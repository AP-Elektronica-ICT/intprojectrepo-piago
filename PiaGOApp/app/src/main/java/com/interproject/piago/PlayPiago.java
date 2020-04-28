package com.interproject.piago;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.content.DialogInterface;
import android.content.Intent;

import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothSocket;


import android.graphics.Color;
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
    public String Instrument;

    //For playing piano with different instruments in midi-player
    private MidiDriver midiDriver;
    public PiagoMidiDriver piagoMidiDriver;
    private int[] config;
    public Button instrumentButton;


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
    public Boolean songStarted = false;
    public LearnSongs learn = new LearnSongs();
    public Integer noteNumber = 0;
    public Button tileToPress;
    public Boolean noteIsShown = false;
    SignalCheckerThread sChecker;
    PreviewSongThread previewSongThread;
    public Boolean LearningMode = false;
    public Switch learnToggle;

    //Buttons
    Button previewButton;
    Button startButton;
    Button octaveHigher;
    Button octaveLower;
    Button selectSong;

    TextView activeSong;

    byte[] activeSongByteArray = new byte[]{};
    int[] activeSongIntArray = new int[]{};

    AlertDialogBuilder alertDialog;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_play_piago);
        mButtonAutoCnct = (Button) findViewById(R.id.button_autocnct);
        mBTAdapter = BluetoothAdapter.getDefaultAdapter(); // get a handle on the bluetooth radio

        mButtonAutoCnct.setBackgroundColor(Color.RED);

        mButtonAutoCnct.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                new Thread() {
                    public void run() {
                        boolean fail = false;
                        // Change adress to static MAC adress
                        // BluetoothDevice device = mBTAdapter.getRemoteDevice(address);

                        BluetoothDevice device = mBTAdapter.getRemoteDevice("98:D3:31:FD:17:0A");
                        //DEVICE FINLAND
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
                        if (fail == false) {

                            mConnectedThread = new ConnectedThread(mBTSocket);
                            mConnectedThread.start();
                            mButtonAutoCnct.setBackgroundColor(Color.GREEN);
                            mHandler.obtainMessage(CONNECTING_STATUS, 1, -1, "Piago Keyboard")
                                    .sendToTarget();

                        }
                    }
                }.start();
                //mButtonAutoCnct.setBackgroundColor(Color.GREEN);
            }
        });

        mHandler = new Handler() {
            public void handleMessage(android.os.Message msg) {
                if (msg.what == MESSAGE_READ) {
                    String readMessage = null;
                    try {
                        readMessage = new String((byte[]) msg.obj, "UTF-8");
                    } catch (UnsupportedEncodingException e) {
                        e.printStackTrace();
                    }
                    CheckReceived = "1";
                    ReceivedBluetoothSignal = (readMessage.substring(0, 5));
                    Log.d("BTRECEIVED", "handleMessage: receiving msg from arduino" + ReceivedBluetoothSignal);
                }
            }
        };

        ReceivedBluetoothSignal = null;
        CheckReceived = null;
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
                if (isChecked) {
                    LearningMode = true;
                    octaveSelector.SetOctaveLearn();
                } else {
                    LearningMode = false;
                    tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
                }

                ModeSwitcher(LearningMode);
            }
        });

        //Buttons
        previewButton = findViewById(R.id.button_preview);
        startButton = findViewById(R.id.button_start_song);
        octaveHigher = findViewById(R.id.button_octave_higher);
        octaveLower = findViewById(R.id.button_octave_lower);
        selectSong = findViewById(R.id.button_change_song);
        activeSong = findViewById(R.id.textView_active_song);

        activeSongByteArray = learn.FatherJacob;
        activeSongIntArray = learn.FatherJacobTiming;

        alertDialog = new AlertDialogBuilder();
    }

    @Override
    protected void onResume() {
        super.onResume();
        midiDriver.start();
        config = midiDriver.config();
        learnToggle.setChecked(false);
        sChecker.start();
    }

    @Override
    protected void onPause() {
        super.onPause();
        midiDriver.stop();
    }

    Button pressedTile;

    public void playSound(String sound) {
        if (ReceivedBluetoothSignal != null) {
            switch (sound) {
                case "00000": {
                    pressedTile = findViewById(R.id.tile_white_0);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[0], pressedTile);
                    break;
                }
                case "00010": {
                    pressedTile = findViewById(R.id.tile_white_1);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[2], pressedTile);

                    break;
                }
                case "00100": {
                    pressedTile = findViewById(R.id.tile_white_2);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[4], pressedTile);
                    break;
                }
                case "00110": {
                    pressedTile = findViewById(R.id.tile_white_3);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[6], pressedTile);
                    break;
                }
                case "00111": {
                    pressedTile = findViewById(R.id.tile_white_4);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[7], pressedTile);
                    break;
                }
                case "01001": {
                    pressedTile = findViewById(R.id.tile_white_5);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[9], pressedTile);
                    break;
                }
                case "01011": {
                    pressedTile = findViewById(R.id.tile_white_6);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[11], pressedTile);
                    break;
                }
                case "01100": {
                    pressedTile = findViewById(R.id.tile_white_7);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[12], pressedTile);
                    break;
                }
                case "01110": {
                    pressedTile = findViewById(R.id.tile_white_8);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[14], pressedTile);
                    break;
                }
                case "10000": {
                    pressedTile = findViewById(R.id.tile_white_9);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[16], pressedTile);
                    break;
                }
                case "10010": {
                    pressedTile = findViewById(R.id.tile_white_10);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[18], pressedTile);
                    break;
                }
                case "10011": {
                    pressedTile = findViewById(R.id.tile_white_11);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[19], pressedTile);
                    break;
                }
                case "10101": {
                    pressedTile = findViewById(R.id.tile_white_12);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[21], pressedTile);
                    break;
                }
                case "10111": {
                    pressedTile = findViewById(R.id.tile_white_13);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[23], pressedTile);
                    break;
                }
                case "11000": {
                    pressedTile = findViewById(R.id.tile_white_14);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[24], pressedTile);
                    break;
                }
                case "11010": {
                    pressedTile = findViewById(R.id.tile_white_15);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[26], pressedTile);
                    break;
                }
                case "11100": {
                    pressedTile = findViewById(R.id.tile_white_16);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[28], pressedTile);
                    break;
                }
                case "11110": {
                    pressedTile = findViewById(R.id.tile_white_17);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[30], pressedTile);
                    break;
                }
                case "00001": {
                    pressedTile = findViewById(R.id.tile_black_0);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[1], pressedTile);
                    break;
                }
                case "00011": {
                    pressedTile = findViewById(R.id.tile_black_1);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[3], pressedTile);
                    break;
                }
                case "00101": {
                    pressedTile = findViewById(R.id.tile_black_2);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[5], pressedTile);
                    break;
                }
                case "01000": {
                    pressedTile = findViewById(R.id.tile_black_3);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[8], pressedTile);
                    break;
                }
                case "01010": {
                    pressedTile = findViewById(R.id.tile_black_4);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[10], pressedTile);
                    break;
                }
                case "01101": {
                    pressedTile = findViewById(R.id.tile_black_5);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[13], pressedTile);
                    break;
                }
                case "01111": {
                    pressedTile = findViewById(R.id.tile_black_6);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[15], pressedTile);
                    break;
                }
                case "10001": {
                    pressedTile = findViewById(R.id.tile_black_7);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[17], pressedTile);
                    break;
                }
                case "10100": {
                    pressedTile = findViewById(R.id.tile_black_8);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[20], pressedTile);
                    break;
                }
                case "10110": {
                    pressedTile = findViewById(R.id.tile_black_9);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[22], pressedTile);
                    break;
                }
                case "11001": {
                    pressedTile = findViewById(R.id.tile_black_10);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[25], pressedTile);
                    break;
                }
                case "11011": {
                    pressedTile = findViewById(R.id.tile_black_11);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[27], pressedTile);
                    break;
                }
                case "11101": {
                    pressedTile = findViewById(R.id.tile_black_12);
                    PlayNotePause(octaveSelector.ActiveOctaveArray[29], pressedTile);
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
        EditText eT = (EditText) findViewById(R.id.testValue);
        if (eT.getText().toString().equals("11111")) {
            CorrectNotePlayer correctNotePlayer = new CorrectNotePlayer(this);
            correctNotePlayer.start();
        } else {
            ReceivedBluetoothSignal = eT.getText().toString();
        }
    }

    private void PauseMethod(final Button pressedTile) {
        pressedTile.setBackgroundResource(R.drawable.tile_pressed);
        new CountDownTimer(200, 100) {
            public void onFinish() {
                pressedTile.setBackground(OriginalBackground(pressedTile.getId()));
            }

            public void onTick(long millisUntilFinished) {
            }
        }.start();
    }

    public void PlayNotePause(byte note, final Button pressedTile) {
        piagoMidiDriver.playNote(note);
        Log.i("Debugkey", "_______________Note played through PlayNotePause");
        PauseMethod(pressedTile);
    }

    public void changeInstrument(View view) {
        alertDialog.showAlertDialogInstrument(PlayPiago.this, instrumentButton, piagoMidiDriver);
    }

    public void changeSong(View view) {
        alertDialog.showAlertDialogSong(PlayPiago.this, this);
    }
    
    public void octaveLower(View view) {
        octaveSelector.OctaveDown();
    }

    public void octaveHigher(View view) {
        octaveSelector.OctaveUp();
    }

    // BLUETOOTH STUFF
    private BluetoothSocket createBluetoothSocket(BluetoothDevice device) throws IOException {
        return device.createRfcommSocketToServiceRecord(BTMODULEUUID);
        //creates secure outgoing connection with BT device using UUID
    }

    public void previewSong(View view) {
        tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
        songStarted = false;
        noteNumber = 0;
        previewSongThread = new PreviewSongThread(this, activeSongByteArray, activeSongIntArray);
        previewSongThread.start();
    }

    public void startSong(View view) {
        tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
        noteNumber = 0;
        ShowCurrentNote(activeSongByteArray);
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
            } catch (IOException e) {
            }

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
                    if (bytes != 0) {
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
            } catch (IOException e) {
            }
        }

        /* Call this from the main activity to shutdown the connection */
        public void cancel() {
            try {
                mmSocket.close();
            } catch (IOException e) {
            }
        }
    }

    public Boolean notePlayed = false;

    //Learn
    public void LearnSong(byte[] noteArray) {
        if (!noteIsShown) {
            ShowCurrentNote(noteArray);
        }
        if (!notePlayed) {
            CheckNotePlayed(noteArray);
        }
        if (noteNumber >= noteArray.length) {
            noteNumber = 0;
            songStarted = false;
        }
    }

    private void PauseMethodLearn(final Button pressedTile, final int backgGroundStatus, final byte[] array) {
        pressedTile.setBackgroundResource(backgGroundStatus);
        Log.i("Debugkey", "Key pressedTile BG set to green or red");
        new CountDownTimer(200, 100) {
            public void onFinish() {
                pressedTile.setBackground(OriginalBackground(pressedTile.getId()));
                Log.i("Debugkey", "PressedTile BG back to original");
                tileToPress.setBackground(OriginalBackground(tileToPress.getId()));
                Log.i("Debugkey", "TileToPress BG back to original");
                ShowCurrentNote(array);
            }

            public void onTick(long millisUntilFinished) {
            }
        }.start();
    }

    //Laat de noot zien die gespeeld moet worden
    public void ShowCurrentNote(byte[] noteArray) {
        Integer noteIndex = 0;
        for (int i = 0; i < octaveSelector.ActiveOctaveArray.length; i++) {
            if (noteArray[noteNumber] == octaveSelector.ActiveOctaveArray[i])
                noteIndex = i;
        }
        tileToPress = findViewById(learn.KeyArray[noteIndex]);
        tileToPress.setBackgroundResource(R.drawable.tile_to_press);
        Log.i("Debugkey", "Key tileToPress is set to Blue, key index " + noteIndex);
        noteIsShown = true;
        notePlayed = false;
        Log.i("Debugkey", "ShowCurrentNote() executed");
    }

    //Check of er een bluetoothsignaal is, zo ja check of het overeenkomt met hetgene dat nodig is
    public void CheckNotePlayed(final byte[] array) {
        if (ReceivedBluetoothSignal != null) {
            playSound(ReceivedBluetoothSignal);
            Log.i("Debugkey", "Sound played through checknoteplayed()");
            if (pressedTile == tileToPress) {
                //Is de noot correct, laat dan een groene background kort zien
                PauseMethodLearn(pressedTile, R.drawable.tile_pressed, array);
                //Log.i("BT", "Correct key");
                noteNumber++;
            } else {
                //is de noot incorrect, laat dan een rode achtergrond zien
                PauseMethodLearn(pressedTile, R.drawable.tile_pressed_fault, array);
            }
            notePlayed = true;
            Log.i("Debugkey", "ChecknotePlayed() executed");
        }
    }

    private void ModeSwitcher(boolean learnModeOn) {
        if (learnModeOn) {
            octaveLower.setVisibility(View.GONE);
            octaveHigher.setVisibility(View.GONE);
            previewButton.setVisibility(View.VISIBLE);
            startButton.setVisibility(View.VISIBLE);
        } else {
            previewButton.setVisibility(View.GONE);
            startButton.setVisibility(View.GONE);
            octaveLower.setVisibility(View.VISIBLE);
            octaveHigher.setVisibility(View.VISIBLE);
        }
    }

    public Drawable OriginalBackground(int tileResource) {
        return BGHandler.Original(tileResource, this);
    }
}