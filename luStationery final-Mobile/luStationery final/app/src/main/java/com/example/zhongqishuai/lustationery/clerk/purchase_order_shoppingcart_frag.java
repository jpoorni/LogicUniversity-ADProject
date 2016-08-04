package com.example.zhongqishuai.lustationery.clerk;

import android.app.AlertDialog;
import android.app.ListFragment;
import android.content.DialogInterface;
import android.database.Cursor;
import android.graphics.Color;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;
import com.example.zhongqishuai.lustationery.ShoppingCartSqLite.ShoppingCartDbAdapter;

import java.util.List;
import java.util.Vector;

/**
 * Created by zhongqishuai on 9/3/16.
 */
public class purchase_order_shoppingcart_frag extends ListFragment{
    public static List<ShoppingCart> cart1;
    ListView list;
    itemRequestAdapter adapter;
    ShoppingCartDbAdapter db;
    String supplierName;
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // setContentView(R.layout.my_browser);
        supplierName=getArguments().getString("supplier");
    }
    public View onCreateView (LayoutInflater inflater, ViewGroup container, Bundle
            savedInstanceState) {
        View v = inflater.inflate(R.layout.shopping_cart_list, container, false);
        db=new ShoppingCartDbAdapter(getActivity());
        db.open();
        cart1=new Vector<ShoppingCart>();
        Cursor cursor = db.fetchAllCustomers(supplierName, Login.userID);
        cursor.moveToFirst();
        while (!cursor.isAfterLast()) {
            cart1.add(new ShoppingCart(cursor.getInt(cursor.getColumnIndex("_id")),
                    cursor.getString(cursor.getColumnIndex("ItemCode")),
                    cursor.getString(cursor.getColumnIndex("ItemDesc")),
                    cursor.getInt(cursor.getColumnIndex("Quantity"))));
            cursor.moveToNext();
        }
        cursor.close();
        list=(ListView) v.findViewById(android.R.id.list);
        list.setClickable(true);
        list.setItemsCanFocus(false);
        adapter = new itemRequestAdapter(getActivity(), R.layout.shoppingcart_row,cart1);
        setListAdapter(adapter);

        list.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                return false;
            }
        });
        return v;
    }

    @Override
    public void onListItemClick(final ListView l, final View v, final int position, long id){
        LayoutInflater li = LayoutInflater.from(getActivity());
        View promptsView = li.inflate(R.layout.shoppingcart_prompts,null);

        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                getActivity());

        // set prompts.xml to alertdialog builder
        alertDialogBuilder.setView(promptsView);
        final EditText userInput = (EditText) promptsView
                .findViewById(R.id.editTextDialogUserInput);
//        final TextView userInput1 = (TextView) v
//                .findViewById(R.id.textView2);


        for(int i=0; i<l.getChildCount(); i++)
        {
            if(i == position)
            {
                l.getChildAt(i).setBackgroundColor(Color.LTGRAY);
            }
            else
            {
                l.getChildAt(i).setBackgroundColor(Color.TRANSPARENT);
            }

        }

        // set dialog message
        alertDialogBuilder
                .setCancelable(false)
                .setPositiveButton("OK",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                TextView userInput1 = (TextView) l
                                        .findViewById(R.id.textView2);
                                Log.i("item old qty", userInput1.getText().toString());
                                int oldquantity=Integer.parseInt(userInput1.getText().toString());
                                userInput1.setText(userInput.getText().toString());
                                ShoppingCart item = (ShoppingCart) getListAdapter().getItem(position);
                                if (userInput.getText().toString().equals("")||userInput.getText().toString().equals("0"))
                                {
//                                    userInput1.setError("Quantity cannot be empty or zero!");
                                    Toast.makeText(getActivity(), "Quantity cannot be empty or zero!", Toast.LENGTH_SHORT).show();
                                    userInput.setText(Integer.toString(oldquantity));
                                }
                                else if (Integer.parseInt(userInput.getText().toString())>1500)
                                {
                                    Toast.makeText(getActivity(), "Over Maximum!", Toast.LENGTH_SHORT).show();
                                    userInput.setText(Integer.toString(oldquantity));
                                }
                                int temp = Integer.parseInt(userInput.getText().toString());
                                item.setItemQuantity(temp);
                                db.updateCustomer(item.getSqliteid(), item.getItemCode(), item.getItemDescription(),
                                        item.getItemQuantity(),supplierName, Login.userID);
//                                l.invalidateViews();
                                ((itemRequestAdapter) l.getAdapter()).notifyDataSetChanged();


//                                userInput1.setText(userInput.getText().toString());
//                                adapter.notifyDataSetChanged();
                            }
                        })
                .setNegativeButton("Cancel",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

        // create alert dialog
        AlertDialog alertDialog = alertDialogBuilder.create();

        // show it
        alertDialog.show();
    }
}
