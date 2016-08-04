package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by student on 9/3/16.
 */
public class DisbursementRep extends HashMap {

    //    public static ArrayList<Integer> DisbursementIdsRepList = new ArrayList<Integer>();
    //final static String baseURL = "http://10.10.1.139/test/Requisition.svc/Viewdisbursement";
    final static String baseURL = "http://10.10.1.139/test/Service.svc/getDisIds";
    final static String baseURL1 = "http://10.10.1.139/test/Service.svc/getAllClerks";


    public DisbursementRep(Integer DisbursementID) {
        put("DisbursementID", DisbursementID);
    }


    public static ArrayList<Integer>  getAllDisForDep(String depID)
    {
        ArrayList<Integer> Dislist = new ArrayList<Integer>();
        try {
            JSONArray a = JSONParser.getJSONArrayFromUrl(baseURL + "/" + depID);
            for (int i =0; i<a.length(); i++) {
                //JSONObject b = a.getJSONObject(i);
                Integer b = a.getInt(i);
                Dislist.add(b);
//                Dislist.add(b.getInt("DisbursementID"));
            }
        }
        catch (Exception e) {
            Log.e("getAllDisForDep()", "JSONArray error");
        }
//        Dislist.add(13099);
//        Dislist.add(13100);
//        Dislist.add(13101);
        return Dislist;
    }


    public static ArrayList<String>  getAllClerk()
    {
        ArrayList<String> Clerklist = new ArrayList<String>();
        try {
            JSONArray a = JSONParser.getJSONArrayFromUrl(baseURL1);
            for (int i =0; i<a.length(); i++) {
                //JSONObject b = a.getJSONObject(i);
                String b = a.getString(i);
                Clerklist.add(b);
//                Dislist.add(b.getInt("DisbursementID"));
            }
        }
        catch (Exception e) {
            Log.e("getAllClerk()", "JSONArray error");
        }
        return Clerklist;
    }
}
