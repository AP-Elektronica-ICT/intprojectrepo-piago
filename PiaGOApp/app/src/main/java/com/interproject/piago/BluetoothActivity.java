package com.interproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import java.util.Set;

public class BluetoothActivity extends AppCompatActivity {


    private static final int REQUEST_ENABLE_BT=0;
    private static final int REQUEST_DISCOVER_BT=1;

    TextView mStatusBlueTv;
    TextView mPairedTv;
    ImageView mBlueIv;
    Button mOnBtn, mOffBtn, mDiscoverBtn, mPairedBtn;

    BluetoothAdapter mBlueAdapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_bluetooth);

        mStatusBlueTv = findViewById(R.id.statusBluetoothTv);
        mPairedTv     = findViewById(R.id.pairedTv);
        mBlueIv       = findViewById(R.id.bluetoothIv);
        mOnBtn        = findViewById(R.id.onBtn);
        mOffBtn       = findViewById(R.id.offBtn);
        mDiscoverBtn  = findViewById(R.id.discoverableBtn);
        mPairedBtn    = findViewById(R.id.pairedBtn);


        //Adapter
        mBlueAdapter = BluetoothAdapter.getDefaultAdapter();

        if(mBlueAdapter==null){
            mStatusBlueTv.setText("Bluetooth is not available");
        }else{
            mStatusBlueTv.setText("Bluetooth is available");
        }

        if(mBlueAdapter.isEnabled()){
            mBlueIv.setImageResource(R.drawable.ic_action_on);
        }else{
            mBlueIv.setImageResource(R.drawable.ic_action_off);
        }


        //on btn click
        mOnBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(!mBlueAdapter.isEnabled()){
                    //intent to ON bluetooth
                    Intent intent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
                    startActivityForResult(intent,REQUEST_ENABLE_BT);
                }else{
                    Toast.makeText(getApplicationContext(),"Bluetooth is already ON",Toast.LENGTH_SHORT).show();
                }
            }
        });

        //discover bluetooth btn click
        mDiscoverBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(mBlueAdapter.isDiscovering()){
                    Toast.makeText(getApplicationContext(),"Making device discoverable",Toast.LENGTH_SHORT).show();
                    Intent intent = new Intent(BluetoothAdapter.ACTION_REQUEST_DISCOVERABLE);
                    startActivityForResult(intent, REQUEST_DISCOVER_BT);
                }
            }
        });
        //off btn click
        mOffBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(mBlueAdapter.isEnabled()){
                    mBlueAdapter.disable();
                    Toast.makeText(getApplicationContext(),"Turning OFF bluetooth",Toast.LENGTH_SHORT).show();
                    mBlueIv.setImageResource(R.drawable.ic_action_off);

                }else{
                    Toast.makeText(getApplicationContext(),"Bluetooth is already off",Toast.LENGTH_SHORT).show();
                }
            }
        });
        //get paired devices
        mPairedBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(mBlueAdapter.isEnabled()){
                    mPairedTv.setText("Paired Devices");
                    Set<BluetoothDevice> devices= mBlueAdapter.getBondedDevices();
                    for(BluetoothDevice device:devices){
                        mPairedTv.append("\nDevice: "+device.getName()+", "+device);
                    }
                }else{
                    Toast.makeText(getApplicationContext(),"Turn on BT to get paired devices",Toast.LENGTH_SHORT).show();
                }
            }
        });

    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data){
        switch(requestCode){
            case REQUEST_ENABLE_BT:
                if(resultCode==RESULT_OK){
                    //BT is ON
                    mBlueIv.setImageResource(R.drawable.ic_action_on);
                    Toast.makeText(getApplicationContext(),"Bluetooth is ON",Toast.LENGTH_SHORT).show();

                }else{
                    Toast.makeText(getApplicationContext(),"Didn't turn on BT",Toast.LENGTH_SHORT).show();
                }
                break;

        }
        super.onActivityResult(requestCode,resultCode,data);
    }
}
