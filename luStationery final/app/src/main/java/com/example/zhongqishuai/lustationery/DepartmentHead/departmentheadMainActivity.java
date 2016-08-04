package com.example.zhongqishuai.lustationery.DepartmentHead;

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
import com.example.zhongqishuai.lustationery.Representative.ViewAllReqFragment;
import com.example.zhongqishuai.lustationery.clerk.clerk_Main;

public class departmentheadMainActivity extends AppCompatActivity {
    private FragmentTabHost mTabHost;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_departmenthead_main);
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
        mTabHost = (FragmentTabHost) findViewById(android.R.id.tabhost);
        mTabHost.setup(this, getSupportFragmentManager(), android.R.id.tabcontent);
        View aprView = LayoutInflater.from(departmentheadMainActivity.this).inflate(R.layout.approve_re_tab,null);
        View vrqView = LayoutInflater.from(departmentheadMainActivity.this).inflate(R.layout.view_re_tab_for_head,null);
        View deleView = LayoutInflater.from(departmentheadMainActivity.this).inflate(R.layout.delegation_tab,null);
        View cpView = LayoutInflater.from(departmentheadMainActivity.this).inflate(R.layout.collection_point_tab,null);
        mTabHost.addTab(
                mTabHost.newTabSpec("RequisitionDepHead").setIndicator(aprView),
                dhRequisition.class, null);
        mTabHost.addTab(
                mTabHost.newTabSpec("View").setIndicator(vrqView),
                ViewAllReqFragment.class, null);
        mTabHost.addTab(
                mTabHost.newTabSpec("Delagation").setIndicator(deleView),
                dhDelegate.class, null);

        mTabHost.addTab(
                mTabHost.newTabSpec("Collection Point").setIndicator(cpView),
                CollectionPoints.class, null);

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
