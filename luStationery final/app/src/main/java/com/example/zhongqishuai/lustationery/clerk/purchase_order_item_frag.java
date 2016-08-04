package com.example.zhongqishuai.lustationery.clerk;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.GridView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Model.Item;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * Created by zhongqishuai on 8/3/16.
 */
public class purchase_order_item_frag extends Fragment {
    public purchase_order_item_frag() {
        // Required empty public constructor
    }
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        View v = inflater.inflate(R.layout.purchase_order_gridview, container, false);

        final GridView gv=(GridView) v.findViewById(R.id.purchase_order_gv);

        Bundle arg = getArguments();
        Log.i("args", arg.toString());
        if (arg != null) {
            Log.i("cat***************",arg.getString("cat"));
            final String cat_item = arg.getString("cat");
            if (cat_item != null) {

                //gv.setBackgroundResource(R.drawable.cescendants);
                new AsyncTask<Void, Void, List<Item>>() {
                    @Override
                    protected List<Item> doInBackground(Void... params) {
                        Log.i("back", "GET");
                        return Item.getItemList(cat_item);
                    }

                    @Override
                    protected void onPostExecute(final List<Item> result) {
                        //gv.setAdapter(new CustomAdapter(getActivity(), result));
                        Log.i("post", "result");
                        gv.setAdapter(new purchase_order_adapter(getActivity(), result));
                        /*********Working OK***************/
                        Log.i("##########", "outside click event");
                        gv.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                            public void onItemClick(AdapterView<?> parent, View v,
                                                    int position, long id) {
                                //Log.i("selected item", result.get(position).toString());
                                String ItemDesc =  result.get(position).get("ItemDescription");
                                String ItemPhoto = result.get(position).get("Photos");
                                String UOM = result.get(position).get("Uom");
                                String itemCode=result.get(position).get("Itemcode");
                                String imageUrl=result.get(position).get("ImageUrl");
//                                Log.i("selected item", ItemPhoto);
                                //items.get(position).
//                                Log.i("selected item", selectedItem.toString());
                                //Toast.makeText(getActivity(), selectedItem.get("ItemDescription").toString() + " item desc selected", Toast.LENGTH_SHORT).show();
                                Toast.makeText(getActivity(), ItemDesc + " item desc selected", Toast.LENGTH_SHORT).show();
                                // Send intent to SingleViewActivity
                                Intent i =
                                        new Intent(getActivity(), purchase_order_additem.class);
                                i.putExtra("ItemDesc", ItemDesc);
                                i.putExtra("ItemPhoto", ItemPhoto);
                                i.putExtra("UOM", UOM);
                                i.putExtra("ItemCode",itemCode);
                                i.putExtra("ImageUrl",imageUrl);
                                startActivity(i);
                            }
                        });
                        /*********Working OK***************/
                    }
                }.execute();
            }
        }
        return v;
    }
}
