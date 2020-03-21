package com.interproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.media.ToneGenerator;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.SystemClock;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

import org.billthefarmer.mididriver.MidiDriver;

public class PlayPiago extends AppCompatActivity {


    Button mPlaySound;
    public String Instrument;

    //For playing piano with different instruments in midi-player
    private MidiDriver midiDriver;
    private PiagoMidiDriver piagoMidiDriver;
    private int[] config;
    private Button instrumentButton;

    public String ReceivedBluetoothSignal;



    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_play_piago);

        mPlaySound=findViewById(R.id.button_playSound);
        mPlaySound.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ToneGenerator toneGen1 = new ToneGenerator(AudioManager.STREAM_MUSIC, 100);
                toneGen1.startTone(ToneGenerator.TONE_CDMA_PIP,150);

            }
        });

        ReceivedBluetoothSignal = null;
        Instrument = "piano";

        //Midi-player
        midiDriver = new MidiDriver();
        piagoMidiDriver = new PiagoMidiDriver(midiDriver);
        instrumentButton = findViewById(R.id.button_change_instrument);
    }

    @Override
    protected void onResume() {
        super.onResume();
        midiDriver.start();
        config = midiDriver.config();
    }

    @Override
    protected void onPause() {
        super.onPause();
        midiDriver.stop();
    }

    private void playSound(){
        if(ReceivedBluetoothSignal != null){
            switch (ReceivedBluetoothSignal){
                case "000000":{
                    Button pressedTile = findViewById(R.id.tile_white_0);
                    PlayNotePause((byte) 0x35, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "000001":{
                    Button pressedTile = findViewById(R.id.tile_white_1);
                    PlayNotePause((byte) 0x37, R.drawable.tile_white, pressedTile);

                    break;
                }
                case "000010":{
                    Button pressedTile = findViewById(R.id.tile_white_2);
                    PlayNotePause((byte) 0x39, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "000011":{
                    Button pressedTile = findViewById(R.id.tile_white_3);
                    PlayNotePause((byte) 0x3B, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "000100":{
                    Button pressedTile = findViewById(R.id.tile_white_4);
                    PlayNotePause((byte) 0x3C, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "000101":{
                    Button pressedTile = findViewById(R.id.tile_white_5);
                    PlayNotePause((byte) 0x3E, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "000110":{
                    Button pressedTile = findViewById(R.id.tile_white_6);
                    PlayNotePause((byte) 0x40, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "000111":{
                    Button pressedTile = findViewById(R.id.tile_white_7);
                    PlayNotePause((byte) 0x41, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001000":{
                    Button pressedTile = findViewById(R.id.tile_white_8);
                    PlayNotePause((byte) 0x43, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001001":{
                    Button pressedTile = findViewById(R.id.tile_white_9);
                    PlayNotePause((byte) 0x45, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001010":{
                    Button pressedTile = findViewById(R.id.tile_white_10);
                    PlayNotePause((byte) 0x47, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001011":{
                    Button pressedTile = findViewById(R.id.tile_white_11);
                    PlayNotePause((byte) 0x48, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001100":{
                    Button pressedTile = findViewById(R.id.tile_white_12);
                    PlayNotePause((byte) 0x4A, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001101":{
                    Button pressedTile = findViewById(R.id.tile_white_13);
                    PlayNotePause((byte) 0x4C, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001110":{
                    Button pressedTile = findViewById(R.id.tile_white_14);
                    PlayNotePause((byte) 0x4D, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "001111":{
                    Button pressedTile = findViewById(R.id.tile_white_15);
                    PlayNotePause((byte) 0x4F, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "010000":{
                    Button pressedTile = findViewById(R.id.tile_white_16);
                    PlayNotePause((byte) 0x51, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "010001":{
                    Button pressedTile = findViewById(R.id.tile_white_17);
                    PlayNotePause((byte) 0x53, R.drawable.tile_white, pressedTile);
                    break;
                }
                case "010010":{
                    Button pressedTile = findViewById(R.id.tile_black_0);
                    PlayNotePause((byte) 0x36, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "010011":{
                    Button pressedTile = findViewById(R.id.tile_black_1);
                    PlayNotePause((byte) 0x38, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "010100":{
                    Button pressedTile = findViewById(R.id.tile_black_2);
                    PlayNotePause((byte) 0x3A, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "010101":{
                    Button pressedTile = findViewById(R.id.tile_black_3);
                    PlayNotePause((byte) 0x3D, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "010110":{
                    Button pressedTile = findViewById(R.id.tile_black_4);
                    PlayNotePause((byte) 0x3F, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "010111":{
                    Button pressedTile = findViewById(R.id.tile_black_5);
                    PlayNotePause((byte) 0x42, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "011000":{
                    Button pressedTile = findViewById(R.id.tile_black_6);
                    PlayNotePause((byte) 0x44, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "011001":{
                    Button pressedTile = findViewById(R.id.tile_black_7);
                    PlayNotePause((byte) 0x46, R.drawable.tile_black, pressedTile);
                }
                case "011010":{
                    Button pressedTile = findViewById(R.id.tile_black_8);
                    PlayNotePause((byte) 0x49, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "011011":{
                    Button pressedTile = findViewById(R.id.tile_black_9);
                    PlayNotePause((byte) 0x4B, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "011100":{
                    Button pressedTile = findViewById(R.id.tile_black_10);
                    PlayNotePause((byte) 0x4E, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "011101":{
                    Button pressedTile = findViewById(R.id.tile_black_11);
                    PlayNotePause((byte) 0x50, R.drawable.tile_black, pressedTile);
                    break;
                }
                case "011110":{
                    Button pressedTile = findViewById(R.id.tile_black_12);
                    PlayNotePause((byte) 0x52, R.drawable.tile_black, pressedTile);
                    break;
                }


                //ZOEK NOG Ab6 en BB6



                default:
                    break;
            }

            ReceivedBluetoothSignal = null;
        }
    }

    public void playSoundNow(View view) {

        EditText eT = (EditText)findViewById(R.id.testValue);
        ReceivedBluetoothSignal = eT.getText().toString();
        playSound();



        //Intent intent = new Intent(getApplicationContext(), TestMidiActivity.class);
        //startActivity(intent);
    }

    private void PauseMethod(final int tileDrawable, final Button pressedTile){
        pressedTile.setBackgroundResource(R.drawable.tile_pressed);
        new CountDownTimer(500, 100) {
            public void onFinish() {
                // When timer is finished
                // Execute your code here
                pressedTile.setBackgroundResource(tileDrawable);
            }

            public void onTick(long millisUntilFinished) {
                // millisUntilFinished    The amount of time until finished.
            }
        }.start();
    }

    public void changeInstrument(View view) {
        if(instrumentButton.getText().toString().equals("Piano")){
            instrumentButton.setText("Trumpet");
            piagoMidiDriver.InstrumentSelection("Trumpet");
        }else if(instrumentButton.getText().toString().equals("Trumpet")){
            instrumentButton.setText("Harmonica");                          //CHANGED, not harmonica
            piagoMidiDriver.InstrumentSelection("Harmonica");
        }else if(instrumentButton.getText().toString().equals("Harmonica")) {
            instrumentButton.setText("Piano");
            piagoMidiDriver.InstrumentSelection("Piano");
        }
    }

    public void PlayNotePause(byte note, final int tileDrawable, final Button pressedTile){
        piagoMidiDriver.playNote(note);
        PauseMethod(tileDrawable, pressedTile);
    }

    public void octaveLower(View view) {
    }

    public void octaveHigher(View view) {
    }
}



