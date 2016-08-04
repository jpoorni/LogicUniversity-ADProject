package com.example.zhongqishuai.lustationery.clerk;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Bitmap;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v7.app.AppCompatActivity;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.Item;
import com.example.zhongqishuai.lustationery.Model.Supplier;
import com.example.zhongqishuai.lustationery.R;
import com.example.zhongqishuai.lustationery.ShoppingCartSqLite.ShoppingCartDbAdapter;

public class purchase_order_additem extends Activity {
    //    ShoppingCart ShoppingCartObject = new ShoppingCart();
//    final List<ShoppingCart> cart = ShoppingCart.getCart();
    private ShoppingCartDbAdapter db;
    String[] suppliers;
    private  AlertDialog supplierDialog;
    int defaultQty;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_purchase_order_additem);
        final String ItemDesc  =  getIntent().getStringExtra("ItemDesc");
        final String itemCode=getIntent().getStringExtra("ItemCode");
        final String UOM  =  getIntent().getStringExtra("UOM");
        final String Url=getIntent().getStringExtra("ImageUrl");
        Log.i("selected item UOM", UOM);

        TextView e = (TextView) findViewById(R.id.add_po_textViewItemDesc);
        e.setText(ItemDesc);

        TextView e1 = (TextView) findViewById(R.id.add_po_textViewUOM);
        e1.setText(UOM);
        final EditText e2 = (EditText) findViewById(R.id.add_po_editTextQty);
        final ImageView img=(ImageView)findViewById(R.id.additem_imageView);
        new AsyncTask<String,Void,Integer>() {
            @Override
            protected Integer doInBackground(String... params) {
                suppliers= Supplier.getSupplier();
                return Item.getDefaultReorderQty(params[0]);
            }

            @Override
            protected void onPostExecute(Integer quantity) {
                defaultQty=quantity;
                e2.setText(quantity.toString());
            }
        }.execute(itemCode);
        new AsyncTask<String,Void,Bitmap>() {
            @Override
            protected Bitmap doInBackground(String... params) {
                return Item.getPhoto(params[0]);
            }

            @Override
            protected void onPostExecute(Bitmap image) {
                img.setImageBitmap(image);
            }
        }.execute(Url);
        e2.setOnEditorActionListener(new TextView.OnEditorActionListener() {
            @Override
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                if (actionId == EditorInfo.IME_ACTION_SEARCH ||
                        actionId == EditorInfo.IME_ACTION_DONE ||
                        event.getAction() == KeyEvent.ACTION_DOWN &&
                                event.getKeyCode() == KeyEvent.KEYCODE_ENTER) {
                    if (e2.getText().toString().equals("")) {
                        e2.setText(Integer.toString(defaultQty));
                    } else if (e2.getText().toString().equals("0")) {
                        e2.setError("Quantity cannot be Zero!");
                    } else if (Integer.parseInt(e2.getText().toString()) > 1500) {
                        e2.setError("Over the Maximum!");
                    }
                    InputMethodManager inputManager =
                            (InputMethodManager) purchase_order_additem.this.
                                    getSystemService(Context.INPUT_METHOD_SERVICE);
                    inputManager.hideSoftInputFromWindow(
                            purchase_order_additem.this.getCurrentFocus().getWindowToken(),
                            InputMethodManager.HIDE_NOT_ALWAYS);
                    v.clearFocus();
                    return true;

                }
                return false;
            }
        });

        Button addButton = (Button) findViewById(R.id.add_po_buttonAddCart);
        addButton.setOnClickListener(new View.OnClickListener()

        {
            @Override
            public void onClick(View v) {
                if (e2.getText().toString().equals("0")) {
                    e2.setError("Quantity cannot be Zero!");
                }
                else if (Integer.parseInt(e2.getText().toString()) > 1500) {
                    e2.setError("Over the Maximum!");
                }else {
                    AlertDialog.Builder builder = new AlertDialog.Builder(purchase_order_additem.this);
                    builder.setTitle("Select The Change Reason");
                    builder.setSingleChoiceItems(suppliers, -1, new DialogInterface.OnClickListener() {
                        public void onClick(DialogInterface dialog, int supplierRank) {
                            db = new ShoppingCartDbAdapter(purchase_order_additem.this);
                            db.open();
                            if (e2.getText().toString().equals("")) {
                                e2.setText(Integer.toString(defaultQty));
                            }
                            switch (supplierRank) {
                                case 0:
                                    db.createShoppingCartItem(itemCode, ItemDesc, Integer.parseInt(e2.getText().toString()), suppliers[supplierRank], Login.userID);
                                    finish();
                                    break;
                                case 1:
                                    db.createShoppingCartItem(itemCode, ItemDesc, Integer.parseInt(e2.getText().toString()), suppliers[supplierRank], Login.userID);
                                    finish();
                                    break;
                                case 2:
                                    db.createShoppingCartItem(itemCode, ItemDesc, Integer.parseInt(e2.getText().toString()), suppliers[supplierRank], Login.userID);
                                    finish();
                                    break;
                            }
                            supplierDialog.dismiss();
                        }
                    });
                    supplierDialog = builder.create();
                    supplierDialog.show();
                }
//                    ShoppingCartObject.setItemCode(ItemDesc);
//                    ShoppingCartObject.setItemQuantity(Integer.parseInt(e2.getText().toString()));
//                    cart.add(ShoppingCartObject);
                if (db != null) {
                    db.close();
                    db = null;
                }
//                    finish();
            }

        });

    }
}
