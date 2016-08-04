package com.example.zhongqishuai.lustationery.Representative;

import android.app.Activity;
import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.DisbursementDetailsRep;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;
import java.util.List;

public class DisbursementDetRepAdapter extends ArrayAdapter<DisbursementDetailsRep> {
    private ArrayList<DisbursementDetailsRep> items;
    int layout;

    public DisbursementDetRepAdapter(Context context, int resource, ArrayList<DisbursementDetailsRep> items) {
        super(context, resource, items);
        this.items = items;
        this.layout = resource;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);

        View v = inflater.inflate(layout, null);

        DisbursementDetailsRep mid = items.get(position);

        if (mid != null) {
            TextView m = (TextView) v.findViewById(R.id.textViewDisDet);
            m.setText(mid.get("ItemDes").toString());
//            String temp = mid.get("ReqQty").toString();
            TextView m1 = (TextView) v.findViewById(R.id.textViewReqQty);
            m1.setText(mid.get("ReqQty").toString());
            TextView m2 = (TextView) v.findViewById(R.id.textViewRecQty);
            m2.setText(mid.get("ReceivedQuantity").toString());
//            Log.i("||||item desc||||||", mid.toString());
        }
        return v;
    }
}
