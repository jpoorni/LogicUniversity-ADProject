package com.example.zhongqishuai.lustationery.DepartmentHead;


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
import com.example.zhongqishuai.lustationery.Model.RequisitionDepHead;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class dhRequisition extends Fragment implements AdapterView.OnItemClickListener{


    public dhRequisition() {
        // Required empty public constructor
    }

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        final View v = inflater.inflate(R.layout.fragment_dh_requisition, container, false);

        new AsyncTask<Void, Void, List<RequisitionDepHead>>() {
            @Override
            protected List<RequisitionDepHead> doInBackground(Void... params) {

//                return RequisitionDepHead.RequisitionList("COMM");
                /****new***/
                Log.i("dep code in dhReq",Login.departmentCode);
                return RequisitionDepHead.RequisitionList(Login.departmentCode);
                /****new***/
            }
            @Override
            protected void onPostExecute(List<RequisitionDepHead> result) {

                ListView list = (ListView) v.findViewById(R.id.listView);
                RequisitionAdapter adapter = new RequisitionAdapter(getActivity(), R.layout.requisitionrow, result);
//                Log.i("req list",result.toString());
                list.setAdapter(adapter);
                //setListAdapter(adapter);
                list.setOnItemClickListener(dhRequisition.this);
            }
        }.execute();

        return  v;
    }

    public void onItemClick(AdapterView<?> av, View v, int position, long id) {

//        Log.i("Start","");

        RequisitionDepHead item = (RequisitionDepHead) av.getAdapter().getItem(position);
        String Reqid = item.get("requisitionId");

        Intent intent = new Intent(getActivity(), dhRequisitionDetails.class);
        intent.putExtra("RID", Reqid);
        startActivityForResult(intent, 1);

    }


    public void onActivityResult(int requestCode, int resultCode, Intent Data)
    {
        if (requestCode ==1)
        {
            getActivity().recreate();
        }
    }
}
