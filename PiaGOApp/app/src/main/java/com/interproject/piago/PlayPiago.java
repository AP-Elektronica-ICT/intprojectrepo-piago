package com.interproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.media.AudioManager;
import android.media.ToneGenerator;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class PlayPiago extends AppCompatActivity {


    Button mPlaySound;

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
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "000001":{
                    Button pressedTile = findViewById(R.id.tile_white_1);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "000010":{
                    Button pressedTile = findViewById(R.id.tile_white_2);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);

                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "000011":{
                    Button pressedTile = findViewById(R.id.tile_white_3);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);

                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "000100":{
                    Button pressedTile = findViewById(R.id.tile_white_4);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "000101":{
                    Button pressedTile = findViewById(R.id.tile_white_5);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "000110":{
                    Button pressedTile = findViewById(R.id.tile_white_6);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "000111":{
                    Button pressedTile = findViewById(R.id.tile_white_7);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001000":{
                    Button pressedTile = findViewById(R.id.tile_white_8);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001001":{
                    Button pressedTile = findViewById(R.id.tile_white_9);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001010":{
                    Button pressedTile = findViewById(R.id.tile_white_10);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001011":{
                    Button pressedTile = findViewById(R.id.tile_white_11);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001100":{
                    Button pressedTile = findViewById(R.id.tile_white_12);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001101":{
                    Button pressedTile = findViewById(R.id.tile_white_13);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001110":{
                    Button pressedTile = findViewById(R.id.tile_white_14);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "001111":{
                    Button pressedTile = findViewById(R.id.tile_white_15);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "010000":{
                    Button pressedTile = findViewById(R.id.tile_white_16);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "010001":{
                    Button pressedTile = findViewById(R.id.tile_white_17);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_white);
                }
                case "010010":{
                    Button pressedTile = findViewById(R.id.tile_black_0);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "010011":{
                    Button pressedTile = findViewById(R.id.tile_black_1);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "010100":{
                    Button pressedTile = findViewById(R.id.tile_black_2);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "010101":{
                    Button pressedTile = findViewById(R.id.tile_black_3);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "010110":{
                    Button pressedTile = findViewById(R.id.tile_black_4);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "010111":{
                    Button pressedTile = findViewById(R.id.tile_black_5);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "011000":{
                    Button pressedTile = findViewById(R.id.tile_black_6);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "011001":{
                    Button pressedTile = findViewById(R.id.tile_black_7);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "011010":{
                    Button pressedTile = findViewById(R.id.tile_black_8);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "011011":{
                    Button pressedTile = findViewById(R.id.tile_black_9);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "011100":{
                    Button pressedTile = findViewById(R.id.tile_black_10);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "011101":{
                    Button pressedTile = findViewById(R.id.tile_black_11);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
                case "011110":{
                    Button pressedTile = findViewById(R.id.tile_black_12);
                    pressedTile.setBackgroundResource(R.drawable.tile_pressed);
                    //Playsound
                    pressedTile.setBackgroundResource(R.drawable.tile_black);
                }
            }

            ReceivedBluetoothSignal = null;
        }
    }

    @Override
    protected void onResume() {
        super.onResume();
        playSound();
    }
}



