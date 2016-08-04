package com.example.zhongqishuai.lustationery.Employee;

import android.app.AlertDialog;
import android.app.ListActivity;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Color;
import android.os.Bundle;
import android.os.StrictMode;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Model.RequistionDetails;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;
import com.example.zhongqishuai.lustationery.StoreSupervisor.Adjustment;

import java.util.List;

public class ListItem extends ListActivity {
    final Context context = this;
    List<ShoppingCart> cart1;
    ListView list;
    ItemRequestAdapter adapter;
    Button confirmReqButton;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_list_item);

        cart1 = ShoppingCart.getCart();
        confirmReqButton = (Button) findViewById(R.id.button);
        if (cart1.size() == 0)
        {
            confirmReqButton.setEnabled(false);
        }
        list = this.getListView();
        list.setClickable(true);
        list.setItemsCanFocus(false);
        adapter = new ItemRequestAdapter(ListItem.this, R.layout.row3, cart1);
        setListAdapter(adapter);

        list.setOnItemLongClickListener(new AdapterView.OnItemLongClickListener() {
            @Override
            public boolean onItemLongClick(AdapterView<?> parent, View view, int position, long id) {
                return false;
            }
        });


        StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);

        confirmReqButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                android.support.v7.app.AlertDialog.Builder builder1 = new android.support.v7.app.AlertDialog.Builder(ListItem.this);
                builder1.setMessage("Confirm This Requisition?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                cart1 = ShoppingCart.getCart();
                                if(cart1.size()==0){
                                    Toast.makeText(ListItem.this, "Empty Shopping Cart...", Toast.LENGTH_SHORT).show();
                                }
                                else {
                                    String result = RequistionDetails.CreateReq(cart1);

                                    Toast.makeText(ListItem.this, "Requisition made Successfully...", Toast.LENGTH_SHORT).show();
                                    cart1.clear();
                                }
                                finish();
                            }
                        });

                builder1.setNegativeButton(
                        "No",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

                android.support.v7.app.AlertDialog alert11 = builder1.create();
                alert11.show();
            }
        });

    }

    @Override
    public void onListItemClick(final ListView l, final View v, final int position, long id){
        LayoutInflater li = LayoutInflater.from(context);
        View promptsView = li.inflate(R.layout.prompts,null);

        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                context);

        // set prompts.xml to alertdialog builder
        alertDialogBuilder.setView(promptsView);
        final EditText userInput = (EditText) promptsView
                .findViewById(R.id.editTextDialogUserInput);


        // set dialog message
        alertDialogBuilder
                .setCancelable(false)
                .setPositiveButton("OK",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                TextView userInput1 = (TextView) l
                                        .findViewById(R.id.textView2);
//                                Log.i("item old qty", userInput1.getText().toString());
                                userInput1.setText(userInput.getText().toString());
                                ShoppingCart item = (ShoppingCart) getListAdapter().getItem(position);

                                if (!(userInput.getText().toString().equals("")||userInput.getText().toString().equals("0")))
                                {
                                    int temp = Integer.parseInt(userInput.getText().toString());
                                    item.setItemQuantity(temp);
                                }
//                                  l.invalidateViews();
                                ((ItemRequestAdapter) l.getAdapter()).notifyDataSetChanged();
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


    @Override
    protected void onStart() {
        super.onStart();
        if (cart1.size() == 0)
        {
            confirmReqButton.setEnabled(false);
        }
    }
}
