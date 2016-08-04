package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by student on 9/3/16.
 */
public class Delegate extends HashMap<String, String> {
    final static String baseurl = "http://10.10.1.139/test";
    public Delegate(String employeeId, String employeeName, String status)
    {
        put("employeeId",employeeId);
        put("employeeName",employeeName);
        put("status",status);
    }

    public Delegate(String employeeName, String fromDate, String toDate, String reason, String status)
    {
        put("employeeName",employeeName);
        put("fromDate",fromDate);
        put("toDate",toDate);
        put("reason",reason);
        put("status",status);
    }

    public Delegate(String employeeName)
    {
        put("employeeName",employeeName);
    }


    public static Delegate getcurrent(String deptcode) {
        Delegate p = null;
        try {

            JSONObject a = JSONParser.getJSONFromUrl("http://10.10.1.139/test/Requisition.svc/getDelegate/" + deptcode);
            p = new Delegate(Integer.toString(a.getInt("EmployeeId")),a.getString("EmployeeName"),a.getString("Status"));
        } catch (Exception e) {
            Log.e("getProduct", "JSON error");
        }
        return p;
    }

    public static String InsertDelegate(Delegate d) {
        try {

            JSONObject del = new JSONObject();

            del.put("EmployeeName",d.get("employeeName"));
            del.put("FromDate", d.get("fromDate"));
//            del.put("FromDate", d.get("2016-03-10"));
            del.put("ToDate", d.get("toDate"));
            del.put("Reason", d.get("reason"));
            del.put("Status", d.get("status"));
            String json = del.toString();
            String result = JSONParser.postStream(
                    String.format("%s/Requisition.svc/InsertDelegation", baseurl),
                    json);
            Log.i("Json",result.toString());
        } catch (Exception e) {
            Log.e("updateProduct", "JSON error");
        }
        return (null);
    }

    public static List<Delegate> Emplist(String deptcode) {
        List<Delegate> list = new ArrayList<Delegate>();
        JSONArray b = JSONParser.getJSONArrayFromUrl("http://10.10.1.139/test/Requisition.svc/employeeList/" + deptcode);
        try {
            for (int i = 0; i < b.length(); i++) {
                JSONObject a = b.getJSONObject(i);
                list.add(

                        new Delegate(Integer.toString(a.getInt("EmployeeId")),
                                a.getString("EmployeeName"),a.getString("Status"))
                );
            }
        } catch (Exception e) {
            Log.e("Emplist", "JSONArray error");
        }
        return (list);
    }

    public static void EndDelegate(String EmpName) {
        try {
//            Log.i("Employee name",EmpName);
//            JSONObject del = new JSONObject();
//
//            del.put("EmployeeName",EmpName);
//            String json = del.toString();
//            Log.i("Json",json);
//            String result = JSONParser.postStream(
//                    String.format("%s/Requisition.svc/EndDelegation", baseurl),
//                    json);
            String result = JSONParser.getStream("http://10.10.1.139/test/Requisition.svc/EndDelegation/"+EmpName);
            Log.i("Json 123",result.toString());
        } catch (Exception e) {
            Log.e("enddelegation", "JSON error");
        }
    }

}
