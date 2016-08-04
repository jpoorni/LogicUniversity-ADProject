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

public class SSPurchaseDetail extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
        setContentView(R.layout.activity_dh_requisition_details);
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
        Intent i = getIntent();
        final String ReqID = i.getStringExtra("RID");
        Button b = (Button)findViewById(R.id.buttonAccept);
        b.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View arg0) {
                AlertDialog.Builder builder1 = new AlertDialog.Builder(SSPurchaseDetail.this);
                builder1.setMessage("Confirm This Purchasement?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                Purchasement.ChangeStatus(ReqID, "approved");
                                String s = "PO Number :" + ReqID + " Is Confirmed";
                                Toast.makeText(SSPurchaseDetail.this, s,
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
                AlertDialog.Builder builder1 = new AlertDialog.Builder(SSPurchaseDetail.this);
                builder1.setMessage("Reject This Purchasemnet?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                Purchasement.ChangeStatus(ReqID, "rejected");
                                String s = "PO Number: " + ReqID + " Is Rejected";
                                Toast.makeText(SSPurchaseDetail.this, s,
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

                new AsyncTask<String, Void, List<Purchasement>>() {
                    @Override
                    protected List<Purchasement> doInBackground(String... params) {
                        return Purchasement.PurchasementDetails(params[0]);
                    }

                    @Override
                    protected void onPostExecute(List<Purchasement> result) {
                        Log.i("RD", result.toString());
                        PurchaseDetailAdapter adapter = new PurchaseDetailAdapter(SSPurchaseDetail.this, R.layout.porowdetail, result);

                        ListView lv = (ListView) findViewById(R.id.listView2);
                        lv.setAdapter(adapter);
                        //setListAdapter(adapter);
                    }
                }.execute(ReqID);
            }
        }
