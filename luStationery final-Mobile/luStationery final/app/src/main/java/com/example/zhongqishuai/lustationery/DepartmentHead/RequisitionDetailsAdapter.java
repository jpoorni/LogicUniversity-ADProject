package com.example.zhongqishuai.lustationery.DepartmentHead;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.RequisitionDetailsDepHead;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * Created by student on 6/3/16.
 */
public class RequisitionDetailsAdapter extends ArrayAdapter<RequisitionDetailsDepHead> {

    private List<RequisitionDetailsDepHead> items;
    int resource;


    public RequisitionDetailsAdapter(Context context, int resource, List<RequisitionDetailsDepHead> items) {
        super(context, resource, items);
        this.resource = resource;
        this.items = items;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
        View v = inflater.inflate(resource, null);
        RequisitionDetailsDepHead Req = items.get(position);



        if (Req != null) {
//            TextView e = (TextView) v.findViewById(R.id.reqEmployee);
//            e.setText(Req.get(("EmployeeName")));
            TextView e1 = (TextView) v.findViewById(R.id.textViewItemDesc);
//            Log.i("ID", Req.get("requisitionId").toString());
            e1.setText(Req.get("itemDescription").toString());
            TextView e2 = (TextView) v.findViewById(R.id.textViewReqQty);
            e2.setText(Req.get(("qtyNeeded")));


            // ImageView image = (ImageView) v.findViewById(R.id.imageView);

            //image.setImageBitmap(RequisitionDepHead.getPhoto(true, eid));
        }
        return v;
    }
}
