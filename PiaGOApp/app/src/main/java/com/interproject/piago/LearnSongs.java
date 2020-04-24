package com.interproject.piago;

import android.widget.Button;

import java.security.Key;

public class LearnSongs {
    public byte[] FatherJacob;
    public int[] KeyArray;
    public int[] FatherJacobTiming;

    public LearnSongs(){
        initByteArrays();
        initKeyArray();
    }

    private void initByteArrays(){
        FatherJacob = new byte[]{
                (byte)0x41,
                (byte)0x43,
                (byte)0x45,
                (byte)0x41,
                (byte)0x41,
                (byte)0x43,
                (byte)0x45,
                (byte)0x41,
                (byte)0x45,
                (byte)0x46,
                (byte)0x48,
                (byte)0x45,
                (byte)0x46,
                (byte)0x48,
                (byte)0x48,
                (byte)0x4A,
                (byte)0x48,
                (byte)0x46,
                (byte)0x45,
                (byte)0x41,
                (byte)0x48,
                (byte)0x4a,
                (byte)0x48,
                (byte)0x46,
                (byte)0x45,
                (byte)0x41,
                (byte)0x41,
                (byte)0x3c,
                (byte)0x41,
                (byte)0x41,
                (byte)0x3c,
                (byte)0x41,

        };

        FatherJacobTiming = new int[]{
                0,
                600,
                1200,
                1800,
                2400,
                3000,
                3600,
                4200,
                4800,
                5400,
                6000,
                7200,
                7800,
                8400,
                9600,
                10050,
                10200,
                10500,
                10800,
                11400,
                12000,
                12450,
                12600,
                12900,
                13200,
                13800,
                14400,
                15000,
                15600,
                16800,
                17400,
                18000
        };
    }

    private void initKeyArray(){
        KeyArray = new int[]{
                R.id.tile_white_0,
                R.id.tile_black_0,
                R.id.tile_white_1,
                R.id.tile_black_1,
                R.id.tile_white_2,
                R.id.tile_black_2,
                R.id.tile_white_3,
                R.id.tile_white_4,
                R.id.tile_black_3,
                R.id.tile_white_5,
                R.id.tile_black_4,
                R.id.tile_white_6,
                R.id.tile_white_7,
                R.id.tile_black_5,
                R.id.tile_white_8,
                R.id.tile_black_6,
                R.id.tile_white_9,
                R.id.tile_black_7,
                R.id.tile_white_10,
                R.id.tile_white_11,
                R.id.tile_black_8,
                R.id.tile_white_12,
                R.id.tile_black_9,
                R.id.tile_white_13,
                R.id.tile_white_14,
                R.id.tile_black_10,
                R.id.tile_white_15,
                R.id.tile_black_11,
                R.id.tile_white_16,
                R.id.tile_black_12,
                R.id.tile_white_17,
        };


    }
}
