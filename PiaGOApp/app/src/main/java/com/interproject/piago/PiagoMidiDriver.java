package com.interproject.piago;
import org.billthefarmer.mididriver.MidiDriver;

public class PiagoMidiDriver {
    private MidiDriver midiDriver;
    private byte[] event;
    //private int[] config;

    public PiagoMidiDriver(MidiDriver _midiDriver){
        midiDriver = _midiDriver;
    }

    public void playNote(byte channel, byte chord, byte maxVelocity){
        event = new byte[2];
        event[0]=(byte)0xC2; //New instrument on channel 2
        event[1]=(byte)0x28; //Instrument with hex 0x28 (+1)
        midiDriver.write(event);

        //Note on
        event = new byte[3];
        event[0] = (byte) (0x90 | channel);  // 0x90 = note On, 0x00 = channel 1
        event[1] = (byte) chord;  // 0x3C = middle C
        event[2] = (byte) maxVelocity;  // 0x7F = the maximum velocity (127)

        // Internally this just calls write() and can be considered obsoleted:
        //midiDriver.queueEvent(event);

        // Send the MIDI event to the synthesizer.
        midiDriver.write(event);

        //Note off
        event = new byte[3];
        event[0] = (byte) (0x80 | channel);  // 0x90 = note On, 0x00 = channel 1
        event[1] = (byte) chord;  // 0x3C = middle C
        event[2] = (byte) maxVelocity;  // 0x7F = the maximum velocity (127)

        // Internally this just calls write() and can be considered obsoleted:
        //midiDriver.queueEvent(event);

        // Send the MIDI event to the synthesizer.
        midiDriver.write(event);
    }
}
