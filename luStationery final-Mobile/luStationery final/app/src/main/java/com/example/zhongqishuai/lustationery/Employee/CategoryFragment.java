package com.example.zhongqishuai.lustationery.Employee;


import android.os.Bundle;
//import android.app.Fragment;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class CategoryFragment extends Fragment {


//    public CategoryFragment() {
//        // Required empty public constructor
//    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment


        View v = inflater.inflate(R.layout.fragment_category, container, false);

        String []values = {"Clip","Envelope","Eraser","Exercise","File","Pen","Puncher","Pad","Paper","Ruler",
                "Scissors","Tape","Sharpener","Shorthand","Stapler","Tacks","Tparency","Tray"};

        ListView lv = (ListView)v.findViewById(R.id.listView);

        ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(),
                R.layout.row, R.id.catName, values);

        lv.setAdapter(adapter);

        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> arg0, View arg1, int position, long arg3) {
//                Toast.makeText(getActivity(), arg0.getAdapter().getItem(position) + " selected", Toast.LENGTH_SHORT).show();
                String cat_item = (String) arg0.getAdapter().getItem(position);
                display(cat_item);
            }
        });

        return v;

    }

    void display(String cat_item) {
        final String TAG = "ItemFragment";
        FragmentManager fm = getFragmentManager();
        FragmentTransaction trans = fm.beginTransaction();

        Fragment frag = new item1Fragment();
        Bundle args = new Bundle();
        args.putSerializable("cat", cat_item);
        frag.setArguments(args);
        if (fm.findFragmentByTag(TAG) == null) {
            // fragment not found -- to be added
//            Log.i("1234---", "not found fragment");
            trans.add(R.id.itemframe, frag, TAG);
        }
        else {
            // fragment found -- to be replaced
//            Log.i("abcd---", "found fragment");
            trans.replace(R.id.itemframe, frag, TAG);
        }
        trans.commit();
    }
}



