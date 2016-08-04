package com.example.zhongqishuai.lustationery.Employee;


import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
//import android.app.Fragment;
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

public class item1Fragment extends Fragment {
//
//    public static String [] prgmNameList={"Let Us C","c++","JAVA"};
//    public static int [] prgmImages={R.drawable.cescendants,R.drawable.creed,R.drawable.cinderella};

    public item1Fragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        View v = inflater.inflate(R.layout.fragment_item1, container, false);

        final GridView gv=(GridView) v.findViewById(R.id.gridView1);

        Bundle arg = getArguments();
        Log.i("args",arg.toString());
        if (arg != null) {
//            Log.i("cat***************",arg.getString("cat"));
            final String cat_item = arg.getString("cat");
            if (cat_item != null) {

                //gv.setBackgroundResource(R.drawable.cescendants);
                new AsyncTask<Void, Void, List<Item>>() {
                    @Override
                    protected List<Item> doInBackground(Void... params) {
//                        Log.i("back", "GET");
                        return Item.getItemList(cat_item);
                }

                    @Override
                    protected void onPostExecute(final List<Item> result) {
                        //gv.setAdapter(new CustomAdapter(getActivity(), result));
//                        Log.i("post", "result");
                        gv.setAdapter(new CustomAdapter(getActivity(), result));
                        /*********Working OK***************/
//                        Log.i("##########", "outside click event");
                        gv.setOnItemClickListener(new AdapterView.OnItemClickListener() {

                            public void onItemClick(AdapterView<?> parent, View v,
                                                    int position, long id) {
                                //Log.i("selected item", result.get(position).toString());
                                String ItemDesc =  result.get(position).get("ItemDescription");
                                String ImageUrl = result.get(position).get("ImageUrl");
                                String UOM = result.get(position).get("Uom");
                                String Itemcode = result.get(position).get("Itemcode");
//                                Log.i("selected item", Itemcode);
                                //items.get(position).
//                                Log.i("selected item", selectedItem.toString());
                                //Toast.makeText(getActivity(), selectedItem.get("ItemDescription").toString() + " item desc selected", Toast.LENGTH_SHORT).show();
                                Toast.makeText(getActivity(), ItemDesc + " item desc selected", Toast.LENGTH_SHORT).show();
                                // Send intent to SingleViewActivity
                                Intent i =
                                        new Intent(getActivity(), ItemDetails.class);
                                i.putExtra("ItemDesc", ItemDesc);
                                i.putExtra("ImageUrl", ImageUrl);
                                i.putExtra("UOM", UOM);
                                i.putExtra("Itemcode",Itemcode);
                                //startActivity(i);
                                startActivityForResult(i,80);
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



