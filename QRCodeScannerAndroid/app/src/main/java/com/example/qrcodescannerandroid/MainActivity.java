package com.example.qrcodescannerandroid;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.Manifest;
import android.content.Intent;
import android.os.Bundle;
import android.os.StrictMode;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.budiyev.android.codescanner.CodeScanner;
import com.budiyev.android.codescanner.CodeScannerView;
import com.budiyev.android.codescanner.DecodeCallback;
import com.google.zxing.Result;
import com.karumi.dexter.Dexter;
import com.karumi.dexter.PermissionToken;
import com.karumi.dexter.listener.PermissionDeniedResponse;
import com.karumi.dexter.listener.PermissionGrantedResponse;
import com.karumi.dexter.listener.PermissionRequest;
import com.karumi.dexter.listener.single.PermissionListener;

import java.sql.Connection;
import java.util.Objects;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class MainActivity extends AppCompatActivity {

    CodeScanner codeScanner;
    CodeScannerView codeScannerView;
    TextView ErrorMessage;
    String ipAddress = "192.168.10.5";
    String port = "5780";
    String Classes = "net.sourceforge.jtds.jdbc.Driver";
    String database = "PharmaMS";
    String username = "sa";
    String password = "123";
    String url = "jdbc:jtds:sqlserver://" + ipAddress + ":" + port + "/" + database;
    private Connection connection = null;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        codeScannerView = findViewById(R.id.scannerView);
        codeScanner = new CodeScanner(this, codeScannerView);
        ErrorMessage = findViewById(R.id.ErrorMessage);

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        try {
            Class.forName(Classes);
            connection = DriverManager.getConnection(url, username, password);

        } catch (ClassNotFoundException e) {
            e.printStackTrace();
            ErrorMessage.setText("Could not connect to DB");
        } catch (SQLException e) {
            e.printStackTrace();
            ErrorMessage.setText("Could not connect to DB");
        }


        try {
            codeScanner.setDecodeCallback(
                    new DecodeCallback() {
                        @Override
                        public void onDecoded(@NonNull Result result) {

                            runOnUiThread(new Runnable() {
                                public void run() {
                                    if (connection != null) {
                                        Statement statement = null;
                                        try {
                                            statement = connection.createStatement();
                                            ResultSet resultSet = statement.executeQuery("select top 1 * from medicine where qrcode = '" + result + "'");
                                            if (resultSet != null && resultSet.next()) {
                                                InformationModel model = new InformationModel();
                                                model.ID = resultSet.getString("ID");
                                                model.Name = resultSet.getString("Name");
                                                model.MfgDate = resultSet.getString("MfgDate");
                                                model.ExpDate = resultSet.getString("ExpiryDate");
                                                model.Batch = resultSet.getString("BatchNo");
                                                Intent i = new Intent(MainActivity.this, InformationActivity.class);
                                                i.putExtra("DbObject",model);
                                                startActivity(i);

                                            } else {
                                                ErrorMessage.setText("No Record in Database with this QR Code");
                                            }
                                        } catch (SQLException e) {
                                            e.printStackTrace();
                                            ErrorMessage.setText("An Exception occured while retrieving records from DB: " + e.getMessage());
                                        }
                                    } else {
                                        ErrorMessage.setText("Connection is null");
                                    }
                                }

                            });
                        }
                    }
            );
        } catch (Exception e) {
            ErrorMessage.setText(e.getMessage());
        }
    }

    public void OnScanClick(View view) {
        codeScanner.startPreview();
    }

    @Override
    protected void onResume() {
        super.onResume();
        requestForCamera();
        requestForInternet();
    }

    public void requestForInternet() {
        Dexter.withActivity(this).withPermission(Manifest.permission.INTERNET).withListener(new PermissionListener() {
            @Override
            public void onPermissionGranted(PermissionGrantedResponse permissionGrantedResponse) {
                codeScanner.startPreview();
            }

            @Override
            public void onPermissionDenied(PermissionDeniedResponse permissionDeniedResponse) {
                Toast.makeText(MainActivity.this, "Internet Permission is Required.", Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onPermissionRationaleShouldBeShown(PermissionRequest permissionRequest, PermissionToken permissionToken) {
                permissionToken.continuePermissionRequest();
            }
        }).check();
    }

    public void requestForCamera() {
        Dexter.withActivity(this).withPermission(Manifest.permission.CAMERA).withListener(new PermissionListener() {

            @Override
            public void onPermissionGranted(PermissionGrantedResponse permissionGrantedResponse) {
                codeScanner.startPreview();

            }

            @Override
            public void onPermissionDenied(PermissionDeniedResponse permissionDeniedResponse) {
                Toast.makeText(MainActivity.this, "Camera Permission is Required.", Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onPermissionRationaleShouldBeShown(PermissionRequest permissionRequest, PermissionToken permissionToken) {
                permissionToken.continuePermissionRequest();
            }
        }).check();
    }
}