package com.example.zhongqishuai.lustationery.clerk;

import android.app.Fragment;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;

import com.example.zhongqishuai.lustationery.Model.Retrieval;
import com.example.zhongqishuai.lustationery.R;

import java.util.HashMap;

/**
 * Created by zhongqishuai on 4/3/16.
 */
public class retrieval_gridView_Frag extends Fragment{
    int RetrievalID=0;
    GridView gv;
    View v;
    String [] prgmNameList={};
    int [] prgmImages={};
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // setContentView(R.layout.my_browser);
        RetrievalID=Integer.parseInt(getArguments().getString("RetrievalId"));
    }
    public View onCreateView (LayoutInflater inflater, ViewGroup container, Bundle
            savedInstanceState) {
        v = inflater.inflate(R.layout.retrievalgridviewfrag, container, false);
        new AsyncTask<Integer,Void,HashMap<String,Retrieval>>() {
            @Override
            protected HashMap<String, Retrieval> doInBackground(Integer... params) {
                Retrieval.getAllCatQty(RetrievalID);
                HashMap<String, Retrieval> categoryQtys = Retrieval.RetrievalCategories.get(RetrievalID);
                Log.i("!!!!!!!!!!!!!!!!!", Integer.toString(RetrievalID));
                Log.i("............size", Integer.toString(categoryQtys.size()));
                return categoryQtys;
            }

            @Override
            protected void onPostExecute(HashMap<String, Retrieval> categoryQtys) {
                prgmNameList = categoryQtys.keySet().toArray(new String[categoryQtys.keySet().size()]);
                prgmImages = new int[prgmNameList.length];
                for (int i = 0; i < prgmNameList.length; i++) {
                    prgmImages[i] = getResources().getIdentifier(prgmNameList[i].toLowerCase(), "drawable", getActivity().getPackageName());
                }
                BaseAdapter Myadapter = new retrievalGridViewAdapter(retrieval_gridView_Frag.this, prgmNameList, prgmImages, RetrievalID);
                Myadapter.notifyDataSetChanged();
//        gv.setAdapter(null);
//        gv.removeAllViews();
                gv=(GridView)v.findViewById(R.id.gridView1);
                gv.setAdapter(Myadapter);
                prgmNameList = null;
                prgmImages = null;
            }
        }.execute(RetrievalID);
        return v;
    }
}
