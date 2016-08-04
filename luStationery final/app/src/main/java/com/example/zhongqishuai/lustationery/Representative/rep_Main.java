package com.example.zhongqishuai.lustationery.Representative;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.support.v4.app.FragmentTabHost;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;

import com.example.zhongqishuai.lustationery.Employee.ListItem;
import com.example.zhongqishuai.lustationery.Employee.createReqFragment;
import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;


public class rep_Main extends AppCompatActivity {
    private FragmentTabHost RepTabHost;

    ImageView cart;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_rep__main);

        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
//        cart = (ImageView) findViewById(R.id.imageButtonCart);
//
//        cart.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                List<ShoppingCart> cart1 = ShoppingCart.getCart();
//                Log.i("items in cart *****", Integer.toString(cart1.size()));
//                if (cart1 != null) {
//                    Intent i = new Intent(rep_Main .this, ListItem.class);
//                    startActivity(i);
//                }
//            }
//        });

        RepTabHost = (FragmentTabHost) findViewById(android.R.id.tabhost);
        RepTabHost.setup(this, getSupportFragmentManager(), android.R.id.tabcontent);

//        RepTabHost.addTab(
//                RepTabHost.newTabSpec("Request").setIndicator("Request", null),
//                createReqFragment.class, null);
//
//        RepTabHost.addTab(
//                RepTabHost.newTabSpec("View").setIndicator("View", null),
//                ViewReqFragment.class, null);
//
//        RepTabHost.addTab(
//                RepTabHost.newTabSpec("Disbursement").setIndicator("Disbursement", null),
//                DisbursementFragment.class, null);
        View crqView = LayoutInflater.from(rep_Main.this).inflate(R.layout.create_rq_tab,null);
        View vrqView = LayoutInflater.from(rep_Main.this).inflate(R.layout.view_rq_for_em,null);
        View disView = LayoutInflater.from(rep_Main.this).inflate(R.layout.disbursement_tab,null);
        RepTabHost.addTab(
                RepTabHost.newTabSpec("Request").setIndicator(crqView),
                createReqFragment.class,null);


        RepTabHost.addTab(
//                empTabHost.newTabSpec("View").setIndicator("View",null),
//                ViewReqFragment.class,null);
                RepTabHost.newTabSpec("View").setIndicator(vrqView),
                ViewAllReqFragment.class,null);

        RepTabHost.addTab(
                RepTabHost.newTabSpec("Disbursement").setIndicator(disView),
                DisbursementFragment.class,null);

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
                Intent i = new Intent(rep_Main.this, ListItem.class);
                startActivity(i);
                break;
        }
        return true;
    }
}
