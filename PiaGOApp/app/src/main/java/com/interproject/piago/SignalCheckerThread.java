package com.interproject.piago;

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
        Log.i("BT", "Looking for signal ..");
        while(true){
            Log.i("BT", "Looking for signal .." + piago.ReceivedBluetoothSignal);
            if(piago.ReceivedBluetoothSignal != null){
                if(piago.LearningMode)
                    piago.runThreadLearn();
                else
                    piago.runThreadNormal();
                //piago.LearnSong(piago.learn.FatherJacob);
            }
        }

    }
}
