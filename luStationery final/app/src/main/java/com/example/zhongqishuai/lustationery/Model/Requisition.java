package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by zhongqishuai on 5/3/16.
 */
public class Requisition extends HashMap {

    final static String baseURL = "http://10.10.1.139/test/Requisition.svc/RequisitionList";
    final static String baseURL1 = "http://10.10.1.139/test/Requisition.svc/Viewrequisitionbydept";
    public static HashMap<String,ArrayList<Requisition>> empRequisitionList =
            new HashMap<String,ArrayList<Requisition>>();

    public Requisition(String RequisitionDate, String RequisitionId,String TotalQty) {
        put("RequisitionDate", RequisitionDate);
        put("RequisitionId",RequisitionId);
        put("TotalQty",TotalQty);
    }

    public Requisition(String RequisitionDate, String RequisitionId,String EmployeeName, String StatusDescription) {
        put("RequisitionDate", RequisitionDate);
        put("RequisitionId",RequisitionId);
        put("EmployeeName",EmployeeName);
        put("StatusDescription",StatusDescription);
    }

    public static void getRequisitionListForEmp(String empId)
    {
        ArrayList<Requisition> Reqlist = new ArrayList<Requisition>();

        try {
            JSONArray a = JSONParser.getJSONArrayFromUrl(baseURL + "/" + empId);
            for (int i =0; i<a.length(); i++) {
                JSONObject b = a.getJSONObject(i);
                Reqlist.add(new Requisition(b.getString("RequisitionDate"),
                                b.getString("RequisitionId"),
                                b.getString("TotalQty"))
                );
            }
            empRequisitionList.put(empId,Reqlist);
        }
        catch (Exception e) {
            Log.e("getRequisition.list()", "JSONArray error");
        }
    }


    public static void getRequisitionbydept(String deptCode)
    {
        ArrayList<Requisition> Reqlist = new ArrayList<Requisition>();

        try {
            JSONArray a = JSONParser.getJSONArrayFromUrl(baseURL1 + "/" + deptCode);
            for (int i =0; i<a.length(); i++) {
                JSONObject b = a.getJSONObject(i);
                Reqlist.add(new Requisition(b.getString("RequisitionDate"),
                                b.getString("RequisitionId"),
                                b.getString("EmployeeName"),
                                b.getString("StatusDescription"))

                );
            }
            empRequisitionList.put(deptCode,Reqlist);
            Log.i("list no", Integer.toString(empRequisitionList.size()));
        }
        catch (Exception e) {
            Log.e("getRequisitionbydept", "JSONArray error");
        }
    }

}
