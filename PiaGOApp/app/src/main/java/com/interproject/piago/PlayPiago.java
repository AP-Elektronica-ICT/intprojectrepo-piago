package com.interproject.piago;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.media.AudioManager;
import android.media.MediaPlayer;
import android.media.ToneGenerator;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Handler;
import android.os.SystemClock;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import org.billthefarmer.mididriver.MidiDriver;

import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.io.UnsupportedEncodingException;
import java.util.UUID;

public class PlayPiago extends AppCompatActivity {


    Button mPlaySound;
    public String Instrument;

    //For playing piano with different instruments in midi-player
    private MidiDriver midiDriver;
    private PiagoMidiDriver piagoMidiDriver;
    private int[] config;
    private Button instrumentButton;




    //BLUETOOTH STUFF
    private Handler mHandler;
    private BluetoothSocket mBTSocket = null; // bi-directional client-to-client data path
    private ConnectedThread mConnectedThread;

    private BluetoothAdapter mBTAdapter;

    private Button mButtonAutoCnct;
    // #defines for identifying shared types between calling functions
    private final static int REQUEST_ENABLE_BT = 1; // used to identify adding bluetooth names
    private final static int MESSAGE_READ = 2; // used in bluetooth handler to identify message update
    private final static int CONNECTING_STATUS = 3; // used in bluetooth handler to identify message status

    private static final UUID BTMODULEUUID = UUID.fromString("00001101-0000-1000-8000-00805F9B34FB"); // "random" unique identifier





    public String ReceivedBluetoothSignal;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_play_piago);



        mButtonAutoCnct=(Button)findViewById(R.id.button_autocnct);
        mBTAdapter = BluetoothAdapter.getDefaultAdapter(); // get a handle on the bluetooth radio



        mButtonAutoCnct.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                new Thread()
                {
                    public void run() {
                        boolean fail = false;
                        // Change adress to static MAC adress
                        // BluetoothDevice device = mBTAdapter.getRemoteDevice(address);
                        BluetoothDevice device = mBTAdapter.getRemoteDevice("98:D3:31:FD:17:0A");
                        //BluetoothDevice device = mBTAdapter.getRemoteDevice("B4:E6:2D:DF:4B:83");

                        try {
                            mBTSocket = createBluetoothSocket(device);
                        } catch (IOException e) {
                            fail = true;
                            Toast.makeText(getBaseContext(), "Socket creation failed", Toast.LENGTH_SHORT).show();
                        }
                        // Establish the Bluetooth socket connection.
                        try {
                            mBTSocket.connect();
                        } catch (IOException e) {
                            try {
                                fail = true;
                                mBTSocket.close();
                                mHandler.obtainMessage(CONNECTING_STATUS, -1, -1)
                                        .sendToTarget();
                            } catch (IOException e2) {
                                //insert code to deal with this
                                Toast.makeText(getBaseContext(), "Socket creation failed", Toast.LENGTH_SHORT).show();
                            }
                        }
                        if(fail == false) {
                            mConnectedThread = new ConnectedThread(mBTSocket);
                            mConnectedThread.start();

                            mHandler.obtainMessage(CONNECTING_STATUS, 1, -1, "Piago Keyboard")
                                    .sendToTarget();
                        }
                    }
                }.start();
            }
        });

        mHandler = new Handler(){
            public void handleMessage(android.os.Message msg){
                if(msg.what == MESSAGE_READ){
                    String readMessage = null;
                    try {
                        readMessage = new String((byte[]) msg.obj, "UTF-8");
                    } catch (UnsupportedEncodingException e) {
                        e.printStackTrace();
                    }
                    //String info = ((TextView) v).getText().toString();
                    //mReadBuffer.setText(readMessage);
                    //int i = Integer.parseInt(readMessage);
                    //ReceivedBluetoothSignal=readMessage;
                    String toneToPlay= (readMessage.substring(0,6));
                    ReceivedBluetoothSignal="1";
                    playSound(toneToPlay);
                    Log.d("BTRECEIVED", "handleMessage: reveiving msg from arduino"+toneToPlay);

                }

//                if(msg.what == CONNECTING_STATUS){
//                    /*if(msg.arg1 == 1)
//                        //mBluetoothStatus.setText("Connected to Device: " + (String)(msg.obj));
//                    else
//                        //mBluetoothStatus.setText("Connection Failed");*/
//                }
            }
        };

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

    private void playSound(String sound){
        //if(ReceivedBluetoothSignal != null){
            switch (sound){
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
            //}

            //ReceivedBluetoothSignal = null;
        }
    }

/*    public void playSoundNow(View view) {

        EditText eT = (EditText)findViewById(R.id.testValue);
        ReceivedBluetoothSignal = eT.getText().toString();
        playSound();



        //Intent intent = new Intent(getApplicationContext(), TestMidiActivity.class);
        //startActivity(intent);
    }*/

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


    // BLUETOOTH STUFF

    private BluetoothSocket createBluetoothSocket(BluetoothDevice device) throws IOException {
        return  device.createRfcommSocketToServiceRecord(BTMODULEUUID);
        //creates secure outgoing connection with BT device using UUID
    }

    private class ConnectedThread extends Thread {
        private final BluetoothSocket mmSocket;
        private final InputStream mmInStream;
        private final OutputStream mmOutStream;

        public ConnectedThread(BluetoothSocket socket) {
            mmSocket = socket;
            InputStream tmpIn = null;
            OutputStream tmpOut = null;

            // Get the input and output streams, using temp objects because
            // member streams are final
            try {
                tmpIn = socket.getInputStream();
                tmpOut = socket.getOutputStream();
            } catch (IOException e) { }

            mmInStream = tmpIn;
            mmOutStream = tmpOut;
        }

        public void run() {

            byte[] buffer = new byte[1024];  // buffer store for the stream
            int bytes; // bytes returned from read()
            // Keep listening to the InputStream until an exception occurs
            while (true) {
                try {
                    // Read from the InputStream
                    bytes = mmInStream.available();
                    if(bytes != 0) {
                        SystemClock.sleep(100); //pause and wait for rest of data. Adjust this depending on your sending speed.
                        bytes = mmInStream.available(); // how many bytes are ready to be read?
                        bytes = mmInStream.read(buffer);
                        //bytes = mmInStream.read(buffer, 1, bytes); // record how many bytes we actually read
                        /*mHandler.obtainMessage(MESSAGE_READ, bytes, -1, buffer)
                                .sendToTarget(); // Send the obtained bytes to the UI activity*/

                        mHandler.obtainMessage(MESSAGE_READ, bytes, 1, buffer)
                                .sendToTarget(); // Send the obtained bytes to the UI activity
                    }
                } catch (IOException e) {
                    e.printStackTrace();

                    break;
                }
            }
        }

        /* Call this from the main activity to send data to the remote device */
        public void write(String input) {
            byte[] bytes = input.getBytes();           //converts entered String into bytes
            try {
                mmOutStream.write(bytes);
            } catch (IOException e) { }
        }

        /* Call this from the main activity to shutdown the connection */
        public void cancel() {
            try {
                mmSocket.close();
            } catch (IOException e) { }
        }
    }
}



