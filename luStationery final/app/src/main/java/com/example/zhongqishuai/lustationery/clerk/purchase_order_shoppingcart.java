package com.example.zhongqishuai.lustationery.clerk;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.SharedPreferences;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.Spinner;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.PurchaseOrder;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.Model.Supplier;
import com.example.zhongqishuai.lustationery.R;
import com.example.zhongqishuai.lustationery.ShoppingCartSqLite.ShoppingCartDbAdapter;

public class purchase_order_shoppingcart extends AppCompatActivity implements AdapterView.OnItemSelectedListener,View.OnClickListener{
    final Context context = this;
//    List<ShoppingCart> cart1;
//    ListView list;
    String[] suppliers;
    ArrayAdapter<String> dataAdapter;
    Button btnConfirm;
    String supplierCode;
    String supplierName;
    ShoppingCartDbAdapter db;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_purchase_order_shoppingcart);
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
//        purchase_order_shoppingcart_frag.cart1=new Vector<ShoppingCart>();
        new AsyncTask<Void, Void,String[]>()
        {
            @Override
            protected String[] doInBackground(Void... params) {
                return Supplier.getSupplier();
            }
            @Override
            protected void onPostExecute(String[] spliers) {
                suppliers = spliers;
                Log.i("AAAAAAAAAAAAA", spliers[0]);


//        db=new ShoppingCartDbAdapter(this);
//        db.open();
////        cart1 = ShoppingCart.getCart();
//        cart1=new Vector<ShoppingCart>();
//        if (cart1.size()==0) {
                Spinner spinner = (Spinner) findViewById(R.id.supplier_spinner);

                // Spinner click listener
                spinner.setOnItemSelectedListener(purchase_order_shoppingcart.this);

                // Creating adapter for spinner
                dataAdapter = new ArrayAdapter<String>(purchase_order_shoppingcart.this, android.R.layout.simple_spinner_item, suppliers);

                // Drop down layout style - list view with radio button
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

                // attaching data adapter to spinner
                spinner.setAdapter(dataAdapter);

                btnConfirm = (Button) findViewById(R.id.po_confirm_button);
//                    else
//                    {
                        btnConfirm.setEnabled(true);
                        btnConfirm.setOnClickListener(purchase_order_shoppingcart.this);
//                    }
//               else {
//
//                }
            }
        }.execute();
    }
    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        // On selecting a spinner item
        supplierName= parent.getItemAtPosition(position).toString();
        displaycart(supplierName);
//        Log.i("see supplierCode!!!!!",supplierCode);
//        if (purchase_order_shoppingcart_frag.cart1==null)
//        {
////            Toast.makeText(getApplicationContext(), "You haven't Added Anything", Toast.LENGTH_SHORT).show();
//            btnConfirm.setEnabled(false);
//        }
//        else
//        {
//            btnConfirm.setEnabled(true);
//        }
        // Showing selected spinner item

    }
    public void onNothingSelected(AdapterView<?> arg0) {
        // TODO Auto-generated method stub


    }
    protected void displaycart(String suppliername){
        Bundle args1 = new Bundle();
        Log.i("qqqqqqqqqqqqqq", "check");
        args1.putString("supplier", suppliername);
        FrameLayout layout=(FrameLayout)findViewById(R.id.carts);
        layout.removeAllViews();
        android.app.Fragment f1 = new purchase_order_shoppingcart_frag();
        f1.setArguments(args1);
        getFragmentManager().beginTransaction()
                .add(R.id.carts, f1)
                .commit();
    }
    @Override
    public void onClick(final View v) {
        Log.i("see the cart",Integer.toString(purchase_order_shoppingcart_frag.cart1.size()));
        if (purchase_order_shoppingcart_frag.cart1.size()==0)
        {
            Toast.makeText(getApplicationContext(), "You haven't Added Anything", Toast.LENGTH_SHORT).show();
//            v.setEnabled(false);
        }
        else {
            v.setEnabled(true);
            new AlertDialog.Builder(this)
                    .setTitle("Create Purchase Order")
                    .setMessage("Are you sure you want to create this Purchase Order?")
                    .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int which) {
                            new AsyncTask<String, Void, String>() {
                                @Override
                                protected String doInBackground(String... params) {
                                    Log.i("watch cart !!!!!", purchase_order_shoppingcart_frag.cart1.get(0).getItemCode());
                                    supplierCode = Supplier.snames.get(params[0]);
                                    PurchaseOrder.createPo(purchase_order_shoppingcart_frag.cart1, supplierCode, Login.userID);
                                    return params[0];
                                }

                                @Override
                                protected void onPostExecute(String sCode) {
                                    FrameLayout layout = (FrameLayout) findViewById(R.id.carts);
                                    layout.removeAllViews();
                                    db = new ShoppingCartDbAdapter(purchase_order_shoppingcart.this);
                                    db.open();
                                    for (ShoppingCart item : purchase_order_shoppingcart_frag.cart1) {
                                        Log.i("item sqliteId", Integer.toString(item.getSqliteid()));
                                        db.deleteCustomer(item.getSqliteid());
                                    }
                                    purchase_order_shoppingcart_frag.cart1.clear();
                                }
                            }.execute(supplierName);
                        }
                    })
                    .
                            setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int which) {
                                    // do nothing
                                }
                            })
                    .setIcon(android.R.drawable.ic_dialog_alert)
                    .show();

        }
    }

