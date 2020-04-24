package com.interproject.piago;

import android.os.CountDownTimer;
import android.util.Log;
import android.widget.Button;

public class PreviewSongThread extends Thread {
    PlayPiago piago;
    byte[] arrayNote;
    int[] timing;
    Button previewTile;

    public PreviewSongThread(PlayPiago piago, byte[] arrayNote, int[] timing){
        this.piago = piago;
        this.arrayNote = arrayNote;
        this.timing = timing;
        //this.piago.LearnSong(piago.learn.FatherJacob);
    }

    @Override
    public void run() {
        //super.run();
        int runIndex = 0;
        for(int i = 0; i < arrayNote.length-1; i++){
            Log.i("Debugkey", "Runindex: "+runIndex);
            runIndex++;
            final int j = i;
            Playnote(j);
            BackgroundChanger(j);
            Log.i("Debugkey", "runThreadPreview with note "+arrayNote[i]);
            try{
                Thread.sleep((timing[i+1]-timing[i]));
            }catch (InterruptedException e){
                Thread.currentThread().interrupt();
            }
        }


        piago.piagoMidiDriver.playNote(arrayNote[arrayNote.length-1]);
        BackgroundChanger(arrayNote.length-1);
    }

    private void Playnote(final int j){
        piago.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                piago.piagoMidiDriver.playNote(arrayNote[j]);
                Log.i("Debugkey", "Sound played " + j);
            }
        });
    }

    private void BackgroundChanger(final int j){
        piago.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                int index = 0;
                for(int i = 0; i < piago.octaveSelector.ActiveOctaveArray.length; i++) {
                    if (arrayNote[j] == piago.octaveSelector.ActiveOctaveArray[i]) {
                        index = i;
                        //break;
                    }
                }
                previewTile = piago.findViewById(piago.learn.KeyArray[index]);
                previewTile.setBackgroundResource(R.drawable.tile_to_press);
                Log.i("Debugkey", "Tile preview "+index);

                new CountDownTimer(120, 100) {
                    public void onFinish() {
                        // When timer is finished
                        // Execute your code here
                        //pressedTile.setBackgroundResource(tileDrawable);
                        previewTile.setBackground(piago.OriginalBackground(previewTile.getId()));
                        Log.i("Debugkey", "Tile reset ");
                    }

                    public void onTick(long millisUntilFinished) {
                        // millisUntilFinished    The amount of time until finished.
                    }
                }.start();

            }
        });
    }


}
