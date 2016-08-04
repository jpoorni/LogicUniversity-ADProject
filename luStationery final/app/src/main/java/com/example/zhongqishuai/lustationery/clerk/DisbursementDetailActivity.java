package com.example.zhongqishuai.lustationery.clerk;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.ExpandableListView;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.Disbursement;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;

public class DisbursementDetailActivity extends AppCompatActivity {

    private disbursementDetailAdapter DisAdapter;
    private ExpandableListView DisList;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_disbursement_detail);
        Intent intent = getIntent();
        String departmentId = intent.getExtras().getString("DepartmentId");
        Log.i("MMMMMMMMMMMMMMMMM", departmentId);
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
        new AsyncTask<String, Void, ArrayList<Disbursement>>() {
            @Override
            protected ArrayList<Disbursement> doInBackground(String... params) {
                Disbursement.getDisbursementListForDept(params[0]);
                return Disbursement.deptDisbursementList.get(params[0]);
            }

            @Override
            protected void onPostExecute(ArrayList<Disbursement> result) {
//                new AsyncTask<ArrayList<Disbursement>, Void, ArrayList<Disbursement>>() {
//                    @Override
//                    protected ArrayList<Disbursement> doInBackground(ArrayList<Disbursement>... params) {
//                        for (int i = 0; i < params[0].size(); i++) {
//                            Disbursement.getDisDetailInfo(Integer.parseInt(params[0].get(i).get("disbursementId").toString()));
//                        }
//                        return params[0];
//                    }
//
//                    @Override
//                    protected void onPostExecute(ArrayList<Disbursement> result) {
                        DisList = (ExpandableListView) findViewById(R.id.dis_list);
                        DisAdapter = new disbursementDetailAdapter(DisbursementDetailActivity.this, result);
                        DisList.setAdapter(DisAdapter);
//                    }
//                }.execute(result);
            }
        }.execute(departmentId);
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu, menu);
        getMenuInflater().inflate(R.menu.shopping_cart,menu);

        return true;
    }
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case R.id.Logout:
                Intent intent = new Intent(this, Login.class);
                intent.putExtra("finish", true); // if you are checking for this in your other Activities
                intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP |
                        Intent.FLAG_ACTIVITY_CLEAR_TASK |
                        Intent.FLAG_ACTIVITY_NEW_TASK);
                SharedPreferences preferences = getSharedPreferences("loginPrefs", Context.MODE_PRIVATE);
                SharedPreferences.Editor editor = preferences.edit();
                editor.clear();
                editor.commit();
                startActivity(intent);
                finish();
                break;
            case R.id.ShoppingCart:
                Intent i = new Intent(DisbursementDetailActivity.this, purchase_order_shoppingcart.class);
                startActivity(i);
        }
        return true;
    }
}
