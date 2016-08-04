package com.example.zhongqishuai.lustationery.StoreManager;

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

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.R;
import com.example.zhongqishuai.lustationery.StoreSupervisor.SSAdjustment;
//import com.example.zhongqishuai.lustationery.departmentHead.dhRequisition;

public class StoreManagerMainActivity extends AppCompatActivity {

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
        View aadView = LayoutInflater.from(StoreManagerMainActivity.this).inflate(R.layout.approve_adjust_tab,null);
        View vrView = LayoutInflater.from(StoreManagerMainActivity.this).inflate(R.layout.view_report_tab,null);
        mTabHost.addTab(
                mTabHost.newTabSpec("Adjustment").setIndicator(aadView),
                SSAdjustment.class, null);
//        mTabHost.addTab(
//                mTabHost.newTabSpec("View").setIndicator(vrView),
//                SMReportFragment.class, null);
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