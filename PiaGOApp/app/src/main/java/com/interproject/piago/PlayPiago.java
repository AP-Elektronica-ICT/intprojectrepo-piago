package com.interproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.media.AudioManager;
import android.media.MediaPlayer;
import android.media.ToneGenerator;
import android.os.Bundle;
import android.os.SystemClock;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;

public class PlayPiago extends AppCompatActivity {


    Button mPlaySound;
    public String Instrument;


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
    }

   // public void playSound(View view) {
   // }

    private void playSound(){
        if(ReceivedBluetoothSignal != null){
            switch (ReceivedBluetoothSignal){
                case "000000":{
                    Button pressedTile = findViewById(R.id.tile_white_0);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_f3);
                        mP.start();
                    }

                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "000001":{
                    Button pressedTile = findViewById(R.id.tile_white_1);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_g3);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "000010":{
                    Button pressedTile = findViewById(R.id.tile_white_2);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_a4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "000011":{
                    Button pressedTile = findViewById(R.id.tile_white_3);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);

                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_b4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "000100":{
                    Button pressedTile = findViewById(R.id.tile_white_4);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_c4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "000101":{
                    Button pressedTile = findViewById(R.id.tile_white_5);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_d4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "000110":{
                    Button pressedTile = findViewById(R.id.tile_white_6);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_e4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "000111":{
                    Button pressedTile = findViewById(R.id.tile_white_7);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_f4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001000":{
                    Button pressedTile = findViewById(R.id.tile_white_8);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_g4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001001":{
                    Button pressedTile = findViewById(R.id.tile_white_9);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_a5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001010":{
                    Button pressedTile = findViewById(R.id.tile_white_10);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_b5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001011":{
                    Button pressedTile = findViewById(R.id.tile_white_11);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_c5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001100":{
                    Button pressedTile = findViewById(R.id.tile_white_12);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_d5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001101":{
                    Button pressedTile = findViewById(R.id.tile_white_13);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_e5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001110":{
                    Button pressedTile = findViewById(R.id.tile_white_14);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_f5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "001111":{
                    Button pressedTile = findViewById(R.id.tile_white_15);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_g5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "010000":{
                    Button pressedTile = findViewById(R.id.tile_white_16);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_g5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "010001":{
                    Button pressedTile = findViewById(R.id.tile_white_17);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound



                    //ZOEK NOG A6 & B6




                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_g5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                    break;
                }
                case "010010":{
                    Button pressedTile = findViewById(R.id.tile_black_0);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_gb3);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "010011":{
                    Button pressedTile = findViewById(R.id.tile_black_1);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_ab4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "010100":{
                    Button pressedTile = findViewById(R.id.tile_black_2);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_bb4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "010101":{
                    Button pressedTile = findViewById(R.id.tile_black_3);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_db4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "010110":{
                    Button pressedTile = findViewById(R.id.tile_black_4);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_eb4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "010111":{
                    Button pressedTile = findViewById(R.id.tile_black_5);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_gb4);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "011000":{
                    Button pressedTile = findViewById(R.id.tile_black_6);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_ab5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "011001":{
                    Button pressedTile = findViewById(R.id.tile_black_7);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_bb5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "011010":{
                    Button pressedTile = findViewById(R.id.tile_black_8);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_db5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "011011":{
                    Button pressedTile = findViewById(R.id.tile_black_9);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_eb5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "011100":{
                    Button pressedTile = findViewById(R.id.tile_black_10);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_gb5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "011101":{
                    Button pressedTile = findViewById(R.id.tile_black_11);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_gb5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }
                case "011110":{
                    Button pressedTile = findViewById(R.id.tile_black_12);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    if(Instrument == "piano"){
                        MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_gb5);
                        mP.start();
                    }
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                    break;
                }


                //ZOEK NOG Ab6 en BB6



                default:
                    break;
            }

            ReceivedBluetoothSignal = null;
        }
    }

    @Override
    protected void onResume() {
        super.onResume();
        //playSound();


    }

    public void playSoundNow(View view) {
        //MediaPlayer mP = MediaPlayer.create(this, R.raw.piano_f4);
        //mP.start();
        EditText eT = (EditText)findViewById(R.id.testValue);
        ReceivedBluetoothSignal = eT.getText().toString();
        playSound();
    }
}



