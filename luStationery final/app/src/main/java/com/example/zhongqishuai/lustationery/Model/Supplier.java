package com.example.zhongqishuai.lustationery.Model;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.HashMap;

/**
 * Created by zhongqishuai on 10/3/16.
 */
public class Supplier extends HashMap<String,String> {
    public static HashMap<Integer,Supplier> suppliers=new HashMap<Integer,Supplier>();
    public static HashMap<String,String> snames=new HashMap<String,String>();
    public static String[] Sps=new String[3];
    public Supplier(String SupplierId, String SupplierName)
    {
        put("SupplierId",SupplierId);
        put("SupplierName",SupplierName);
    }
    public static String[] getSupplier(){
        JSONArray supps= JSONParser.getJSONArrayFromUrl("http://10.10.1.139/test/Requisition.svc/getallsupplier");
        try
        {
            for (int i=0;i<supps.length();i++) {
                JSONObject supplier = supps.getJSONObject(i);
                suppliers.put(supplier.getInt("SupplierRank"),new Supplier(supplier.getString("SupplierCode"),supplier.getString("SupplierName")));
            }
        }
        catch (Exception e)
        {
        }
//        suppliers.put(1,new Supplier("ALPA","ALPHA Office"));
//        suppliers.put(3,new Supplier("BANE","BANES Shop"));
//        suppliers.put(2,new Supplier("CHEP","Cheap Stationer"));
//        suppliers.put(0,new Supplier("OMEG","OMEGA Stationery"));
        for (int i=1;i<4;i++)
        {
            Sps[i-1]=suppliers.get(i).get("SupplierName");
            snames.put(suppliers.get(i).get("SupplierName"),suppliers.get(i).get("SupplierId"));
        }

        return Sps;
    }
}
