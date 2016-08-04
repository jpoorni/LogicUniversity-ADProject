package com.example.zhongqishuai.lustationery.Representative;

import android.content.Context;
import android.os.AsyncTask;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.Requisition;
import com.example.zhongqishuai.lustationery.Model.RequistionDetails;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by zhongqishuai on 7/3/16.
 */
public class AllRequisitionDetailAdapter extends BaseExpandableListAdapter {

    private Context context;
    private List<Requisition> requisitionGroups;
    TextView RequisitionDate;
    TextView RequisitionId;
    TextView RequistionEmpName;
    TextView RequisitionStatus;
    String reqId;
    Requisition requistion;
    TextView reqItemName;
    TextView reqItemQty;

    public AllRequisitionDetailAdapter(Context context, List<Requisition> requistions) {
        this.context = context;
        this.requisitionGroups = requistions;
    }


    @Override
    public Object getChild(int groupPosition, int childPosition) {
        ArrayList<RequistionDetails> ReqDet = new ArrayList<RequistionDetails>();
        Log.i("***Req Id******",requisitionGroups.get(groupPosition).get("RequisitionId").toString());
        ReqDet = RequistionDetails.ReqDetailsList.get(requisitionGroups.get(groupPosition).get("RequisitionId"));
        Log.i("***Req Id obj******",ReqDet.toString());

        return ReqDet.get(childPosition);
    }

    @Override
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }

    @Override
    public View getChildView(int groupPosition, int childPosition,
                             boolean isLastChild, View convertView, ViewGroup parent) {

        RequistionDetails ReqDet = (RequistionDetails) getChild(groupPosition,childPosition);

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) context
                    .getSystemService(context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.req_details, null);
        }

        reqItemName = (TextView) convertView.findViewById(R.id.reqItemname);
        reqItemQty = (TextView) convertView.findViewById(R.id.reqItemQty);
        reqItemName.setText(ReqDet.get("ItemDescription").toString());
        reqItemQty.setText(ReqDet.get("QtyNeeded").toString());
        return convertView;
    }

    @Override
    public int getChildrenCount(int groupPosition) {
        return RequistionDetails.ReqDetailsList.get(requisitionGroups.get(groupPosition).get("RequisitionId").toString()).size();
    }

    @Override
    public Object getGroup(int groupPosition) {
        return requisitionGroups.get(groupPosition);
    }

    @Override
    public int getGroupCount() {
        return requisitionGroups.size();
    }

    @Override
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    @Override
    public View getGroupView(int groupPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {

        requistion = (Requisition) getGroup(groupPosition);
        if (convertView == null) {
            LayoutInflater inf = (LayoutInflater) context
                    .getSystemService(context.LAYOUT_INFLATER_SERVICE);
            convertView = inf.inflate(R.layout.requisition_all_detail_group, null);
        }

        new AsyncTask<Integer, Void, Integer>() {
            @Override
            protected Integer doInBackground(Integer... params) {
//                Log.i("AAAAAAAAAAAAAAAA", requisitionGroups.get(params[0]).get("RequisitionId").toString());
                reqId = requisitionGroups.get(params[0]).get("RequisitionId").toString();
//                Log.i("dddddddddddddddd",Integer.toString(params[0]));
                RequistionDetails.getRequisitionDet(reqId);
                return params[0];
            }

            @Override
            protected void onPostExecute(Integer position) {
            }
        }.execute(groupPosition);


        RequisitionId = (TextView)convertView.findViewById(R.id.textViewReqId);
        RequisitionId.setText(requisitionGroups.get(groupPosition).get("RequisitionId").toString());

        RequisitionDate = (TextView)convertView.findViewById(R.id.req_Date);
        RequisitionDate.setText(requisitionGroups.get(groupPosition).get("RequisitionDate").toString());

        RequistionEmpName = (TextView)convertView.findViewById(R.id.EmpName);
        RequistionEmpName .setText(requisitionGroups.get(groupPosition).get("EmployeeName").toString());

        RequisitionStatus = (TextView)convertView.findViewById(R.id.reqStatus);
        RequisitionStatus.setText(requisitionGroups.get(groupPosition).get("StatusDescription").toString());

        return convertView;
    }

    @Override
    public boolean hasStableIds() {
        return true;
    }

    @Override
    public boolean isChildSelectable(int groupPosition, int childPosition) {
        return true;
    }

}
