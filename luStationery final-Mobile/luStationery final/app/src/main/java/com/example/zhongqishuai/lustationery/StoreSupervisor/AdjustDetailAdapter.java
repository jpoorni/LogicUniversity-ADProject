package com.example.zhongqishuai.lustationery.StoreSupervisor;

/**
 * Created by student on 8/3/16.
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

public class AdjustDetailAdapter extends ArrayAdapter<Adjustment> {
    private List<Adjustment> items;
    int resource;

    public AdjustDetailAdapter(Context context, int resource, List<Adjustment> items) {
        super(context, resource, items);
        this.resource = resource;
        this.items = items;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
        View v = inflater.inflate(resource, null);
        Adjustment Req = items.get(position);


        if (Req != null) {
            TextView e = (TextView) v.findViewById(R.id.textView2);
            e.setText(Req.get(("adreason")));
            TextView e1 = (TextView) v.findViewById(R.id.textView1);
            String adqty = Req.get("adQty").toString();
            String type = Req.get("type");
            String mark ="";
            if(type.matches("AdjustIn")){
             mark="+";
            }else{
                mark = "-";
            }
            //e1.setText(Req.get("adQty").toString());
            String full = mark + adqty;
            e1.setText(full);
            TextView t4= (TextView) v.findViewById(R.id.textView1);
            ImageView image = (ImageView) v.findViewById(R.id.imageView);

            image.setImageBitmap(Adjustment.getPhoto(Req.get("itemCode")));

        }
        return v;
    }
}
