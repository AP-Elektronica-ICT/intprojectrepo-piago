package com.interproject.piago;

import android.os.AsyncTask;

public class SignalChecker extends AsyncTask {
    public PlayPiago piago;

    public SignalChecker(PlayPiago piago){
        this.piago = piago;
    }
    @Override
    protected Object doInBackground(Object[] objects) {
        while(piago.ReceivedBluetoothSignal == null)
           ;
        return null;
    }

    @Override
    protected void onPostExecute(Object o) {
        piago.LearnSong(piago.learn.FatherJacob);
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
        piago.LearnSong(piago.learn.FatherJacob);
    }
}
