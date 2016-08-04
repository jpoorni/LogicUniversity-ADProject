package com.example.zhongqishuai.lustationery.Employee;

import android.app.Activity;
import android.graphics.Bitmap;
import android.os.AsyncTask;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.Item;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

//public class ItemDetails extends AppCompatActivity {
public class ItemDetails extends Activity {
    ShoppingCart ShoppingCartObject = new ShoppingCart();
    final List<ShoppingCart> cart = ShoppingCart.getCart();
//    if (cart == null)
//    {
//        List<ShoppingCart> ShoppingCartList= new ArrayList<ShoppingCart>();
//    }


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_item_details);

        final String ItemDesc  =  getIntent().getStringExtra("ItemDesc");

        final String UOM  =  getIntent().getStringExtra("UOM");

        final String ImageUrl  =  getIntent().getStringExtra("ImageUrl");

        final String Itemcode = getIntent().getStringExtra("Itemcode");

        Log.i("item details",Itemcode + ItemDesc + UOM + ImageUrl);

//        Log.i("selected item UOM", UOM);

        TextView e = (TextView) findViewById(R.id.textViewItemDesc);
        e.setText(ItemDesc);

        TextView e1 = (TextView) findViewById(R.id.textViewUOM);
        e1.setText(UOM);

        final ImageView m1 = (ImageView) findViewById(R.id.imageView3);

        new AsyncTask<Void, Void, Bitmap>() {
            @Override
            protected Bitmap doInBackground(Void... params) {
                return Item.getPhoto(ImageUrl);
            }
            @Override
            protected void onPostExecute(Bitmap result) {
                m1.setImageBitmap(result);
            }
        }.execute();

        final EditText e2 = (EditText) findViewById(R.id.editTextQty);

        Button addButton  = (Button) findViewById(R.id.buttonAddCart);
        final String temp = e2.getText().toString();


        addButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

//                if (Integer.parseInt(e2.getText().toString()) == 0 ) {
//                    Log.i("empty errdfdfdfd",temp);
//                    e2.setError("Quantity cannot be Zero!");
//                }
                if (temp.matches("") || e2.getText().toString().matches("0")) {
                    Log.i("empty err", e2.getText().toString());
                    e2.setError("Enter Quantity & add to cart!");
                }
                else if (temp.isEmpty()) {
                    Log.i("empty errdfdfdfd",temp);
                    e2.setError("Quantity cannot be Zero!");
                }

                if (e2.getText().length() > 0) {
                    e2.setError(null);
                    ShoppingCartObject.setItemDescription(ItemDesc);
                    ShoppingCartObject.setItemCode(Itemcode);
                    ShoppingCartObject.setItemQuantity(Integer.parseInt(e2.getText().toString()));

                    cart.add(ShoppingCartObject);
                    finish();
                }
            }
        });


    }


}
