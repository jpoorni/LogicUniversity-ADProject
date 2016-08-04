package com.example.zhongqishuai.lustationery.Model;

/**
 * Created by student on 9/3/16.
 */

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;
import com.example.zhongqishuai.lustationery.Login;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;


/**
 * Created by student on 8/3/16.
 */
public class RequistionDetails extends HashMap <String,String> {

//    public static HashMap<Integer,ArrayList<disbursementItem>> disbursementItems=new HashMap<Integer,ArrayList<disbursementItem>>();
    public static HashMap<String,ArrayList<RequistionDetails>> ReqDetailsList = new HashMap<String,ArrayList<RequistionDetails>>();
    final static String baseURL = "http://10.10.1.139/test/Requisition.svc/Requisitiondetails";


    public RequistionDetails(String ItemDescription,String QtyNeeded,String StatusDescription) {
        put("ItemDescription",ItemDescription);
        put("QtyNeeded",QtyNeeded);
        put("StatusDescription",StatusDescription);
    }

    public RequistionDetails(String ItemCode,String QtyNeeded,String DeptCode,String EmpCode) {
        put("ItemCode",ItemCode);
        put("QtyNeeded",QtyNeeded);
        put("DeptCode",DeptCode);
        put("EmpCode",EmpCode);
    }


    public static void getRequisitionDet(String rId) {
        Log.i("req. ID ------", rId);
        ArrayList<RequistionDetails> ReqDetails = new ArrayList();
        try {
            JSONArray a = JSONParser.getJSONArrayFromUrl(baseURL + "/" + rId);
            for (int i =0; i<a.length(); i++) {
                JSONObject b = a.getJSONObject(i);

                ReqDetails.add((new RequistionDetails(b.getString("ItemDescription"),b.getString("QtyNeeded"), b.getString("StatusDescription"))));
            }
            ReqDetailsList.put(rId, ReqDetails);
        }
        catch (Exception e) {
            Log.e("getRequisitionDet()", "JSONArray error");
        }
        return ;
    }


    public static String CreateReq(List<ShoppingCart> list) {
        JSONArray items = new JSONArray();

        List<RequistionDetails> list1 = new ArrayList();

        for (ShoppingCart s: list) {
//            Log.i("sdfdfdsfdfdf",s.getItemCode().toString());
//            Log.i("sdfdfdsfdfdf qty", Integer.toString(s.getItemQuantity()));
            //list1.add(new RequistionDetails(s.getItemCode(), Integer.toString(s.getItemQuantity()), "COMM","1006"));

            /****new***/
            list1.add(new RequistionDetails(s.getItemCode(), Integer.toString(s.getItemQuantity()), Login.departmentCode,Integer.toString(Login.userID)));
            /****new***/
        }

//        for (RequistionDetails e2 : list1) {
//            Log.e("In_CreateReq()", e2.get("QtyNeeded"));
//        }

        for(RequistionDetails e1 : list1)
        {
            JSONObject item = new JSONObject();

            try {
                item.put("EmployeeId", e1.get("EmpCode"));
                item.put("DepartmentCode",e1.get("DeptCode"));
                item.put("ItemCode", e1.get("ItemCode"));
                item.put("QtyNeeded", e1.get("QtyNeeded"));
                /***hard coded.. empcode & dept code need to get from the shared preferences***/

                /***hard coded.. empcode & dept code need to get from the shared preferences***/

            } catch (JSONException e) {
                e.printStackTrace();
            }

            items.put(item);
        }

        Log.e("Result", items.toString());

    String result = JSONParser.postStream("http://10.10.1.139/test/Requisition.svc/CreateRequisition", items.toString());

      Log.e("Result 123", result.toString());

        return result;

    }

//
    }


