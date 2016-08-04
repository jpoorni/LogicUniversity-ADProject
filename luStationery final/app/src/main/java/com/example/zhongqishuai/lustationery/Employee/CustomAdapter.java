package com.example.zhongqishuai.lustationery.Employee;

/**
 * Created by student on 5/3/16.
 */

import android.content.Context;
import android.graphics.Bitmap;
import android.os.AsyncTask;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.Item;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

public class CustomAdapter extends BaseAdapter {

    String [] result;
    Context mcontext;
    int [] imageId;
    List<Item> items;
    Item mid;
    String itemName;
    private static LayoutInflater inflater=null;

    //public CustomAdapter(Context context, String cName, int[] prgmImages) {
    public CustomAdapter(Context context, List<Item> itemList)  {
        // TODO Auto-generated constructor stub
//        result=prgmNameList;
        //catName = cName;
        mcontext=context;
        items = itemList;
        notifyDataSetChanged();
//        Log.i("|||||||||||||||||", Integer.toString(items.size()));
    }


    @Override
    public int getCount() {
        // TODO Auto-generated method stub
        return items.size();
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

    public class Holder
    {
        TextView tv;
        ImageView img;
    }
    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        // TODO Auto-generated method stub
        final Holder holder=new Holder();
        View rowView;

        LayoutInflater inflater = LayoutInflater.from(mcontext);
        rowView = inflater.inflate(R.layout.itemlist, parent, false);
        holder.tv = (TextView) rowView.findViewById(R.id.textView1);
        holder.img = (ImageView) rowView.findViewById(R.id.imageView1);
        itemName=items.get(position).get("ItemDescription");
        Log.i("*************",itemName);
        holder.tv.setText(itemName);
//        mid = items.get(position);

        //holder.tv.setText(mid.get("itemDescription"));
//        String temp = mid.get("Itemcode") + mid.get("Photos");
//        Log.i("&&&&item code",mid.get("Itemcode"));
//        holder.tv.setText(temp);

//        holder.tv.setText(mid.get("Itemcode") + mid.get("Photos"));
//        Log.i("&&&&item code", mid.get("Itemcode"));

        new AsyncTask<Void, Void, Bitmap>() {
            @Override
            protected Bitmap doInBackground(Void... params) {
                mid = items.get(position);
//                Log.i("&&&&item code", mid.get("Itemcode"));
//                String temp = mid.get("Itemcode") + mid.get("Photos");
                return Item.getPhoto(mid.get("ImageUrl"));
            }
            @Override
            protected void onPostExecute(Bitmap result) {
                //holder.tv.setText(mid.get("Itemcode") + mid.get("Photos"));
//                holder.tv.setText(mid.get("ItemDescription"));
                holder.img.setImageBitmap(result);
            }
        }.execute();


        return rowView;
    }

}