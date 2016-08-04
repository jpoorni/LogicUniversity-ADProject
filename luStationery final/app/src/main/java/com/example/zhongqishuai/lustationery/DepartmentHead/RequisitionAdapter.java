package com.example.zhongqishuai.lustationery.DepartmentHead;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.RequisitionDepHead;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * Created by student on 6/3/16.
 */
public class RequisitionAdapter extends ArrayAdapter<RequisitionDepHead> {

    private List<RequisitionDepHead> items;
    int resource;


    public RequisitionAdapter(Context context, int resource, List<RequisitionDepHead> items) {
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
        RequisitionDepHead Req = items.get(position);



        if (Req != null) {


            TextView e = (TextView) v.findViewById(R.id.reqEmployee);
            e.setText(Req.get(("employeeName")));
            TextView e1 = (TextView) v.findViewById(R.id.textViewReqId);
            e1.setText(Req.get("requisitionId").toString());
            TextView e2 = (TextView) v.findViewById(R.id.req_Date);
            e2.setText(Req.get(("requisitionDate")));

//            TextView e = (TextView) v.findViewById(R.id.textView2);
//            e.setText(Req.get(("employeeName")));
//            TextView e1 = (TextView) v.findViewById(R.id.textView1);
//
//            e1.setText(Req.get("requisitionId").toString());
//
//            ImageView image = (ImageView) v.findViewById(R.id.imageView);
//
//            image.setImageBitmap(RequisitionDepHead.getPhoto(true, eid));
        }
        return v;
    }
}
