package com.example.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.media.AudioManager;
import android.media.ToneGenerator;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class PlayPiago extends AppCompatActivity {


    Button mPlaySound;

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
    }

    public void playSound(View view) {
    }
}



