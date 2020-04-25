package com.interproject.piago;

import android.widget.Toast;

public class OctaveSelector {
    private byte[] octaveF5_B7;
    private byte[] octaveF4_B6;
    private byte[] octaveF3_B5;
    private byte[] octaveF2_B4;
    private byte[] octaveF1_B3;

    private byte[][] OctaveArray;

    private int ActiveOctaveInt;

    public byte[] ActiveOctaveArray;

    public OctaveSelector(){
        initOctaveArrays();
        ActiveOctaveInt = 2;
        ActiveOctaveArray = OctaveArray[ActiveOctaveInt];
    }

    public void OctaveUp(){
        if(ActiveOctaveInt == 4){
            ActiveOctaveInt = 4;
        }else{
            ActiveOctaveInt++;
        }
        ArrayUpdate();
    }

    public void OctaveDown(){
        if(ActiveOctaveInt == 0){
            ActiveOctaveInt = 0;
        }else{
            ActiveOctaveInt--;
        }
        ArrayUpdate();
    }

    private void ArrayUpdate(){
        ActiveOctaveArray = OctaveArray[ActiveOctaveInt];
    }

    private void initOctaveArrays(){
        initF1_B3();
        initF2_B4();
        initF3_B5();
        initF4_B6();
        initF5_B7();

        OctaveArray = new byte[][]{octaveF1_B3, octaveF2_B4,octaveF3_B5,octaveF4_B6,octaveF5_B7};
        ActiveOctaveArray = new byte[31];
    }

    private void initF1_B3(){
        octaveF1_B3 = new byte[]{
                    (byte) 0x1D,
                    (byte) 0x1E,
                    (byte) 0x1F,
                    (byte) 0x20,
                    (byte) 0x21,
                    (byte) 0x22,
                    (byte) 0x23,
                    (byte) 0x24,
                    (byte) 0x25,
                    (byte) 0x26,
                    (byte) 0x27,
                    (byte) 0x28,
                    (byte) 0x29,
                    (byte) 0x2A,
                    (byte) 0x2B,
                    (byte) 0x2C,
                    (byte) 0x2D,
                    (byte) 0x2E,
                    (byte) 0x2F,
                    (byte) 0x30,
                    (byte) 0x31,
                    (byte) 0x32,
                    (byte) 0x33,
                    (byte) 0x34,
                    (byte) 0x35,
                    (byte) 0x36,
                    (byte) 0x37,
                    (byte) 0x38,
                    (byte) 0x39,
                    (byte) 0x3A,
                    (byte) 0x3B
        };
    }
    private void initF2_B4(){
        octaveF2_B4 = new byte[]{
                (byte) 0x2A,
                (byte) 0x2B,
                (byte) 0x2C,
                (byte) 0x2D,
                (byte) 0x2E,
                (byte) 0x2F,
                (byte) 0x30,
                (byte) 0x31,
                (byte) 0x32,
                (byte) 0x33,
                (byte) 0x34,
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
        };

    }
    private void initF3_B5(){
        octaveF3_B5 = new byte[]{
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

    }
    private void initF4_B6(){
        octaveF4_B6 = new byte[]{
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
                (byte) 0x53,
                (byte) 0x54,
                (byte) 0x55,
                (byte) 0x56,
                (byte) 0x57,
                (byte) 0x58,
                (byte) 0x59,
                (byte) 0x5A,
                (byte) 0x5B,
                (byte) 0x5C,
                (byte) 0x5D,
                (byte) 0x5E,
                (byte) 0x5F
        };

    }
    private void initF5_B7(){
        octaveF5_B7 = new byte[]{
                (byte) 0x4D,
                (byte) 0x4E,
                (byte) 0x4F,
                (byte) 0x50,
                (byte) 0x51,
                (byte) 0x52,
                (byte) 0x53,
                (byte) 0x54,
                (byte) 0x55,
                (byte) 0x56,
                (byte) 0x57,
                (byte) 0x58,
                (byte) 0x59,
                (byte) 0x5A,
                (byte) 0x5B,
                (byte) 0x5C,
                (byte) 0x5D,
                (byte) 0x5E,
                (byte) 0x5F,
                (byte) 0x60,
                (byte) 0x61,
                (byte) 0x62,
                (byte) 0x63,
                (byte) 0x64,
                (byte) 0x65,
                (byte) 0x66,
                (byte) 0x67,
                (byte) 0x68,
                (byte) 0x69,
                (byte) 0x6A,
                (byte) 0x6B
        };
    }

    public void SetOctaveLearn(){
        ActiveOctaveArray = OctaveArray[2];
    }
}
