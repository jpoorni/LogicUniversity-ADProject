package com.example.zhongqishuai.lustationery.StoreSupervisor;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * Created by student on 7/3/16.
 */
public class AdjustmentAdapter extends ArrayAdapter<Adjustment> {

    private List<Adjustment> items;
    int resource;


    public AdjustmentAdapter(Context context, int resource, List<Adjustment> items) {
        super(context, resource, items);
        this.resource = resource;
        this.items = items;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        notifyDataSetChanged();
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
        View v = inflater.inflate(resource, null);
        Adjustment Req = items.get(position);



        if (Req != null) {
            TextView e = (TextView) v.findViewById(R.id.textView2);
            e.setText(Req.get("totalAmount"));
            TextView e1 = (TextView) v.findViewById(R.id.textView1);

            e1.setText(Req.get("adjustDate").toString());

            TextView e2 = (TextView)v.findViewById(R.id.textView4);
            e2.setText(Req.get("adjustmentId"));

            // ImageView image = (ImageView) v.findViewById(R.id.imageView);

            //image.setImageBitmap(Requisition.getPhoto(true, eid));
        }
        return v;
    }
}