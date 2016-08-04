package com.example.zhongqishuai.lustationery.clerk;

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

/**
 * Created by zhongqishuai on 8/3/16.
 */
public class purchase_order_adapter extends BaseAdapter {
    Context mcontext;
    List<Item> items;
    Item selectedItem;
//    TextView tv;
//    ImageView img;
    String itemName;
    private static LayoutInflater inflater=null;
    public purchase_order_adapter(Context context,List<Item> itemList)
    {
        mcontext=context;
        items = itemList;
        Log.i("|||||||||||||||||", Integer.toString(items.size()));
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
        final View rowView;

        //rowView = inflater.inflate(R.layout.programlist, null);

        LayoutInflater inflater = LayoutInflater.from(mcontext);
        rowView = inflater.inflate(R.layout.purchase_order_gridviewcell, parent, false);
        holder.tv=(TextView) rowView.findViewById(R.id.purchaseItemText);
        holder.img=(ImageView)rowView.findViewById(R.id.imageView1);
        itemName=items.get(position).get("ItemDescription");
        Log.i("*************",itemName);
        holder.tv.setText(itemName);
        new AsyncTask<Void, Void, Bitmap>()
        {
            @Override
            protected Bitmap doInBackground(Void...params)
            {
                selectedItem = items.get(position);
                return Item.getPhoto(selectedItem.get("ImageUrl"));
            }
            @Override
            protected void onPostExecute(Bitmap result)
            {
                holder.img.setImageBitmap(result);
            }
        }.execute();


        return rowView;
    }
}
