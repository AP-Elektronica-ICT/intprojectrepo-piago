package com.interproject.piago;

public class LearnSongs {
    public byte[] FatherJacob;
    public int[] KeyArray;
    public int[] FatherJacobTiming;
    public String[] FatherJacobInputSignals;

    public int[]Dummie1Timing;
    public int[]Dummie2Timing;
    public byte[]Dummie1Notes;
    public byte[]Dummie2Notes;

    public LearnSongs(){
        initByteArrays();
        initKeyArray();
    }

    private void initByteArrays(){
        Dummie1Notes = new byte[]{
                (byte) 0x35,
                (byte) 0x36,
                (byte) 0x37,
                (byte) 0x38,
                (byte) 0x39,
                (byte) 0x3A,
                (byte) 0x3B,
                (byte) 0x3C,
                (byte) 0x3D,
                (byte) 0x3E,
                (byte) 0x3F,
                (byte) 0x40,
                (byte) 0x41,
                (byte) 0x42,
                (byte) 0x43,
                (byte) 0x44,
                (byte) 0x45,
                (byte) 0x46,
                (byte) 0x47,
                (byte) 0x48,
                (byte) 0x49,
                (byte) 0x4A,
                (byte) 0x4B,
                (byte) 0x4C,
                (byte) 0x4D,
                (byte) 0x4E,
                (byte) 0x4F,
                (byte) 0x50,
                (byte) 0x51,
                (byte) 0x52,
                (byte) 0x53
        };
        Dummie1Timing=new int[]{
                0,
                200,
                400,
                600,
                800,
                1000,
                1200,
                1400,
                1600,
                1800,
                2000,
                2200,
                2400,
                2600,
                2800,
                3000,
                3200,
                3400,
                3600,
                3800,
                4000,
                4200,
                4400,
                4600,
                4800,
                5000,
                5200,
                5400,
                5600,
                5800,
                6000,
        };

        Dummie2Notes = new byte[]{
                (byte)65,
                (byte)68,
                (byte)71,
                (byte)65,
                (byte)68,
                (byte)71,
        };

        Dummie2Timing = new int[]{
                0,
                200,
                400,
                1000,
                1500,
                1700
        };

        FatherJacobInputSignals = new String[]{
                "01100",
                "01110",
                "10000",
                "01100",
                "01100",
                "01110",
                "10000",
                "01100",
                "10000",
                "10001",
                "10011",
                "10000",
                "10001",
                "10011",
                "10011",
                "10101",
                "10011",
                "10001",
                "10000",
                "01100",
                "10011",
                "10101",
                "10011",
                "10001",
                "10000",
                "01100",
                "01100",
                "00111",
                "01100",
                "01100",
                "00111",
                "01100",
                "01100"

        };

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
