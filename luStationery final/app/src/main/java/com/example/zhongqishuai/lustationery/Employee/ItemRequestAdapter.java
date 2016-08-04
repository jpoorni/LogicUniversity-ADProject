package com.example.zhongqishuai.lustationery.Employee;

import android.app.Activity;
import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

public class ItemRequestAdapter extends ArrayAdapter<ShoppingCart> {
    private List<ShoppingCart> items;
    int layout;

    public ItemRequestAdapter(Context context, int resource, List<ShoppingCart> items) {
        super(context, resource, items);
        this.items = items;
        this.layout = resource;
    }

    @Override
    public View getView(final int position, View convertView, ViewGroup parent) {
        LayoutInflater inflater = (LayoutInflater) getContext()
                .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
        View v = inflater.inflate(layout, null);

        final ShoppingCart mid = items.get(position);
        if (mid != null) {
            TextView m = (TextView) v.findViewById(R.id.textView1);
            m.setText(mid.getItemDescription());
            TextView m1 = (TextView) v.findViewById(R.id.textView2);
            m1.setText(Integer.toString(mid.getItemQuantity()));
        }


        ImageView buttonDelete = (ImageView) v.findViewById(R.id.imageButtonDelete);



        buttonDelete.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                items.remove(position);
                notifyDataSetChanged();
            }
        });

        return v;
    }
}
