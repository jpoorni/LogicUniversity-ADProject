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

import com.example.zhongqishuai.lustationery.Model.Retrieval;
import com.example.zhongqishuai.lustationery.R;

/**
 * Created by zhongqishuai on 3/3/16.
 */
public class retrievalGridViewAdapter extends BaseAdapter {
    String [] result;
    Context context;
    int [] imageId;
    int RetrievalId;
    private static LayoutInflater inflater=null;

    public retrievalGridViewAdapter(retrieval_gridView_Frag mainActivity, String[] prgmNameList, int[] prgmImages,int RetrievalId) {
        // TODO Auto-generated constructor stub
        result=prgmNameList;
        context=mainActivity.getActivity();
        imageId=prgmImages;
        this.RetrievalId=RetrievalId;
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
        TextView catelogueName;
        ImageView catelogueImg;
        TextView badge;
    }
    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        // TODO Auto-generated method stub
        final Holder holder=new Holder();
        final View rowView;

        rowView = inflater.inflate(R.layout.retrievalgridviewcell, null);
        holder.catelogueName=(TextView) rowView.findViewById(R.id.catelogueName);
        holder.catelogueImg=(ImageView) rowView.findViewById(R.id.catelogueImage);
        holder.badge=(TextView)rowView.findViewById(R.id.badge1);
        int hasQty= Integer.parseInt(Retrieval.RetrievalCategories.get(RetrievalId).get(result[position]).get("count"));
        if (hasQty>0)
        {
            holder.badge.setVisibility(rowView.VISIBLE);
            holder.badge.setText(Integer.toString(hasQty));
        }
        holder.catelogueName.setText(result[position]);
        holder.catelogueImg.setBackgroundResource(imageId[position]);
//        holder.img.se
        Log.i("------------", Integer.toString(result.length));
        Log.i("------------", Integer.toString(RetrievalId));
        rowView.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                // TODO Auto-generated method stub
                Toast.makeText(context, "You Clicked " + result[position], Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(context, Retrieval_Confirm.class);
                Log.i("|||||||||||||||",Retrieval.RetrievalCategories.get(RetrievalId).get(result[position]).get("categoryId"));
                intent.putExtra("CategoryId", Retrieval.RetrievalCategories.get(RetrievalId).get(result[position]).get("categoryId"));
                intent.putExtra("RetrievalId",RetrievalId);
                context.startActivity(intent);
                Retrieval.RetrievalCategories.get(RetrievalId).get(result[position]).put("count","0");
                holder.badge.setVisibility(View.INVISIBLE);
            }
        });
        return rowView;
    }



}
