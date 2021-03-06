package com.interproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;

public class MainActivity extends AppCompatActivity {

    Button mOfflineButton;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        mOfflineButton = findViewById(R.id.titlescreen_offline);

        mOfflineButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(getApplicationContext(),BTCommunication.class);
                startActivity(intent);
            }
        });

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
