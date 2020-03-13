package com.interproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;

import org.billthefarmer.mididriver.MidiDriver;

public class TestMidiActivity extends AppCompatActivity {

    private MidiDriver midiDriver;
    private PiagoMidiDriver piagoMidiDriver;
    //private byte[] event;
    private int[] config;
    private Button buttonPlayNote;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_test_midi_driver);

        buttonPlayNote = (Button)findViewById(R.id.buttonPlayNote);

        midiDriver = new MidiDriver();
        piagoMidiDriver = new PiagoMidiDriver(midiDriver);

        config = midiDriver.config();

    }

    @Override
    protected void onResume() {
        super.onResume();
        midiDriver.start();
        config = midiDriver.config();
        //config[1] = 104;
    }

    @Override
    protected void onPause() {
        super.onPause();
        midiDriver.stop();
    }


    public void playIsIets(View view){
        piagoMidiDriver.playNote((byte)0x02, (byte)0x3C, (byte)0x7F);

        //0x09 tennisracket

    }


}
