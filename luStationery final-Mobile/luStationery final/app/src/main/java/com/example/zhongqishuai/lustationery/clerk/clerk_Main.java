package com.example.zhongqishuai.lustationery.clerk;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.database.ContentObserver;
import android.database.Cursor;
import android.net.Uri;
import android.os.Bundle;
import android.os.Handler;
import android.support.v4.app.FragmentTabHost;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.ImageView;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

public class clerk_Main extends AppCompatActivity {
    private FragmentTabHost mTabHost;
    ImageView cart;
//    Handler handler;
//    String emailaddress="alizee521070@gmail.com";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_clerk__main);
//        cart = (ImageView) findViewById(R.id.imageButtonCart);
//
//        cart.setOnClickListener(new View.OnClickListener() {
//            @Override
//            public void onClick(View v) {
//                List<ShoppingCart> cart1 = ShoppingCart.getCart();
////                Log.i("items in cart *****", Integer.toString(cart1.size()));
////                if (cart1 != null) {
//                Intent i = new Intent(clerk_Main.this, purchase_order_shoppingcart.class);
//                startActivity(i);
////                }
//            }
//        });
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
        mTabHost = (FragmentTabHost) findViewById(android.R.id.tabhost);
        mTabHost.setup(this, getSupportFragmentManager(), android.R.id.tabcontent);
        View reView = LayoutInflater.from(clerk_Main.this).inflate(R.layout.retrieval_tab,null);
        View diView = LayoutInflater.from(clerk_Main.this).inflate(R.layout.disbursement_tab, null);
        View cpoView = LayoutInflater.from(clerk_Main.this).inflate(R.layout.create_po_tab, null);
        View rpoView = LayoutInflater.from(clerk_Main.this).inflate(R.layout.receive_po_tab, null);
        mTabHost.addTab(
                mTabHost.newTabSpec("Retrieval").setIndicator(reView),
                retrieval_Main.class, null);

        mTabHost.addTab(
                mTabHost.newTabSpec("Disbursement").setIndicator(diView),
                disbursement_Main.class, null);
        mTabHost.addTab(
                mTabHost.newTabSpec("Purchase Order").setIndicator(cpoView),
                purchaseOrder_Main.class, null);
        mTabHost.addTab(
                mTabHost.newTabSpec("Receive").setIndicator(rpoView),
                Receive_PO_Main.class, null);
//        getContentResolver().
//                registerContentObserver(
//                        Uri.parse("content://gmail- ls"),
//                        true,
//                        new MyContentObserver(handler));

    }
//    class MyContentObserver extends ContentObserver {
//        public MyContentObserver(Handler h) {
//            super(h);
//        }
//
//        @Override
//        public boolean deliverSelfNotifications() {
//            return true;
//        }
//
//        @Override
//        public void onChange(boolean selfChange) {
//            super.onChange(selfChange);
//            Cursor conversations =getContentResolver().query(Uri.parse("content://gmail-ls/conversations/" + emailaddress));
//            Cursor messages = _contetResolver.query(Uri.parse("content://gmail-ls/conversations/" + YourEmailAddress + "/" + String.valueOf(conversationId) + "/messages"), null, null, null, null);
//        }
//    }
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
                Intent i = new Intent(clerk_Main.this, purchase_order_shoppingcart.class);
                startActivity(i);
        }
        return true;
    }
}
