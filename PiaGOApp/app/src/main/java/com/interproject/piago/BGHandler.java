package com.interproject.piago;

import android.graphics.drawable.Drawable;

public class BGHandler {


    public static Drawable Original(int tileResource, PlayPiago piago){
        int i = 0;
        for(int j = 0; j < piago.learn.KeyArray.length; j++){
            if(piago.learn.KeyArray[j] == tileResource) {
                i = j;
            }
        }
        switch (i){
            case 0:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 1:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 2:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 3:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 4:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 5:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 6:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 7:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 8:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 9:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 10:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 11:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 12:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 13:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 14:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 15:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 16:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 17:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 18:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 19:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 20:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 21:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 22:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 23:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 24:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 25:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 26:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 27:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 28:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            case 29:
                return piago.getResources().getDrawable(R.drawable.tile_black);
            case 30:
                return piago.getResources().getDrawable(R.drawable.tile_white);
            default:
                return piago.getResources().getDrawable(R.drawable.tile_white);
        }
    }
}

