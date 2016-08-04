package com.example.zhongqishuai.lustationery.clerk;

import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.FrameLayout;
import android.widget.ListView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.R;

/**
 * Created by zhongqishuai on 8/3/16.
 */
public class purchase_order_category_frag extends Fragment {
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment


        View v = inflater.inflate(R.layout.purchase_order_category, container, false);

        String []values = {"Clip","Envelope","Eraser","Exercise","File","Pen","Puncher","Pad","Paper","Ruler",
                "Scissors","Tape","Sharpener","Shorthand","Stapler","Tacks","Tparency","Tray"};

        ListView lv = (ListView)v.findViewById(R.id.listView);

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(),
                R.layout.purchase_row, R.id.catName, values);

        lv.setAdapter(adapter);

        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> arg0, View arg1, int position, long arg3) {
                Toast.makeText(getActivity(), arg0.getAdapter().getItem(position) + " selected", Toast.LENGTH_SHORT).show();
                String cat_item = (String) arg0.getAdapter().getItem(position);
                display(cat_item);
            }
        });

        return v;

    }
    void display(String cat_item) {
        final String TAG = "ItemFragment";
        FragmentManager fm=getFragmentManager();
        FragmentTransaction trans = fm.beginTransaction();

        android.support.v4.app.Fragment frag = new purchase_order_item_frag();
        Bundle args = new Bundle();
        args.putSerializable("cat", cat_item);
        frag.setArguments(args);
        FrameLayout layout=(FrameLayout)getActivity().findViewById(R.id.itemframe);
        layout.removeAllViews();
        if (fm.findFragmentByTag(TAG) == null) {
            Log.i("1234---", "not found fragment");
            trans.add(R.id.itemframe, frag, TAG);
        }
        else {
            // fragment found -- to be replaced
            Log.i("abcd---", "found fragment");
            trans.replace(R.id.itemframe, frag, TAG);
        }
        trans.commit();
    }
}
