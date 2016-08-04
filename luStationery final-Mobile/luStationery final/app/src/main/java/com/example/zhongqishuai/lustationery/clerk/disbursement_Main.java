package com.example.zhongqishuai.lustationery.clerk;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.GridView;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.Disbursement;
import com.example.zhongqishuai.lustationery.R;

import java.util.HashMap;

/**
 * Created by zhongqishuai on 5/3/16.
 */
public class disbursement_Main extends Fragment {
    GridView gv;
    String [] prgmNameList={};
    int [] prgmImages={};
    int [] badgeQtys={};
    TextView alert;
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v = inflater.inflate(R.layout.disbursement_main, container, false);
//        restoreInstanceState(savedInstanceState);
        alert = (TextView) v.findViewById(R.id.dis_alert);
        alert.setVisibility(View.INVISIBLE);
        new AsyncTask<Void, Void, HashMap<String,Disbursement>>() {
            @Override
            protected HashMap<String,Disbursement> doInBackground(Void... params) {
                Disbursement.getDisbursementTotalQty();
                return Disbursement.departmentDisQty;
            }
            @Override
            protected void onPostExecute(HashMap<String,Disbursement> result) {
                prgmNameList = new String[result.size()];
                String[] tempCode = result.keySet().toArray(new String[result.keySet().size()]);
                prgmImages = new int[prgmNameList.length];
                badgeQtys = new int[prgmNameList.length];
                for (int i = 0; i < result.size(); i++) {
                    prgmNameList[i] = result.get(tempCode[i]).get("departmentName").toString();
                    prgmImages[i] = getResources().getIdentifier(tempCode[i].toLowerCase(), "drawable", getActivity().getPackageName());
                    badgeQtys[i] = Integer.parseInt(result.get(tempCode[i]).get("totalDisbursementQty").toString());
                }
                BaseAdapter Myadapter = new DisbursementGridViewAdapter(disbursement_Main.this, prgmNameList, prgmImages, badgeQtys, tempCode);
                Myadapter.notifyDataSetChanged();
                if (prgmNameList.length == 0) {
                    alert.setVisibility(View.VISIBLE);
                } else {
                    gv = (GridView) v.findViewById(R.id.disbursement_gv);
                    gv.setAdapter(Myadapter);
                }
            }
        }.execute();
        return v;
    }
}
