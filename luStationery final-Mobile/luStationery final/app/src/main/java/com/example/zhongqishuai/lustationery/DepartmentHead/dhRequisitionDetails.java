package com.example.zhongqishuai.lustationery.DepartmentHead;

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
import android.widget.SimpleAdapter;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Model.RequisitionDepHead;
import com.example.zhongqishuai.lustationery.Model.RequisitionDetailsDepHead;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

public class dhRequisitionDetails extends AppCompatActivity {

    String ReqID;
    ListView lv;
    SimpleAdapter adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_dh_requisition_details);
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
        Intent i = getIntent();
        ReqID = i.getStringExtra("RID");
        new AsyncTask<Void, Void, List<RequisitionDetailsDepHead>>() {
            @Override
            protected List<RequisitionDetailsDepHead> doInBackground(Void... params) {
                return RequisitionDetailsDepHead.RequisitionListById(ReqID);
            }
            @Override
            protected void onPostExecute(List<RequisitionDetailsDepHead> result) {
                Log.i("RD",result.toString());
                adapter = new SimpleAdapter(getApplicationContext(), result,
                        R.layout.requisitiondetailsrow,
                        new String[]{"itemDescription","qtyNeeded"},
                        new int[]{R.id.textViewItemDesc, R.id.textViewReqQty});
                lv = (ListView) findViewById(R.id.listView2);
//                lv.invalidateViews();
                lv.setAdapter(adapter);
                //setListAdapter(adapter);
            }
        }.execute();


        final Button buttonAccept = (Button)  findViewById(R.id.buttonAccept);
        buttonAccept.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);

            Log.i("Confirm clicked", buttonAccept.toString());
            //***Status 2001 - to approve requisition made***/
            final RequisitionDepHead r1 = new RequisitionDepHead(ReqID,"","","","2001");
            Log.i("Objects confirm", r1.toString());
                AlertDialog.Builder builder1 = new AlertDialog.Builder(dhRequisitionDetails.this);
                builder1.setMessage("Confirm this requisition ?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                RequisitionDepHead.approveRequisition(r1);
                                String S = "RequistionID : " + ReqID + " Is Approved";
                                Toast.makeText(dhRequisitionDetails.this, S, Toast.LENGTH_LONG).show();
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

        final Button buttonReject = (Button)  findViewById(R.id.buttonReject);
        buttonReject.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
//                Log.i("Reject clicked", buttonReject.toString());
                StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
                //***Status 2002 - to reject requisition made***/
                final RequisitionDepHead r1 = new RequisitionDepHead(ReqID,"","","","2002");

                AlertDialog.Builder builder1 = new AlertDialog.Builder(dhRequisitionDetails.this);
                builder1.setMessage("Confirm this requisition ?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                RequisitionDepHead.approveRequisition(r1);
//                Log.i("Objects Reject", r1.toString());
                                String S = "RequistionID : " + ReqID + " Is Rejected";
                                Toast.makeText(dhRequisitionDetails.this,S,Toast.LENGTH_LONG).show();
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

    }
}
