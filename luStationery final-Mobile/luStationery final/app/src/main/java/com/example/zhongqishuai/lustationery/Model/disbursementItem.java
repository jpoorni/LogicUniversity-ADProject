package com.example.zhongqishuai.lustationery.Model;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;

/**
 * Created by zhongqishuai on 7/3/16.
 */
public class disbursementItem extends HashMap {
    public static HashMap<Integer,ArrayList<disbursementItem>> disbursementItems=new HashMap<Integer,ArrayList<disbursementItem>>();
    final static String baseurl = "http://10.10.1.139/test/Service.svc";
    public disbursementItem(String itemDes, int reqQty)
    {
        put("itemDes",itemDes);
        put("reqQty",reqQty);
    }
    public static void getDisbursementItems(int disbursementId)
    {
        ArrayList<disbursementItem> disitemlist=new ArrayList<disbursementItem>();
        JSONArray disbs= JSONParser.getJSONArrayFromUrl(String.format("%s/DisbursementDetailsListforMobile/%s", baseurl, disbursementId));
        try
        {
            for (int i =0; i<disbs.length(); i++) {
                JSONObject disbursement=disbs.getJSONObject(i);
                disitemlist.add(new disbursementItem(disbursement.getString("ItemDes"),disbursement.getInt("ReqQty")));
            }
        }catch (Exception e){
        }
//        if (disbursementId==12045) {
//            disitemlist.add(new disbursementItem("Clip Double", 12));
//            disitemlist.add(new disbursementItem("Whopper", 20));
//            disbursementItems.put(disbursementId, disitemlist);
//        }
//        else {
//            disitemlist.add(new disbursementItem("pencil", 30));
//            disbursementItems.put(disbursementId, disitemlist);
//        }

        disbursementItems.put(disbursementId, disitemlist);
    }
}
