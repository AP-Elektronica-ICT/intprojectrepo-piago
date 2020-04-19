package com.interproject.piago;

import java.security.Key;

public class LearnSongs {
    public byte[] FatherJacob;
    public int[] KeyArray;

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
