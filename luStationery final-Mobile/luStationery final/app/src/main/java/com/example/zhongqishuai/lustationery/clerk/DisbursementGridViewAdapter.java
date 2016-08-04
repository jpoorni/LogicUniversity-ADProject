package com.example.zhongqishuai.lustationery.clerk;

import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Model.Disbursement;
import com.example.zhongqishuai.lustationery.R;

/**
 * Created by zhongqishuai on 5/3/16.
 */
public class DisbursementGridViewAdapter extends BaseAdapter {
    String [] result;
    Context context;
    int [] imageId;
    int [] badgeQty;
    String []Codes;
    private static LayoutInflater inflater=null;

    public DisbursementGridViewAdapter(disbursement_Main mainActivity, String[] prgmNameList, int[] prgmImages,int[] badgeQtys,String[]codes) {
        // TODO Auto-generated constructor stub
        result=prgmNameList;
        context=mainActivity.getActivity();
        imageId=prgmImages;
        badgeQty=badgeQtys;
        Codes=codes;
        inflater = ( LayoutInflater )context.
                getSystemService(Context.LAYOUT_INFLATER_SERVICE);

    }
    @Override
    public int getCount() {
        // TODO Auto-generated method stub

        return result.length;
    }

    @Override
    public Object getItem(int position) {
        // TODO Auto-generated method stub
        return position;
    }

    @Override
    public long getItemId(int position) {
        // TODO Auto-generated method stub
        return position;
    }
    @Override
    public void notifyDataSetChanged (){
        super.notifyDataSetChanged();
    }
    public class Holder
    {
        TextView departmentName;
        ImageView departmentImg;
        TextView badge;
    }
    public View getView(final int position, View convertView, ViewGroup parent) {
        // TODO Auto-generated method stub
        final Holder holder = new Holder();
        final View rowView;

        rowView = inflater.inflate(R.layout.disbursementgridviewcell, null);
        holder.departmentName = (TextView) rowView.findViewById(R.id.departmentName);
        holder.departmentImg = (ImageView) rowView.findViewById(R.id.departmentImage);
        holder.badge = (TextView) rowView.findViewById(R.id.badge2);
        holder.badge.setVisibility(rowView.VISIBLE);
        holder.badge.setText(Integer.toString(badgeQty[position]));
        holder.departmentName.setText(result[position]);
        holder.departmentImg.setBackgroundResource(imageId[position]);
        rowView.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                Toast.makeText(context, "You Clicked " + result[position], Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(context, DisbursementDetailActivity.class);
                Log.i("|||||||||||||||", Codes[position]);
                intent.putExtra("DepartmentId", Codes[position]);
                context.startActivity(intent);
                Disbursement.departmentDisQty.get(Codes[position]).put("totalDisbursementQty",0);
                holder.badge.setVisibility(View.INVISIBLE);
            }
        });
        return rowView;
    }
}
