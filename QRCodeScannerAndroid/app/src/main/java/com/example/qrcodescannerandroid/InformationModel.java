package com.example.qrcodescannerandroid;

import java.io.Serializable;

public class InformationModel implements Serializable {
    public String getID() {
        return ID;
    }

    public String ID;

    public String getName() {
        return Name;
    }

    public String Name;

    public String getMfgDate() {
        return MfgDate;
    }

    public String MfgDate;

    public String getExpDate() {
        return ExpDate;
    }

    public String ExpDate;

    public String getBatch() {
        return Batch;
    }

    public String Batch;
}
