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

                if(piago.LearningMode)
                    piago.runThreadLearn();
                else
                    piago.runThreadNormal();

                SystemClock.sleep(100);
                //piago.LearnSong(piago.learn.FatherJacob);
            }
        }

    }
}
