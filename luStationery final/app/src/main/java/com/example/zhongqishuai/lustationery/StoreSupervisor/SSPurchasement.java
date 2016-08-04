package com.example.zhongqishuai.lustationery.StoreSupervisor;


import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class SSPurchasement extends Fragment implements AdapterView.OnItemClickListener {


    public SSPurchasement() {
        // Required empty public constructor
    }

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View v = inflater.inflate(R.layout.fragment_ssadjustment, container, false);

        new AsyncTask<Void, Void, List<Purchasement>>() {
            @Override
            protected List<Purchasement> doInBackground(Void... params) {
                return Purchasement.PurchasementList(Integer.toString(Login.userID));
            }

            @Override
            protected void onPostExecute(List<Purchasement> result) {
                PurchasementAdapter adapter = new PurchasementAdapter(getActivity(), R.layout.porow, result);
                ListView list = (ListView) v.findViewById(R.id.listView);
                list.setAdapter(adapter);
                //setListAdapter(adapter);
                list.setOnItemClickListener(SSPurchasement.this);
            }
        }.execute();

        return v;
    }

    public void onItemClick(AdapterView<?> av, View v, int position, long id) {
        Log.i("Start", "");

        Purchasement item = (Purchasement) av.getAdapter().getItem(position);
        String adid = item.get("Purchaseorderno");
        Intent intent = new Intent(getActivity(), SSPurchaseDetail.class);
        intent.putExtra("RID", adid);
        startActivityForResult(intent, 2);

    }
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {

        if (requestCode == 2) {
            getActivity().recreate();
        }
    }
}