package com.interproject.piago;

public class CorrectNotePlayer extends Thread{
    private PlayPiago playPiago;

    public CorrectNotePlayer(PlayPiago playPiago){
        this.playPiago = playPiago;
    }

    @Override
    public void run() {
        super.run();
        PlaySong(playPiago.learn.FatherJacobInputSignals);
    }

    public void PlaySong(final String[] array){
        for (int i = 0; i< array.length; i++){
            final int index = i;
            playPiago.runOnUiThread(new Runnable() {
                @Override
                public void run() {
                    playPiago.ReceivedBluetoothSignal = array[index];
                }
            });

            try
            {
                Thread.sleep(800);
            }
            catch (InterruptedException e)
            {
                e.printStackTrace();
            }
        }
    }
}
