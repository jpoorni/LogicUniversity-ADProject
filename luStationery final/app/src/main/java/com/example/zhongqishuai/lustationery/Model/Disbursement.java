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
public class Disbursement  extends HashMap {
    public static HashMap<String,Disbursement> departmentDisQty=new HashMap<String,Disbursement>();
    final static String baseurl = "http://10.10.1.139/test/Service.svc";
    public static HashMap<String,ArrayList<Disbursement>> deptDisbursementList=
            new HashMap<String,ArrayList<Disbursement>>();
    public static HashMap<Integer,Disbursement>disbursementInfo =new HashMap<Integer,Disbursement>();
    public Disbursement(String departmentId, String departmentName,int totalDisbursementQty)
    {
        put("departmentId",departmentId);
        put("departmentName",departmentName);
        put("totalDisbursementQty",totalDisbursementQty);
    }
    public Disbursement(String collectionDate, int disbursementId, String departmentName,String collectionName,String employeeName)
    {
        put("collectionDate",collectionDate);
        put("disbursementId",disbursementId);
        put("departmentName",departmentName);
        put("collectionName",collectionName);
        put("employeeName", employeeName);
    }
//    public Disbursement(int disbursementId, String collectionName, int collectionId, int employeeId,String employeeName)
//    {
//
//        put("disbursementId",disbursementId);
//
//        put("collectionId",collectionId);
//        put("employeeId", employeeId);
//        put("employeeName", employeeName);
//    }
    public static void getDisbursementTotalQty()
    {
        JSONArray depts= JSONParser.getJSONArrayFromUrl(String.format("%s/DisForClerk", baseurl));
        try
        {
            for (int i =0; i<depts.length(); i++) {
                JSONObject department=depts.getJSONObject(i);
                departmentDisQty.put(department.getString("DepartmentId"),new Disbursement(department.getString("DepartmentId"),
                        department.getString("DepetName"),department.getInt("TotalDisburseIdNo")));
            }
        }catch (Exception e){
        }
//        departmentDisQty.put("COMM", new Disbursement("COMM", "Commerce Dept", 1));
//        departmentDisQty.put("ZOOL", new Disbursement("ZOOL", "Zoology Dept", 1));
    }
    public static void getDisbursementListForDept(String departmentId)
    {
        ArrayList<Disbursement> dislist=new ArrayList<Disbursement>();
        JSONArray disbs= JSONParser.getJSONArrayFromUrl(String.format("%s/DisbyDeptForClerk/%s", baseurl, departmentId));
        try
        {
            Log.i("wwwwwwwwwwwww", "wwwwwwwww");
            for (int i =0; i<disbs.length(); i++) {
                JSONObject department=disbs.getJSONObject(i);
                dislist.add(new Disbursement(department.getString("CollectionDate"),
                        department.getInt("DisbursementID"), department.getString("DepartmentName"),
                        department.getString("CollectionPointName"),
                        department.getString("EmployeeName")));
//                getDisDetailInfo(department.getInt("DisbursementID"));
                disbursementItem.getDisbursementItems(department.getInt("DisbursementID"));
            }
        }catch (Exception e){
        }
//        getDisDetailInfo(12045);
//        getDisDetailInfo(12046);
//        dislist.add(new Disbursement("12/03/16", 12077, "Commerce","A","B"));
//        dislist.add(new Disbursement("11/03/16",12077,"Commerce","A","B"));
//        disbursementItem.getDisbursementItems(12077);
//        disbursementItem.getDisbursementItems(12077);
        deptDisbursementList.put(departmentId,dislist);

    }
//    public static void getDisDetailInfo(int disbursementId)
//    {
//        JSONArray Dis=JSONParser.getJSONArrayFromUrl(String.format("%s/DisWithoutItemForClerk/%s", baseurl, disbursementId));
//        try {
//            Log.i("OOOO",Integer.toString(Dis.length()));
//            JSONObject DisbursementDetail=Dis.getJSONObject(0);
//            disbursementInfo.put(disbursementId,new Disbursement(disbursementId,DisbursementDetail.getString("CollectionPointName"),
//                    DisbursementDetail.getInt("CollectionPointId"),DisbursementDetail.getInt("EmployeeId"),
//                    DisbursementDetail.getString("EmployeeName")));
//            Log.i("PPPPPPPPPPPPPPP",disbursementInfo.get(disbursementId).get(disbursementId).toString());
//        }
//        catch (Exception e)
//        {
//            Log.i("JSON Error","JSON Error");
//        }
////        disbursementInfo.put(disbursementId,new Disbursement(disbursementId,"Central Lib",3001,4001,"Ferdinand"));
////        disbursementInfo.put(disbursementId,new Disbursement(disbursementId,"Central lib",3001,4001,"Ferdinand"));
//    }

}
