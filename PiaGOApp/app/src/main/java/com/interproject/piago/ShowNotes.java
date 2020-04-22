package com.interproject.piago;

import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.widget.Button;

import java.lang.ref.WeakReference;

public class ShowNotes extends AsyncTask<Void, Void, Void> {

    private Button tileToPress;
    private Drawable OriginalBG;
    ShowNotes(Button tileToPress){
        this.tileToPress = tileToPress;
    }

    @Override
    protected Void doInBackground(Void... voids) {
        try{
            Thread.sleep(1000);
        }catch (InterruptedException e){
            Thread.currentThread().interrupt();
        }
        return null;
    }

    @Override
    protected void onPreExecute() {
        super.onPreExecute();
        OriginalBG = tileToPress.getBackground();
        tileToPress.setBackgroundResource(R.drawable.tile_black);
    }

    @Override
    protected void onPostExecute(Void aVoid) {
        tileToPress.setBackground(OriginalBG);
    }
}
