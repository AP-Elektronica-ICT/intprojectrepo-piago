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
        //Log.i("BT", "Looking for signal ..");
        while(true){
            //Log.i("BT", "Looking for signal .." + piago.ReceivedBluetoothSignal);
            if(piago.ReceivedBluetoothSignal != null){
                Log.i("Debugkey", "BT signal != null, starting threads " + piago.ReceivedBluetoothSignal);
                //SystemClock.sleep(100);
                if(piago.LearningMode)
                    piago.runThreadLearn();
                else
                    piago.runThreadNormal();

                SystemClock.sleep(100);
                //piago.LearnSong(piago.learn.FatherJacob);
            }
        }

    }

    private void Debouncer(){

    }
}