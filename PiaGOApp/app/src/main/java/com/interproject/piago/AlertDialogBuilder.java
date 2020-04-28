package com.interproject.piago;

import android.content.Context;
import android.content.DialogInterface;
import android.widget.Button;

import androidx.appcompat.app.AlertDialog;

public class AlertDialogBuilder {

    public void showAlertDialogInstrument(Context context, final Button button, final PiagoMidiDriver midiDriver){
        AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
        alertDialog.setTitle("Select your instrument");
        String[] instruments={"Piano", "Trumpet", "Xylophone"};
        alertDialog.setSingleChoiceItems(instruments, -1, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                switch (which){
                    case 0: {
                        button.setText("Piano");
                        midiDriver.InstrumentSelection("Piano");
                        break;
                    }
                    case 1: {
                        button.setText("Trumpet");
                        midiDriver.InstrumentSelection("Trumpet");
                        break;
                    }
                    case 2: {
                        button.setText("Xylophone");
                        midiDriver.InstrumentSelection("Xylophone");
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

    public void showAlertDialogSong(Context context, final PlayPiago piago){
        AlertDialog.Builder alertDialog = new AlertDialog.Builder(context);
        alertDialog.setTitle("Select your song");
        String[] instruments={"Father Jacob", "Dummie 1", "Dummie 2"};
        alertDialog.setSingleChoiceItems(instruments, -1, new DialogInterface.OnClickListener() {
            @Override
            public void onClick(DialogInterface dialog, int which) {
                switch (which){
                    case 0: {
                        piago.activeSong.setText("Active song: Father Jacob");
                        piago.activeSongByteArray = piago.learn.FatherJacob;
                        piago.activeSongIntArray = piago.learn.FatherJacobTiming;
                        break;
                    }
                    case 1: {
                        piago.activeSong.setText("Active song: Dummie 1");
                        piago.activeSongByteArray = piago.learn.Dummie1Notes;
                        piago.activeSongIntArray = piago.learn.Dummie1Timing;
                        break;
                    }
                    case 2: {
                        piago.activeSong.setText("Active song: Dummie 2");
                        piago.activeSongByteArray = piago.learn.Dummie2Notes;
                        piago.activeSongIntArray = piago.learn.Dummie2Timing;
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
                if(piago.songStarted) {
                    piago.tileToPress.setBackground(piago.OriginalBackground(piago.tileToPress.getId()));
                    piago.noteNumber = 0;
                    piago.songStarted = false;
                    //ShowCurrentNote(activeSongByteArray);
                }
            }
        });
        AlertDialog alert = alertDialog.create();
        alert.setCanceledOnTouchOutside(false);
        alert.show();
    }
}
