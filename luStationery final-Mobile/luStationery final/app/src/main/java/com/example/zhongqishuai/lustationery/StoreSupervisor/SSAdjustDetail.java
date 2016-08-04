package com.example.zhongqishuai.lustationery.StoreSupervisor;

import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.R;

import java.util.List;

public class SSAdjustDetail extends AppCompatActivity {
    String ReqID ;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dh_requisition_details);
        Intent i = getIntent();
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
        StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
        ReqID = i.getStringExtra("RID");
        //ReqID = "8001";
        Button b = (Button)findViewById(R.id.buttonAccept);
        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View arg0) {
                AlertDialog.Builder builder1 = new AlertDialog.Builder(SSAdjustDetail.this);
                builder1.setMessage("Confirm This Adjustment?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                Adjustment.Approve(ReqID);
                                String s = "AdjustmentID:" + ReqID + "Is Confirmed";
                                Toast.makeText(SSAdjustDetail.this, s,
                                        Toast.LENGTH_LONG).show();
                                finish();
                            }
                        });

                builder1.setNegativeButton(
                        "No",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

                AlertDialog alert11 = builder1.create();
                alert11.show();
            }
        });
        Button b2 = (Button)findViewById(R.id.buttonReject);
        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View arg0) {
                AlertDialog.Builder builder1 = new AlertDialog.Builder(SSAdjustDetail.this);
                builder1.setMessage("Reject This Adjustment?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                Adjustment.Reject(ReqID);
                                String s = "AdjustmentID: "+ReqID+"Is Rejected";
                                Toast.makeText(SSAdjustDetail.this,s,
                                        Toast.LENGTH_LONG).show();
                                finish();
                            }
                        });

                builder1.setNegativeButton(
                        "No",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

                AlertDialog alert11 = builder1.create();
                alert11.show();
            }
        });

        new AsyncTask<String, Void, List<Adjustment>>() {
            @Override
            protected List<Adjustment> doInBackground(String... params) {
                return Adjustment.AdjustmentDetails(params[0]);
            }
            @Override
            protected void onPostExecute(List<Adjustment> result) {
                Log.i("RD",result.toString());
                AdjustDetailAdapter adapter = new AdjustDetailAdapter(SSAdjustDetail.this, R.layout.adjustdetailrow, result) ;

                ListView lv = (ListView) findViewById(R.id.listView2);
                lv.setAdapter(adapter);
                //setListAdapter(adapter);
            }
        }.execute(ReqID);
    }
}

