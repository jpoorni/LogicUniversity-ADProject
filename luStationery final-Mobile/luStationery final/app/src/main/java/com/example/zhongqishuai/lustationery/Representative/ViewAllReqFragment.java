package com.example.zhongqishuai.lustationery.Representative;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;

import com.example.zhongqishuai.lustationery.Employee.RequisitionDetailAdapter;
import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.Requisition;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;


public class ViewAllReqFragment extends Fragment {
    private ExpandableListView list;
    private AllRequisitionDetailAdapter ReqAdapter;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_view_all_req, container, false);

        // Inflate the layout for this fragment

        list = (ExpandableListView)v.findViewById(R.id.expandableListAllReq);
        list.setClickable(true);
        list.setItemsCanFocus(false);


        /*********TO DO************/
        //get the dep who logged in from the shared preferences
        //Currently hard-coded
        /*********TO DO************/
//        final String deptCode = "COMM";
        /****new***/
        final String deptCode = Login.departmentCode;
        /****new***/
        new AsyncTask<String, Void, ArrayList<Requisition>>() {
            @Override
            protected ArrayList<Requisition> doInBackground(String... params) {
                Requisition.getRequisitionbydept(deptCode);
                Log.i("params[0]",params[0]);
                return Requisition.empRequisitionList.get(params[0]);
            }


            @Override
            protected void onPostExecute(ArrayList<Requisition> result) {
                Log.i("req view - list size", Integer.toString(result.size()));
                Log.i("result",result.toString());
                ReqAdapter = new AllRequisitionDetailAdapter(getActivity(), result);
                list.setAdapter(ReqAdapter);
            }
        }.execute(deptCode);

        return v;
    }
}
