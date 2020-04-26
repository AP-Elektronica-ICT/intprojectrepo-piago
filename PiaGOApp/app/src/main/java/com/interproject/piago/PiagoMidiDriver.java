package com.interproject.piago;
import android.app.Activity;
import android.util.Log;

import org.billthefarmer.mididriver.MidiDriver;

public class PiagoMidiDriver {
    private MidiDriver midiDriver;
    private byte[] event;
    private byte ActiveInstrument;
    public byte MaxVelocity;

    public PiagoMidiDriver(MidiDriver _midiDriver){
        midiDriver = _midiDriver;
        InstantiateInstruments();
        MaxVelocity = (byte) 0x7F;
    }

    public void InstrumentSelection(String instrument){
        switch (instrument) {
            case "Piano":
                ActiveInstrument = (byte) 0x01;
                break;
            case "Trumpet":
                ActiveInstrument = (byte) 0x02;
                event = new byte[2];
                event[0]=(byte)0xC2;    //Channel 2
                event[1]=(byte)0x38;    //Trumpet
                midiDriver.write(event);
                break;
            case "Xylophone":
                ActiveInstrument = (byte) 0x03;
                event = new byte[2];
                event[0]=(byte)0xC3;    //Channel 3
                event[1]=(byte)13;    //Harmonica //CHANGED
                midiDriver.write(event);
                break;
                default:
                    break;
        }
    }

    private void InstantiateInstruments(){
        event = new byte[2];
        event[0]=(byte)0xC2;    //Channel 2
        event[1]=(byte)0x38;    //Trumpet
        midiDriver.write(event);

        event = new byte[2];
        event[0]=(byte)0xC3;    //Channel 3
        event[1]=(byte)0x16;    //Harmonica
        midiDriver.write(event);

        //Other instrument codes:
        //http://www.ccarh.org/courses/253/handout/gminstruments/
        //Convert decimal -1 to hexadecimal
    }

    public void playNote(byte chord){
        //Note on
        event = new byte[3];
        event[0] = (byte) (0x90 | ActiveInstrument);  // 0x90 = note On
        event[1] = (byte) chord;  // 0x3C = middle C
        event[2] = MaxVelocity;  // 0x7F = the maximum velocity (127)

        // Send the MIDI event to the synthesizer.
        midiDriver.write(event);

        //Note off
        event = new byte[3];
        event[0] = (byte) (0x80 | ActiveInstrument);  // 0x90 = note On
        event[1] = (byte) chord;  // 0x3C = middle C
        event[2] = MaxVelocity;  // 0x7F = the maximum velocity (127)

        // Send the MIDI event to the synthesizer.
        midiDriver.write(event);

        Log.i("Debugkey","Sound played ___________ " + chord);
    }
}
