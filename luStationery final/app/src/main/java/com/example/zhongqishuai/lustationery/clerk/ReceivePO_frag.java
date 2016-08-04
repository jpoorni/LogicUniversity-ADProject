package com.example.zhongqishuai.lustationery.clerk;

import android.app.ListFragment;
import android.os.AsyncTask;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.zhongqishuai.lustationery.Model.PurchaseOrder;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * Created by zhongqishuai on 9/3/16.
 */
public class ReceivePO_frag extends ListFragment {

    int purchaseOrderId;
    public static List<PurchaseOrder> details;
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        // setContentView(R.layout.my_browser);
        purchaseOrderId=getArguments().getInt("PurchaseOrder");
    }
    public View onCreateView (LayoutInflater inflater, ViewGroup container, Bundle
            savedInstanceState) {
        View v = inflater.inflate(R.layout.receive_po_frag, container, false);
//        list=(ListView) v.findViewById(android.R.id.list);
        new AsyncTask<Integer, Void, List<PurchaseOrder>>() {
            @Override
            protected List<PurchaseOrder> doInBackground(Integer... params) {
                PurchaseOrder.getPurchaseOrderDetails(params[0]);
                details=PurchaseOrder.PurchaseOrder.get(params[0]);
                return PurchaseOrder.PurchaseOrder.get(params[0]);
            }

            @Override
            protected void onPostExecute(List<PurchaseOrder> details) {
                Log.i("}}}}}}}}}}}}}}}", Integer.toString(details.size()));
                ReceivePoAdapter adapter = new ReceivePoAdapter(getActivity(), R.layout.receivepo_row, details);
                setListAdapter(adapter);
            }
        }.execute(purchaseOrderId);
        return v;
    }
}
