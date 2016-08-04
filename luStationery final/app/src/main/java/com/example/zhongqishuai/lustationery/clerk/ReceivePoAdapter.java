package com.example.zhongqishuai.lustationery.clerk;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.graphics.Color;
import android.os.AsyncTask;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.view.inputmethod.InputMethodManager;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Model.PurchaseOrder;
import com.example.zhongqishuai.lustationery.R;

import java.util.HashMap;
import java.util.List;

/**
 * Created by zhongqishuai on 9/3/16.
 */
public class ReceivePoAdapter extends ArrayAdapter<PurchaseOrder> {
    private List<PurchaseOrder> details;
    PurchaseOrder po;
    public static HashMap<Integer,Integer> tempQty;
    final String[] reasons = {" Items Broken "," Items Lost "};
    AlertDialog reasonDialog;
    public ReceivePoAdapter(Context context, int resource, List<PurchaseOrder> podetails) {
        super(context, resource, podetails);
        this.details=podetails;
        tempQty=new HashMap<Integer,Integer>();
    }
    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        ViewHolder holder;
        if (convertView == null) {
            holder = new ViewHolder();
            LayoutInflater inflater = (LayoutInflater) getContext()
                    .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.receivepo_row, null);
            po=details.get(position);
            if (po!= null) {
                holder.itemName = (TextView) convertView.findViewById(R.id.po_itemName);
                holder.itemName.setText(po.get("itemDes").toString());
                holder.itemQty=(EditText)convertView.findViewById(R.id.po_itemQty);
                holder.itemQty.setText(po.get("orderQty").toString());
                holder.itemQty.setId(position);
                tempQty.put(position, Integer.parseInt(po.get("orderQty").toString()));
            }
//            holder.btnChange=(Button)convertView.findViewById(R.id.btnChange);
//            holder.btnChange.setId(position);
//            holder.btnChange.setOnClickListener(new View.OnClickListener()
//            {
//                @Override
//                public void onClick(View view){
//                    final int position = view.getId();
//                    if(tempQty.get(position)>Integer.parseInt(details.get(position).get("orderQty").toString())) {
//                        Toast.makeText(getContext(), "Can not Change to a BIGGER Quantity!", Toast.LENGTH_SHORT).show();
//                    }
//                    else if(tempQty.get(position)==Integer.parseInt(details.get(position).get("orderQty").toString())){
//                        Toast.makeText(getContext(), "You Haven't Changed Anything", Toast.LENGTH_SHORT).show();
//                    }
//                    else {
////                    view.setEnabled(false);
////                    view.setVisibility(view.INVISIBLE);
//                        details.get(position).put("orderQty", tempQty.get(position));
//                        changePurchaseOrder(position);
//                    }
//                }
//            });
            holder.itemQty.setOnFocusChangeListener(new View.OnFocusChangeListener() {

                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (!hasFocus) {
                        final EditText Qty = (EditText) v;
                        judgeQty(v);
                    }
                }
            });
            holder.itemQty.setOnEditorActionListener(new TextView.OnEditorActionListener() {
                @Override
                public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                    if (actionId == EditorInfo.IME_ACTION_SEARCH ||
                            actionId == EditorInfo.IME_ACTION_DONE ||
                            event.getAction() == KeyEvent.ACTION_DOWN &&
                                    event.getKeyCode() == KeyEvent.KEYCODE_ENTER) {
                        final int position = v.getId();
                        final EditText Qty = (EditText) v;
                        Log.i("!!!!!!!!!!!!!","see what happened");
                        Qty.clearFocus();
                        return true;

                    }
                    return false;
                }
            });
            convertView.setTag(holder);
        } else {
            holder = (ViewHolder) convertView.getTag();
        }
        return convertView;
    }
    void judgeQty(View v)
    {
        final int position = v.getId();
        final EditText Qty = (EditText) v;
//        final Button btn=(Button)v.getTag(position);

        if (Qty.getText().toString().equals(""))
        {
            Qty.setText(Integer.parseInt(details.get(position).get("orderQty").toString()));
            Log.i("iiiiiiiiiiiii",details.get(position).get("orderQty").toString());
        }
        if (Integer.parseInt(Qty.getText().toString())>Integer.parseInt(details.get(position).get("orderQty").toString()))
        {
            Log.i("~~~~~~~~~~~~~", "I was touched");
//            Button btn=(Button)v.findViewById(position+1000);
//            btn.setEnabled(false);
            tempQty.put(position, Integer.parseInt(Qty.getText().toString()));
            Log.i("!!!!!!!!!!!!!!!!!", Qty.getText().toString());
//            Qty.setBackgroundColor(Color.parseColor("#FF4081"));
            Qty.setError("You cannot put a bigger number");
            Receive_PO_Main.btnConfirm.setEnabled(false);
            Receive_PO_Main.btnReject.setEnabled(false);
        }
        else {
            tempQty.put(position, Integer.parseInt(Qty.getText().toString()));
            Log.i(":::::::::::", Qty.getText().toString());
            Qty.setBackgroundColor(Color.parseColor("#FFFFFF"));
            Receive_PO_Main.btnConfirm.setEnabled(true);
            Receive_PO_Main.btnReject.setEnabled(true);
        }
    }
    class ViewHolder {
        TextView itemName;
        EditText itemQty;
        Button btnChange;

    }
//    void changePurchaseOrder(int position)
//    {
//        new AsyncTask<Integer,Void,Integer>() {
//            @Override
//            protected Integer doInBackground(Integer... params) {
//                int receiveQty = Integer.parseInt(details.get(params[0]).get("orderQty").toString());
//                PurchaseOrder.changePODetail(Integer.parseInt(details.get(params[0]).get("pdetailId").toString()),receiveQty);
//                return params[0];
//            }
//
//            @Override
//            protected void onPostExecute(Integer position) {
//                details.get(position).put("orderQty", tempQty.get(position));
//                Toast.makeText(getContext(), "Change Made", Toast.LENGTH_SHORT).show();
//            }
//        }.execute(position);
//    }
}

