package com.example.zhongqishuai.lustationery.clerk;

import android.app.ListActivity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;

import com.example.zhongqishuai.lustationery.Model.Retrieval;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

public class Retrieval_Confirm extends ListActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_retrieval__confirm);
//        final ListView list = (ListView) findViewById(android.R.id.list);
        Intent intent = getIntent();
        int categoryId=Integer.parseInt(intent.getExtras().getString("CategoryId"));
        int RetrievalId=intent.getExtras().getInt("RetrievalId");
//        List<Retrieval> retrievals=Retrieval.getRetrievalQtyByDepartment(categoryId);
        new AsyncTask<Integer, Void, List<Retrieval>>() {
            @Override
            protected List<Retrieval> doInBackground(Integer... params) {
                return Retrieval.getRetrievalQtyByDepartment(params[0],params[1]);
            }
            @Override
            protected void onPostExecute(List<Retrieval> result) {
                Log.i("}}}}}}}}}}}}}}}",Integer.toString(result.size()));
                Log.i("{{{{{{{{{{{{{{{",result.get(0).get("itemCode"));
                RetrievalListAdapter adapter = new RetrievalListAdapter(Retrieval_Confirm.this, R.layout.retrievalrow,result);
                setListAdapter(adapter);
            }
        }.execute(categoryId,RetrievalId);
    }
}
