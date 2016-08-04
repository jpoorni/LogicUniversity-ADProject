package com.example.zhongqishuai.lustationery.StoreSupervisor;

/**
 * Created by student on 9/3/16.
 */

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.R;

import java.util.List;

public class PurchaseDetailAdapter extends ArrayAdapter<Purchasement> {
    private List<Purchasement> items;
    int resource;

    public PurchaseDetailAdapter(Context context, int resource, List<Purchasement> items) {
        super(context, resource, items);
        this.resource = resource;
        this.items = items;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
        View v = inflater.inflate(resource, null);
        Purchasement Req = items.get(position);


        if (Req != null) {
            TextView e = (TextView) v.findViewById(R.id.textView2);
            e.setText(Req.get(("OrderedQuantity")));
            TextView e1 = (TextView) v.findViewById(R.id.textView1);

            e1.setText(Req.get("Amount").toString());
            ImageView image = (ImageView) v.findViewById(R.id.imageView);

            image.setImageBitmap(Adjustment.getPhoto(Req.get("ItemCode")));

        }
        return v;
    }

}

