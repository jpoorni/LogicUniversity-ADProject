package com.example.zhongqishuai.lustationery.StoreSupervisor;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.Bundle;
import android.support.v4.app.FragmentTabHost;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;

import com.example.zhongqishuai.lustationery.Employee.ViewReqFragment;
import com.example.zhongqishuai.lustationery.Employee.createReqFragment;
import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.R;
import com.example.zhongqishuai.lustationery.Representative.DisbursementFragment;

public class StoreSupervisorMainActivity extends AppCompatActivity {
    private FragmentTabHost mTabHost;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_store_supervisor_main);
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
        mTabHost = (FragmentTabHost) findViewById(android.R.id.tabhost);
        mTabHost.setup(this, getSupportFragmentManager(), android.R.id.tabcontent);
//        mTabHost.addTab(
//                mTabHost.newTabSpec("Adjustment").setIndicator("Adjustment", null),
//                SSAdjustment.class, null);
//        mTabHost.addTab(
//                mTabHost.newTabSpec("Purchasement").setIndicator("Purchasement", null),
//                SSPurchasement.class, null);

        View aadView = LayoutInflater.from(StoreSupervisorMainActivity.this).inflate(R.layout.approve_adjust_tab,null);
        View apoView = LayoutInflater.from(StoreSupervisorMainActivity.this).inflate(R.layout.approve_po_tab,null);
        mTabHost.addTab(
                mTabHost.newTabSpec("Adjustment Approval").setIndicator(aadView),
                SSAdjustment.class, null);

        mTabHost.addTab(
                mTabHost.newTabSpec("Purchase Order Approval").setIndicator(apoView),
                SSPurchasement.class, null);



//        Intent i =getIntent();
//        if (i.hasExtra("back")) {
//            String s = i.getStringExtra("back");
//            Log.e("hahahahha", s);
//            if (s != null) {
//                if (s.equals("adjust")) {
//                    final String TAG = "DETAILS_FRAG";
//                    FragmentManager fm = getSupportFragmentManager();
//                    FragmentTransaction trans = fm.beginTransaction();
//
//                    Fragment fragment = new SSAdjustment();
//                    if (fm.findFragmentByTag(TAG) == null)
//                        // fragment not found -- to be added
//                        trans.add(android.R.id.tabcontent, fragment, TAG);
//                    else
//                        // fragment found -- to be replaced
//                        trans.replace(android.R.id.tabcontent, fragment, TAG);
//                    trans.commit();
//                } else {
//                    final String TAG = "DETAILS_FRAG";
//                    FragmentManager fm = getSupportFragmentManager();
//                    FragmentTransaction trans = fm.beginTransaction();
//
//                    Fragment fragment = new SSPurchasement();
//                    if (fm.findFragmentByTag(TAG) == null)
//                        // fragment not found -- to be added
//                        trans.add(android.R.id.tabcontent, fragment, TAG);
//                    else
//                        // fragment found -- to be replaced
//                        trans.replace(android.R.id.tabcontent, fragment, TAG);
//                    trans.commit();
//                }
//            }
//        }
//        else{
////              mTabHost.addTab(
////                mTabHost.newTabSpec("Adjustment").setIndicator("Adjustment", null),
////                SSAdjustment.class, null);
////            mTabHost.addTab(
////                    mTabHost.newTabSpec("Purchasement").setIndicator("Purchasement", null),
////                    SSPurchasement.class, null);
//            Log.e("aaaaaa","bbbb");
//        }
    }
    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.menu, menu);
        return true;
    }
    public boolean onOptionsItemSelected(MenuItem item) {
        Intent intent = new Intent(this, Login.class);
        intent.putExtra("finish", true); // if you are checking for this in your other Activities
        intent.setFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP |
                Intent.FLAG_ACTIVITY_CLEAR_TASK |
                Intent.FLAG_ACTIVITY_NEW_TASK);
        SharedPreferences preferences=getSharedPreferences("loginPrefs", Context.MODE_PRIVATE);
        SharedPreferences.Editor editor = preferences.edit();
        editor.clear();
        editor.commit();
        startActivity(intent);
        finish();
        return true;
    }
}
