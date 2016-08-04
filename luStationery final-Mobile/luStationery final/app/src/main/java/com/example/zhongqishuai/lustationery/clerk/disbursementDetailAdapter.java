package com.example.zhongqishuai.lustationery.clerk;

import android.content.Context;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseExpandableListAdapter;
import android.widget.TextView;

import com.example.zhongqishuai.lustationery.Model.Disbursement;
import com.example.zhongqishuai.lustationery.Model.disbursementItem;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;

/**
 * Created by zhongqishuai on 7/3/16.
 */
public class disbursementDetailAdapter extends BaseExpandableListAdapter {

    private Context context;
    private ArrayList<Disbursement> disbursementGroups;
//    private HashMap<Integer,ArrayList<disbursementItem>> disbursementItems=new HashMap<Integer,ArrayList<disbursementItem>>();
    TextView itemName;
    TextView itemQty;
    TextView deptName;
    TextView collectionDate;
    TextView rep;
    TextView collectionpoint;
    Integer disbursementId;
    Disbursement dis;
    View ConvertView;
    String departmentName;
    String cDate;
    ArrayList<disbursementItem>disitems;
    public disbursementDetailAdapter(Context context, ArrayList<Disbursement> disbursements) {
        this.context = context;
        this.disbursementGroups = disbursements;
    }
    @Override
    public Object getChild(int groupPosition, int childPosition) {
        Log.i("12345678901", disbursementGroups.get(groupPosition).get("disbursementId").toString());
          int disbursementid=Integer.parseInt(disbursementGroups.get(groupPosition).get("disbursementId").toString());
//        new AsyncTask<Integer,Void,Integer>()
//        {
//            @Override
//            protected Integer doInBackground(Integer... params) {
//                String did=disbursementGroups.get(groupPosition).get("disbursementId").toString();
//                return Integer.parseInt(did);
//            }
//            @Override
//            protected void onPostExecute(Integer disbursementid) {
                disitems=disbursementItem.disbursementItems.get(disbursementid);
                Log.i("~~~~~~~~~~~~~~~",Integer.toString(disitems.size()));
//            }
//        }.execute(groupPosition);

        return disitems.get(childPosition);
    }

    @Override
    public long getChildId(int groupPosition, int childPosition) {
        return childPosition;
    }
    @Override
    public View getChildView(int groupPosition, int childPosition,
                             boolean isLastChild, View convertView, ViewGroup parent) {

        if (convertView == null) {
            LayoutInflater infalInflater = (LayoutInflater) context
                    .getSystemService(context.LAYOUT_INFLATER_SERVICE);
            convertView = infalInflater.inflate(R.layout.dis_item, null);
        }
        itemName = (TextView) convertView.findViewById(R.id.item_name);
        itemQty = (TextView) convertView.findViewById(R.id.disItemQty);
//        new AsyncTask<Integer,Void,disbursementItem>()
//        {
//            @Override
//            protected disbursementItem doInBackground(Integer... params) {
                disbursementItem item = (disbursementItem) getChild(groupPosition,childPosition);
//                return item;
//            }
//            @Override
//            protected void onPostExecute(disbursementItem item) {
                itemName.setText(item.get("itemDes").toString());
                itemQty.setText(item.get("reqQty").toString());
//            }
//        }.execute(groupPosition,childPosition);
        return convertView;
    }
    @Override
    public int getChildrenCount(int groupPosition) {
        return disbursementItem.disbursementItems.get(Integer.parseInt(disbursementGroups.get(groupPosition).get("disbursementId").toString())).size();
    }

    @Override
    public Object getGroup(int groupPosition) {
//        int disId=Integer.parseInt(disbursementGroups.get(groupPosition).get("disbursementId").toString());
        return disbursementGroups.get(groupPosition);
    }

    @Override
    public int getGroupCount() {
        return disbursementGroups.size();
    }

    @Override
    public long getGroupId(int groupPosition) {
        return groupPosition;
    }

    @Override
    public View getGroupView(int groupPosition, boolean isExpanded,
                             View convertView, ViewGroup parent) {
//        dis = (Disbursement) getGroup(groupPosition);
        ConvertView=convertView;
        if (ConvertView == null) {
            LayoutInflater inf = (LayoutInflater) context
                    .getSystemService(context.LAYOUT_INFLATER_SERVICE);
            ConvertView = inf.inflate(R.layout.disbursement_detail_group, null);
//            ConvertView=convertView;
        }
//        new AsyncTask<Integer, Void, Integer>() {
//            @Override
//            protected Integer doInBackground(Integer... params) {
                dis = (Disbursement) getGroup(groupPosition);
                Log.i("AAAAAAAAAAAAAAAA", disbursementGroups.get(groupPosition).get("disbursementId").toString());
//                disbursementId=Integer.parseInt(disbursementGroups.get(groupPosition).get("disbursementId").toString());
                Log.i("dddddddddddddddd", Integer.toString(groupPosition));
//                disbursementItem.getDisbursementItems(disbursementId);
//                return params[0];
//            }
//
//            @Override
//            protected void onPostExecute(Integer position) {
                deptName=(TextView)ConvertView.findViewById(R.id.dept_name);
                collectionDate=(TextView)ConvertView.findViewById(R.id.date_time);
                rep=(TextView)ConvertView.findViewById(R.id.rep_name);
                collectionpoint=(TextView)ConvertView.findViewById(R.id.collection_name);
               departmentName=dis.get("departmentName").toString();
                cDate=dis.get("collectionDate").toString();
                deptName.setText(departmentName);
                collectionDate.setText(cDate);
                rep.setText(dis.get("employeeName").toString());
                collectionpoint.setText(dis.get("collectionName").toString());
//            }
//        }.execute(groupPosition);

        return ConvertView;
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
