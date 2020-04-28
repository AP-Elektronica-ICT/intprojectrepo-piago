package com.interproject.piago;

import android.os.SystemClock;
import android.util.Log;

public class SignalCheckerThread extends Thread {
    PlayPiago piago;

    public SignalCheckerThread(PlayPiago piago){
        this.piago = piago;
        //this.piago.LearnSong(piago.learn.FatherJacob);
    }

    @Override
    public void run() {
        super.run();
        while(true){
            if(piago.ReceivedBluetoothSignal != null){
                Log.i("Debugkey", "BT signal=" + piago.ReceivedBluetoothSignal);

                if(piago.LearningMode) {
                    //piago.runThreadLearn();

                    piago.runOnUiThread(new Thread(new Runnable() {
                        public void run() {
                            if (piago.songStarted) {
                                piago.LearnSong(piago.activeSongByteArray);
                            } else {
                                piago.playSound(piago.ReceivedBluetoothSignal);
                                Log.i("Debugkey", "__________Sound played while songstarted was off");
                            }
                            Log.i("Debugkey", "LearnSong() executed");
                        }
                    }));
                }


                else {
                    //piago.runThreadNormal();
                    piago.runOnUiThread(new Thread(new Runnable() {
                        public void run() {
                            piago.playSound(piago.ReceivedBluetoothSignal);
                            Log.i("Debugkey", "__________Sound played in runThreadNormal");
                        }
                    }));
                }

                SystemClock.sleep(100);
            }
        }

    }
}
