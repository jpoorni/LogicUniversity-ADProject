package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by zhongqishuai on 3/3/16.
 */
public class Retrieval extends HashMap<String,String>{
//    private String categoryName;
//    private int categoryId;
//    private String itemName;
//    private String departmentName;
//    private int needQuantity;
//    private int actualQuantity;
//    private int categoryQuantity;
    final static String baseurl = "http://10.10.1.139/test/Service.svc";
//    public static HashMap<String, Retrieval> catelogueQtys=new HashMap<String,Retrieval>();
    public static HashMap<Integer, HashMap<String,Retrieval>> RetrievalCategories=new HashMap<Integer,HashMap<String,Retrieval>>();
    public static ArrayList<Integer> RetrievalIds=new ArrayList<Integer>();
    public Retrieval(int RetrievalId, int categoryId, String categoryName, int count)
    {
        put("RetrievalID",Integer.toString(RetrievalId));
        put("categoryId", Integer.toString(categoryId));
        put("categoryName",categoryName);
        put("count", Integer.toString(count));

    }
    public Retrieval(int RetrievalId, String itemCode, String itemDes, String departmentName, String departmentCode, int NeedQty)
    {
        put("RetrievalId",Integer.toString(RetrievalId));
        put("itemCode",itemCode);
        put("itemDes",itemDes);
        put("departmentName", departmentName);
        put("departmentCode", departmentCode);
        put("Qty", Integer.toString(NeedQty));
    }
    public static void getAllCatQty(int RetrievalId)
    {
        HashMap<String,Retrieval> tempMap=new HashMap<String,Retrieval>();
        JSONArray catqtys = JSONParser.getJSONArrayFromUrl(String.format("%s/ReNoByCategory/%s", baseurl, RetrievalId));
        try
        {
            for (int i =0; i<catqtys.length(); i++) {
              JSONObject catQty=catqtys.getJSONObject(i);
              Retrieval tempr=new Retrieval(RetrievalId,catQty.getInt("CategoryId"),catQty.getString("CategoryName"),catQty.getInt("ActualQuantity"));
              tempMap.put(catQty.getString("CategoryName"),tempr);
            }
        }catch (Exception e){
        }
//       if (RetrievalId==10005) {
//           tempMap.put("Eraser", new Retrieval(RetrievalId, 5002, "Eraser", 12));
//           tempMap.put("Pen", new Retrieval(RetrievalId, 5005, "Pen", 10));
//       }
//        else {
//           tempMap.put("Clip", new Retrieval(RetrievalId, 5000, "Clip", 10));
//       }
//        HashMap<String,Retrieval> tempMap=catelogueQtys;
        RetrievalCategories.put(RetrievalId, tempMap);
//        catelogueQtys.clear();
        Log.i("????????????????",Integer.toString(tempMap.size()));
    }

    public static List<Retrieval> getRetrievalQtyByDepartment(int CategoryId,int RetrievalId)
    {
        ArrayList<Retrieval> retrievals=new ArrayList<Retrieval>();
        JSONArray itemDepqtys = JSONParser.getJSONArrayFromUrl(String.format("%s/ReNoByDept/%s/%s", baseurl, CategoryId, RetrievalId));
//        Retrieval[]rs=new Retrieval[itemDepqtys.length()];
        try {
            for (int i=0;i<itemDepqtys.length();i++)
            {
                JSONObject itemQty=itemDepqtys.getJSONObject(i);
                Log.i("JSON Size",Integer.toString(itemDepqtys.length()));
                Log.i("JSON Object", itemQty.toString());
                Retrieval tempRetrieval=new Retrieval(RetrievalId,itemQty.getString("ItemCode"),
                        itemQty.getString("ItemDescription"),itemQty.getString("DepetName"),
                        itemQty.getString("DepartmentId"),itemQty.getInt("ActualQuantity"));
                retrievals.add(tempRetrieval);
            }
        }catch (Exception e)
        {
        }
//        Log.i("rs size",Integer.toString(rs.length));
//        Log.i("||||||||||||||||",rs[0].toString());
//        for (int j=0;j<rs.length;j++)
//        {
//            retrievals.add(rs[j]);
//        }
        Log.i("Retrievals Size",Integer.toString(retrievals.size()));
//        retrievals.add(new Retrieval(RetrievalId,"C001","Clip Red","Computer Science","CPSC",5));
//        retrievals.add(new Retrieval(RetrievalId, "C002", "Clip Blue", "Commerce Dept", "COMM", 4));
        return retrievals;
    }
    public static void getAllRetrievalId()
    {
        Log.i("I'm be done","getAllRetrievalId");
        if (RetrievalIds!=null)
        {
            RetrievalIds.clear();
        }

        JSONArray ids= JSONParser.getJSONArrayFromUrl(String.format("%s/AllRetrievalId", baseurl));
        try
        {
            for (int i =0; i<ids.length(); i++) {
              int rId=ids.getInt(i);
                Log.i("JSON Test ??????",Integer.toString(rId));
                getAllCatQty(rId);
              RetrievalIds.add(rId);
            }
        }catch (Exception e){
        }
//        RetrievalIds.add(10004);
//        RetrievalIds.add(10005);
    }
    public static void confirmRetrieval(int RetrievalId)
    {
       String result= JSONParser.getStream(String.format("%s/Confirmretrieval/%s", baseurl, RetrievalId));
    }
//
}