//            Cursor cursor = db.fetchAllCustomers();
//            cursor.moveToFirst();
//            while (!cursor.isAfterLast()) {
//                cart1.add(new ShoppingCart(cursor.getInt(cursor.getColumnIndex("_id")),
//                        cursor.getString(cursor.getColumnIndex("ItemCode")), cursor.getInt(cursor.getColumnIndex("Quantity"))));
//                cursor.moveToNext();
//            }
//            cursor.close();
////        }
//        list = this.getListView();
//        list.setClickable(true);
//        list.setItemsCanFocus(false);
//        adapter = new itemRequestAdapter(purchase_order_shoppingcart.this,R.layout.shoppingcart_row,cart1);
//        setListAdapter(adapter);
//
//        list.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
//            @Override
//            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
//                return false;
//            }
//        });
//
//    }
//
//    @Override
//    public void onListItemClick(final ListView l, final View v, final int position, long id){
//        LayoutInflater li = LayoutInflater.from(context);
//        View promptsView = li.inflate(R.layout.shoppingcart_prompts,null);
//
//        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
//                context);
//
//        // set prompts.xml to alertdialog builder
//        alertDialogBuilder.setView(promptsView);
//        final EditText userInput = (EditText) promptsView
//                .findViewById(R.id.editTextDialogUserInput);
////        final TextView userInput1 = (TextView) v
////                .findViewById(R.id.textView2);
//
//
//        for(int i=0; i<l.getChildCount(); i++)
//        {
//            if(i == position)
//            {
//                l.getChildAt(i).setBackgroundColor(Color.LTGRAY);
//            }
//            else
//            {
//                l.getChildAt(i).setBackgroundColor(Color.TRANSPARENT);
//            }
//
//        }
//
//        // set dialog message
//        alertDialogBuilder
//                .setCancelable(false)
//                .setPositiveButton("OK",
//                        new DialogInterface.OnClickListener() {
//                            public void onClick(DialogInterface dialog, int id) {
//                                TextView userInput1 = (TextView) l
//                                        .findViewById(R.id.textView2);
//                                Log.i("item old qty", userInput1.getText().toString());
//                                userInput1.setText(userInput.getText().toString());
//                                ShoppingCart item = (ShoppingCart) getListAdapter().getItem(position);
//                                int temp = Integer.parseInt(userInput.getText().toString());
//                                item.setItemQuantity(temp);
//                                db.updateCustomer(item.getSqliteid(), item.getItemCode(), item.getItemQuantity());
////                                l.invalidateViews();
//                                ((itemRequestAdapter) l.getAdapter()).notifyDataSetChanged();
//
//
////                                userInput1.setText(userInput.getText().toString());
////                                adapter.notifyDataSetChanged();
//                            }
//                        })
//                .setNegativeButton("Cancel",
//                        new DialogInterface.OnClickListener() {
//                            public void onClick(DialogInterface dialog, int id) {
//                                dialog.cancel();
//                            }
//                        });
//
//        // create alert dialog
//        AlertDialog alertDialog = alertDialogBuilder.create();
//
//        // show it
//        alertDialog.show();
//    }
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
