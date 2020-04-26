package com.interproject.piago;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
import android.content.Intent;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;
import android.graphics.drawable.Drawable;
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
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;
import android.widget.ToggleButton;

import com.google.android.gms.common.annotation.KeepForSdkWithFieldsAndMethods;

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
    public PiagoMidiDriver piagoMidiDriver;
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

    public String CheckReceived;

    public OctaveSelector octaveSelector;

    //LearnSongs
    public LearnSongs learn = new LearnSongs();
    public Integer noteNumber = 0;
    public Drawable noteToPlayBackGround;
    public Drawable notePlayedBackGround;
    public Button tileToPress;
    public Boolean noteIsShown = false;
    SignalCheckerThread sChecker;
    PreviewSongThread previewSongThread;
    public Boolean LearningMode = false;
    public Switch learnToggle;
    CorrectNotePlayer cNotePlayer = new CorrectNotePlayer(this);


    //Buttons
    Button previewButton;
    Button octaveHigher;
    Button octaveLower;

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

                        //BluetoothDevice device = mBTAdapter.getRemoteDevice("98:D3:31:FD:17:0A");
                        //DEVICE FINLAND
                        BluetoothDevice device = mBTAdapter.getRemoteDevice("B4:E6:2D:DF:4B:83");

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
//                    String toneToPlay= (readMessage.substring(0,6));
//                    ReceivedBluetoothSignal="1";
//                    playSound(toneToPlay);
                    //String toneToPlay= (readMessage.substring(0,6));
                    CheckReceived="1";
                    ReceivedBluetoothSignal=(readMessage.substring(0,5));
                    //playSound(ReceivedBluetoothSignal);
                    Log.d("BTRECEIVED", "handleMessage: reveiving msg from arduino"+ReceivedBluetoothSignal);

                }

