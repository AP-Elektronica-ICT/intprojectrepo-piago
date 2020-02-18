package com.example.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
    }

    public void loginActivity(View view) {
        Intent intent = new Intent(getApplicationContext(), PiagoMainScreen.class);
        startActivity(intent);
    }

    public void playOffline(View view) {
        Intent intent = new Intent(getApplicationContext(), PlayPiago.class);
        startActivity(intent);
    }

    public void signupActivity(View view) {
    }

    public void passwordRecovery(View view) {
    }
}
