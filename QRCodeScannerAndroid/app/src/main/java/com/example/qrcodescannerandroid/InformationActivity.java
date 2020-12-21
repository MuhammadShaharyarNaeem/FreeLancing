package com.example.qrcodescannerandroid;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;

public class InformationActivity extends AppCompatActivity {
    TextView ID;
    TextView Name;
    TextView MfgDate;
    TextView ExpDate;
    TextView Batch;
    @Override
    protected void onCreate(@Nullable Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.information_layout);
        Intent i = getIntent();
        InformationModel model = (InformationModel)i.getSerializableExtra("DbObject");

        ID = findViewById(R.id.textViewID);
        Name = findViewById(R.id.textViewName);
        MfgDate = findViewById(R.id.textViewMfgDate);
        ExpDate = findViewById(R.id.textViewExpDate);
        Batch = findViewById(R.id.textViewBatch);

        ID.setText(model.getID());
        Name.setText(model.getName());
        MfgDate.setText(model.getMfgDate());
        ExpDate.setText(model.getExpDate());
        Batch.setText(model.getBatch());
    }
}
