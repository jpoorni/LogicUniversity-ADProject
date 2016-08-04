package com.example.zhongqishuai.lustationery.Employee;

import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ExpandableListView;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.Requisition;
import com.example.zhongqishuai.lustationery.R;
import java.util.ArrayList;


public class ViewReqFragment extends Fragment {
    private ExpandableListView list;
    private RequisitionDetailAdapter ReqAdapter;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_view_req, container, false);

        // Inflate the layout for this fragment

        list = (ExpandableListView)v.findViewById(R.id.expandableListReq);
        list.setClickable(true);
        list.setItemsCanFocus(false);


        /*********TO DO************/
        //get the emp who logged in from the shared preferences
        //Currently hard-coded
        /*********TO DO************/
//        String empId = "1006";

        /****new***/
        String empId = Integer.toString(Login.userID);
        /****new***/
        new AsyncTask<String, Void, ArrayList<Requisition>>() {
            @Override
            protected ArrayList<Requisition> doInBackground(String... params) {
                Requisition.getRequisitionListForEmp(params[0]);
                return Requisition.empRequisitionList.get(params[0]);
            }


            @Override
            protected void onPostExecute(ArrayList<Requisition> result) {
//                Log.i("after enter req view", Integer.toString(result.size()));
                ReqAdapter = new RequisitionDetailAdapter(getActivity(), result);
                list.setAdapter(ReqAdapter);
            }
        }.execute(empId);

        return v;
    }
}
