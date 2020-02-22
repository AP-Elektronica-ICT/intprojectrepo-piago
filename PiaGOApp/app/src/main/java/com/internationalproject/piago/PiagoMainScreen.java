package com.internationalproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class PiagoMainScreen extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_piago_main_screen);
    }

    public void launchJam(View view) {
        Intent intent = new Intent(getApplicationContext(), PlayPiago.class);
        startActivity(intent);
    }

    public void launchLearn(View view) {
    }

    public void launchCustomize(View view) {
    }
}
