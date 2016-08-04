package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by student on 6/3/16.
 */
public class RequisitionDetailsDepHead extends HashMap<String, String> {

    final static String baseurl = "http://10.10.1.139/test/Requisition.svc/Viewemployeereq/";
    public RequisitionDetailsDepHead(String category, String itemDescription, String qtyNeeded) {
        put("category", category);
        put("itemDescription", itemDescription);
        put("qtyNeeded", qtyNeeded);
    }

    public static List<RequisitionDetailsDepHead> RequisitionListById(String dept) {
        List<RequisitionDetailsDepHead> list = new ArrayList<RequisitionDetailsDepHead>();
        JSONArray b = JSONParser.getJSONArrayFromUrl(baseurl + dept);
        Log.i("URL", baseurl + dept);
        try {
            for (int i = 0; i < b.length(); i++) {
                JSONObject a = b.getJSONObject(i);

                RequisitionDetailsDepHead R =  new RequisitionDetailsDepHead(a.getString("Category"),
                        a.getString("ItemDescription"),Integer.toString(a.getInt("QtyNeeded"))
                        );

                list.add(R);

            }
        } catch (Exception e) {
            Log.e("LUS", "JSONArray error");
        }
        return (list);
    }
}
