﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BizHawk.Emulation.Cores.Computers.Commodore64.Media;

namespace BizHawk.Emulation.Cores.Computers.Commodore64.Serial
{
    public sealed partial class Drive1541
    {
        [SaveState.DoNotSave]
        private const long LEHMER_RNG_PRIME = 48271;
        [SaveState.SaveWithName("DiskDensityCounter")]
        private int _diskDensityCounter; // density .. 16
        [SaveState.SaveWithName("DiskSupplementaryCounter")]
        private int _diskSupplementaryCounter; // 0 .. 16
        [SaveState.SaveWithName("DiskFluxReversalDetected")]
        private bool _diskFluxReversalDetected;
        [SaveState.SaveWithName("DiskBitsRemainingInDataEntry")]
        private int _diskBitsLeft;
        [SaveState.SaveWithName("DiskDataEntryIndex")]
        private int _diskByteOffset;
        [SaveState.SaveWithName("DiskDataEntry")]
        private int _diskBits;
        [SaveState.SaveWithName("DiskCurrentCycle")]
        private int _diskCycle;
        [SaveState.SaveWithName("DiskDensityConfig")]
        private int _diskDensity;
        [SaveState.SaveWithName("PreviousCA1")]
        private bool _previousCa1;
        [SaveState.SaveWithName("CountsBeforeRandomTransition")]
        private int _countsBeforeRandomTransition;
        [SaveState.SaveWithName("CurrentRNG")]
        private int _rngCurrent;
        [SaveState.SaveWithName("Clocks")]
        private int _clocks;
        [SaveState.SaveWithName("CpuClocks")]
        private int _cpuClocks;
        [SaveState.SaveWithName("DiskWriteBitsRemaining")]
        private int _diskWriteBitsRemaining;
        [SaveState.SaveWithName("DiskWriteEnabled")]
        private bool _diskWriteEnabled;
        [SaveState.SaveWithName("DiskWriteLatch")]
        private int _diskWriteLatch;
        [SaveState.SaveWithName("DiskOutputBits")]
        private int _diskOutputBits;
        [SaveState.SaveWithName("DiskWriteProtected")]
        private bool _diskWriteProtected;

        // Lehmer RNG
        private void AdvanceRng()
        {
            if (_rngCurrent == 0)
                _rngCurrent = 1;
            _rngCurrent = (int)(_rngCurrent * LEHMER_RNG_PRIME % int.MaxValue);
        }

        private void ExecuteFlux()
        {
            // This actually executes the main 16mhz clock
            while (_clocks > 0)
            {
                _clocks--;

                // rotate disk
                if (_motorEnabled)
                {
                    if (_disk == null)
                    {
                        _diskBitsLeft = 1;
                        _diskBits = 0;
                    }
                    else
                    {
                        if (_diskBitsLeft <= 0)
                        {
                            if (_diskWriteEnabled)
                                _trackImageData[_diskByteOffset] = _diskOutputBits;

                            _diskByteOffset++;

                            if (_diskByteOffset == Disk.FluxEntriesPerTrack)
                                _diskByteOffset = 0;

                            if (!_diskWriteEnabled)
                                _diskBits = _trackImageData[_diskByteOffset];

                            _diskOutputBits = 0;
                            _diskBitsLeft = Disk.FluxBitsPerEntry;
                        }
                    }
                    _diskOutputBits >>= 1;

                    if (_diskWriteEnabled)
                        _countsBeforeRandomTransition = 0;

                    if ((_diskBits & 1) != 0)
                    {
                        _countsBeforeRandomTransition = 0;
                        _diskFluxReversalDetected = true;
                        _diskOutputBits |= int.MinValue; // set bit 31
                    }
                    else
                    {
                        _diskOutputBits &= int.MaxValue; // clear bit 31
                    }

                    _diskBits >>= 1;
                    _diskBitsLeft--;
                }

                // random flux transition readings for unformatted data
                if (_countsBeforeRandomTransition > 0)
                {
                    _countsBeforeRandomTransition--;
                    if (_countsBeforeRandomTransition == 0)
                    {
                        _diskFluxReversalDetected = true;
                        AdvanceRng();
                        // This constant is what VICE uses. TODO: Determine accuracy.
                        _countsBeforeRandomTransition = (_rngCurrent % 367) + 33;
                    }
                }

                // flux transition circuitry
                if (_diskFluxReversalDetected)
                {
                    if (!_diskWriteEnabled)
                    {
                        _diskDensityCounter = _diskDensity;
                        _diskSupplementaryCounter = 0;
                    }
                    _diskFluxReversalDetected = false;
                    if (_countsBeforeRandomTransition == 0)
                    {
                        AdvanceRng();
                        // This constant is what VICE uses. TODO: Determine accuracy.
                        _countsBeforeRandomTransition = (_rngCurrent & 0x1F) + 289;
                    }
                }

                // counter circuitry
                if (_diskDensityCounter >= 16)
                {
                    _diskDensityCounter = _diskDensity;
                    _diskSupplementaryCounter++;

                    if ((_diskSupplementaryCounter & 0x3) == 0x2)
                    {
                        if (!_diskWriteEnabled)
                            _diskWriteBitsRemaining = 0;
                        _diskWriteEnabled = !Via1.Cb2;

                        _diskWriteBitsRemaining--;
                        if (_diskWriteEnabled)
                        {
                            _countsBeforeRandomTransition = 0;
                            _byteReady = false;
                            if (_diskWriteBitsRemaining <= 0)
                            {
                                _diskWriteLatch = Via1.EffectivePrA;
                                _diskWriteBitsRemaining = 8;
                                _byteReady = Via1.Ca2;
                            }
                            if ((_diskWriteLatch & 0x80) != 0)
                            {
                                _diskOutputBits |= int.MinValue; // set bit 31
                            }
                            _diskWriteLatch <<= 1;
                        }
                        else
                        {
                            _bitsRemainingInLatchedByte--;
                            _byteReady = false;
                            _bitHistory = (_bitHistory << 1) | ((_diskSupplementaryCounter & 0xC) == 0x0 ? 1 : 0);
                            _sync = false;
                            if (!_diskWriteEnabled && (_bitHistory & 0x3FF) == 0x3FF)
                            {
                                _sync = true;
                                _bitsRemainingInLatchedByte = 8;
                                _byteReady = false;
                            }

                            if (_bitsRemainingInLatchedByte <= 0)
                            {
                                _bitsRemainingInLatchedByte = 8;

                                // SOE (SO/Byte Ready enabled)
                                _byteReady = Via1.Ca2;
                            }
                        }
                    }

                    // negative transition activates SO pin on CPU
                    _previousCa1 = Via1.Ca1;
                    Via1.Ca1 = !_byteReady;
                    if (_previousCa1 && !Via1.Ca1)
                    {
                        // cycle 6 is roughly 400ns
                        _overflowFlagDelaySr |= _diskCycle > 6 ? 4 : 2;
                    }
                }

                if (_diskSupplementaryCounter >= 16)
                {
                    _diskSupplementaryCounter = 0;
                }

                _cpuClocks--;
                if (_cpuClocks <= 0)
                {
                    ExecuteSystem();
                    _cpuClocks = 16;
                }

                _diskDensityCounter++;
                _diskCycle = (_diskCycle + 1) & 0xF;
            }
        }
    }
}