//                if(msg.what == CONNECTING_STATUS){
//                    /*if(msg.arg1 == 1)
//                        //mBluetoothStatus.setText("Connected to Device: " + (String)(msg.obj));
//                    else
//                        //mBluetoothStatus.setText("Connection Failed");*/
//                }
            }
        };

        /*mPlaySound=findViewById(R.id.button_playSound);
        mPlaySound.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                ToneGenerator toneGen1 = new ToneGenerator(AudioManager.STREAM_MUSIC, 100);
                toneGen1.startTone(ToneGenerator.TONE_CDMA_PIP,150);

            }
        });*/

        ReceivedBluetoothSignal = null;
        CheckReceived=null;
        Instrument = "piano";

        //Midi-player
        midiDriver = new MidiDriver();
        piagoMidiDriver = new PiagoMidiDriver(midiDriver);
        instrumentButton = findViewById(R.id.button_change_instrument);

        //Lower / Higher notes
        octaveSelector = new OctaveSelector();

        //Learning
        tileToPress = findViewById(R.id.tile_white_0);
        sChecker = new SignalCheckerThread(this);
        learnToggle = findViewById(R.id.switch_piago);
        learnToggle.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if(isChecked) {
                    LearningMode = true;
                    octaveSelector.SetOctaveLearn();
                    //noteNumber = 0;
                    //ShowCurrentNote(learn.FatherJacob);

                }
                else {
                    LearningMode = false;
                    tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
                }

                ModeSwitcher(LearningMode);
            }
        });

        //Buttons
        previewButton = findViewById(R.id.button_preview);
        octaveHigher = findViewById(R.id.button_octave_higher);
        octaveLower = findViewById(R.id.button_octave_lower);
    }

    @Override
    protected void onResume() {
        super.onResume();
        midiDriver.start();
        config = midiDriver.config();

        //LearnSong(learn.FatherJacob);
        learnToggle.setChecked(false);
        sChecker.start();
    }

    @Override
    protected void onPause() {
        super.onPause();
        midiDriver.stop();
    }

    Button pressedTile;

    private void playSound(String sound){
        if(ReceivedBluetoothSignal != null){
            switch (sound){
                case "00000":{
                    pressedTile = findViewById(R.id.tile_white_0);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[0], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "00010":{
                    pressedTile = findViewById(R.id.tile_white_1);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[2], R.drawable.tile_white, pressedTile);

                    break;
                }
                case "00100":{
                    pressedTile = findViewById(R.id.tile_white_2);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[4], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "00110":{
                    pressedTile = findViewById(R.id.tile_white_3);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[6], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "00111":{
                    pressedTile = findViewById(R.id.tile_white_4);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[7], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "01001":{
                    pressedTile = findViewById(R.id.tile_white_5);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[9], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "01011":{
                    pressedTile = findViewById(R.id.tile_white_6);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[11], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "01100":{
                    pressedTile = findViewById(R.id.tile_white_7);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[12], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "01110":{
                    pressedTile = findViewById(R.id.tile_white_8);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[14], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "10000":{
                    pressedTile = findViewById(R.id.tile_white_9);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[16], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "10010":{
                    pressedTile = findViewById(R.id.tile_white_10);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[18], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "10011":{
                    pressedTile = findViewById(R.id.tile_white_11);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[19], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "10101":{
                    pressedTile = findViewById(R.id.tile_white_12);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[21], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "10111":{
                    pressedTile = findViewById(R.id.tile_white_13);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[23], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "11000":{
                    pressedTile = findViewById(R.id.tile_white_14);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[24], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "11010":{
                    pressedTile = findViewById(R.id.tile_white_15);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[26], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "11100":{
                    pressedTile = findViewById(R.id.tile_white_16);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[28], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "11110":{
                    pressedTile = findViewById(R.id.tile_white_17);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[30], R.drawable.tile_white, pressedTile);
                    break;
                }
                case "00001":{
                    pressedTile = findViewById(R.id.tile_black_0);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[1], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "00011":{
                    pressedTile = findViewById(R.id.tile_black_1);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[3], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "00101":{
                    pressedTile = findViewById(R.id.tile_black_2);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[5], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "01000":{
                    pressedTile = findViewById(R.id.tile_black_3);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[8], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "01010":{
                    pressedTile = findViewById(R.id.tile_black_4);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[10], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "01101":{
                    pressedTile = findViewById(R.id.tile_black_5);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[13], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "01111":{
                    pressedTile = findViewById(R.id.tile_black_6);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[15], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "10001":{
                    pressedTile = findViewById(R.id.tile_black_7);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[17], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "10100":{
                    pressedTile = findViewById(R.id.tile_black_8);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[20], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "10110":{
                    pressedTile = findViewById(R.id.tile_black_9);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[22], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "11001":{
                    pressedTile = findViewById(R.id.tile_black_10);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[25], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "11011":{
                    pressedTile = findViewById(R.id.tile_black_11);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[27], R.drawable.tile_black, pressedTile);
                    break;
                }
                case "11101":{
                    pressedTile = findViewById(R.id.tile_black_12);
                    notePlayedBackGround = pressedTile.getBackground();
                    PlayNotePause(octaveSelector.ActiveOctaveArray[29], R.drawable.tile_black, pressedTile);
                    break;
                }
                default:
                    break;
            }
            ReceivedBluetoothSignal = null;
        }
    }

    //Test method
    public void playSoundNow(View view) {

        //cNotePlayer.start();
        EditText eT = (EditText)findViewById(R.id.testValue);
        ReceivedBluetoothSignal = eT.getText().toString();


       // PlayFatherJacob(learn.FatherJacob, learn.FatherJacobTiming);
        //previewSongThread = new PreviewSongThread(this, learn.FatherJacob, learn.FatherJacobTiming);
        //previewSongThread.start();

    }

    private void PauseMethod(final int tileDrawable, final Button pressedTile){
        pressedTile.setBackgroundResource(R.drawable.tile_pressed);
        new CountDownTimer(200, 100) {
            public void onFinish() {
                // When timer is finished
                // Execute your code here
                //pressedTile.setBackgroundResource(tileDrawable);
                pressedTile.setBackground(OriginalBackground(pressedTile.getId()));
            }

            public void onTick(long millisUntilFinished) {
                // millisUntilFinished    The amount of time until finished.
            }
        }.start();
    }

    public void changeInstrument(View view) {
        showAlertDialogInstrument();
    }

    private void showAlertDialogInstrument(){
        AlertDialog.Builder alertDialog = new AlertDialog.Builder(PlayPiago.this);
        alertDialog.setTitle("Select your instrument");
        String[] instruments={"Piano", "Trumpet", "Xylophone"};
        alertDialog.setSingleChoiceItems(instruments, -1, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                switch (which){
                    case 0: {
                        instrumentButton.setText("Piano");
                        piagoMidiDriver.InstrumentSelection("Piano");
                        break;
                    }
                    case 1: {
                        instrumentButton.setText("Trumpet");
                        piagoMidiDriver.InstrumentSelection("Trumpet");
                        break;
                    }
                    case 2: {
                        instrumentButton.setText("Xylophone");
                        piagoMidiDriver.InstrumentSelection("Xylophone");
                        break;
                    }
                    default:
                        break;
                }
            }
        });
        alertDialog.setPositiveButton("Back to Keyboard", new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                dialog.dismiss();
            }
        });
        AlertDialog alert = alertDialog.create();
        alert.setCanceledOnTouchOutside(false);
        alert.show();
    }

    public void PlayNotePause(byte note, final int tileDrawable, final Button pressedTile){
        piagoMidiDriver.playNote(note);
        Log.i("Debugkey", "_______________Note played through PlayNotePause");
        PauseMethod(tileDrawable, pressedTile);
    }

    public void octaveLower(View view) {
        octaveSelector.OctaveDown();
    }

    public void octaveHigher(View view) {
        octaveSelector.OctaveUp();
    }


    // BLUETOOTH STUFF

    private BluetoothSocket createBluetoothSocket(BluetoothDevice device) throws IOException {
        return  device.createRfcommSocketToServiceRecord(BTMODULEUUID);
        //creates secure outgoing connection with BT device using UUID
    }

    public void previewSong(View view) {
        tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
        songStarted = false;
        noteNumber = 0;
        previewSongThread = new PreviewSongThread(this, learn.FatherJacob, learn.FatherJacobTiming);
        //previewSongThread = new PreviewSongThread(this, learn.WiiNotes, learn.WiiTiming);
        previewSongThread.start();
    }

    public Boolean songStarted = false;
    public void startSong(View view) {
        tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
        noteNumber = 0;
        ShowCurrentNote(learn.FatherJacob);
        songStarted = true;
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
    
    public Boolean notePlayed = false;

    //Learn
    public void LearnSong(byte[] noteArray){
        if(!noteIsShown){
            ShowCurrentNote(noteArray);
            //Log.i("BT", "ShowCurrentNote method");
        }
        if(!notePlayed){
            CheckNotePlayed(noteArray);
            //Log.i("BT", "CheckNote method");
        }

        if(noteNumber >=  noteArray.length) {
            noteNumber = 0;
            songStarted = false;
        }

        //sChecker.execute();
    }

    private void PauseMethodLearn(final Button pressedTile, final int backgGroundStatus, final byte[] array){
        pressedTile.setBackgroundResource(backgGroundStatus);
        Log.i("Debugkey", "Key pressedTile BG set to green or red");
        new CountDownTimer(200, 100) {
            public void onFinish() {
                // When timer is finished
                // Execute your code here
                //pressedTile.setBackground(notePlayedBackGround);
                pressedTile.setBackground(OriginalBackground(pressedTile.getId()));
                Log.i("Debugkey", "PressedTile BG back to original");
                tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
                Log.i("Debugkey", "TileToPress BG back to original");
                ShowCurrentNote(array);

            }

            public void onTick(long millisUntilFinished) {
                // millisUntilFinished    The amount of time until finished.
            }
        }.start();
    }

    //Laat de noot zien die gespeeld moet worden
    public void ShowCurrentNote(byte[] noteArray){
        Integer noteIndex = 0;

        for(int i = 0; i < octaveSelector.ActiveOctaveArray.length; i++){
            if(noteArray[noteNumber] == octaveSelector.ActiveOctaveArray[i])
                noteIndex = i;
        }

        tileToPress = findViewById(learn.KeyArray[noteIndex]);
        noteToPlayBackGround = tileToPress.getBackground();

        tileToPress.setBackgroundResource(R.drawable.tile_to_press);
        Log.i("Debugkey", "Key tileToPress is set to Blue, key index "+noteIndex);

        noteIsShown = true;
        notePlayed = false;
        Log.i("Debugkey", "ShowCurrentNote() executed");
    }

    //Check of er een bluetoothsignaal is, zo ja check of het overeenkomt met hetgene dat nodig is
    public void CheckNotePlayed(final byte[] array){
        if(ReceivedBluetoothSignal != null) {
            playSound(ReceivedBluetoothSignal);
            Log.i("Debugkey","Sound played through checknoteplayed()");
            //tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
            //Log.i("Debugkey", "Key tileToPress OG background reset");
                if (pressedTile == tileToPress) {
                    //Is de noot correct, laat dan een groene background kort zien
                    PauseMethodLearn(pressedTile, R.drawable.tile_pressed, array);
                    //Log.i("BT", "Correct key");
                    noteNumber++;
                } else {
                    //is de noot incorrect, laat dan een rode achtergrond zien
                    PauseMethodLearn(pressedTile, R.drawable.tile_pressed_fault, array);
                }
            //Reset background van noot die gespeeld moest worden

            notePlayed = true;
            //noteIsShown = false;
            //noteNumber++;


            Log.i("Debugkey", "ChecknotePlayed() executed");
        }
    }

    private void ModeSwitcher(boolean learnModeOn){
        if(learnModeOn){
            octaveLower.setVisibility(View.GONE);
            octaveHigher.setVisibility(View.GONE);
            previewButton.setVisibility(View.VISIBLE);
        }else{
            previewButton.setVisibility(View.GONE);
            octaveLower.setVisibility(View.VISIBLE);
            octaveHigher.setVisibility(View.VISIBLE);
        }
    }




    //CLEANUP POSSIBLE
    public void runThreadLearn(){
        runOnUiThread (new Thread(new Runnable() {
            public void run() {

                    if(songStarted) {
                        LearnSong(learn.FatherJacob);
                    }
                    else {
                        playSound(ReceivedBluetoothSignal);
                        Log.i("Debugkey", "__________Sound played while songstarted was off");
                    }
                Log.i("Debugkey", "LearnSong() executed");

                }

        }));
    }

    //CLEANUP POSSIBLE
    public void runThreadNormal(){
        runOnUiThread (new Thread(new Runnable() {
            public void run() {

                    playSound(ReceivedBluetoothSignal);
                Log.i("Debugkey", "__________Sound played in runThreadNormal");
            }

        }));
    }

    public Drawable OriginalBackground(int tileResource){
        int i = 0;
        for(int j = 0; j < learn.KeyArray.length; j++){
            if(learn.KeyArray[j] == tileResource) {
                i = j;
                //Log.i("BT", "Tile number :" +j);
            }
        }

        switch (i){
            case 0:
                return getResources().getDrawable(R.drawable.tile_white);
            case 1:
                return getResources().getDrawable(R.drawable.tile_black);
            case 2:
                return getResources().getDrawable(R.drawable.tile_white);
            case 3:
                return getResources().getDrawable(R.drawable.tile_black);
            case 4:
                return getResources().getDrawable(R.drawable.tile_white);
            case 5:
                return getResources().getDrawable(R.drawable.tile_black);
            case 6:
                return getResources().getDrawable(R.drawable.tile_white);
            case 7:
                return getResources().getDrawable(R.drawable.tile_white);
            case 8:
                return getResources().getDrawable(R.drawable.tile_black);
            case 9:
                return getResources().getDrawable(R.drawable.tile_white);
            case 10:
                return getResources().getDrawable(R.drawable.tile_black);
            case 11:
                return getResources().getDrawable(R.drawable.tile_white);
            case 12:
                return getResources().getDrawable(R.drawable.tile_white);
            case 13:
                return getResources().getDrawable(R.drawable.tile_black);
            case 14:
                return getResources().getDrawable(R.drawable.tile_white);
            case 15:
                return getResources().getDrawable(R.drawable.tile_black);
            case 16:
                return getResources().getDrawable(R.drawable.tile_white);
            case 17:
                return getResources().getDrawable(R.drawable.tile_black);
            case 18:
                return getResources().getDrawable(R.drawable.tile_white);
            case 19:
                return getResources().getDrawable(R.drawable.tile_white);
            case 20:
                return getResources().getDrawable(R.drawable.tile_black);
            case 21:
                return getResources().getDrawable(R.drawable.tile_white);
            case 22:
                return getResources().getDrawable(R.drawable.tile_black);
            case 23:
                return getResources().getDrawable(R.drawable.tile_white);
            case 24:
                return getResources().getDrawable(R.drawable.tile_white);
            case 25:
                return getResources().getDrawable(R.drawable.tile_black);
            case 26:
                return getResources().getDrawable(R.drawable.tile_white);
            case 27:
                return getResources().getDrawable(R.drawable.tile_black);
            case 28:
                return getResources().getDrawable(R.drawable.tile_white);
            case 29:
                return getResources().getDrawable(R.drawable.tile_black);
            case 30:
                return getResources().getDrawable(R.drawable.tile_white);
                default:
            return getResources().getDrawable(R.drawable.tile_white);
            }
        }
    }






