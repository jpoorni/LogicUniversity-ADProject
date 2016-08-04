package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by zhongqishuai on 9/3/16.
 */
public class PurchaseOrder  extends HashMap{
    final static String baseurl = "http://10.10.1.139/test/Service.svc";
    public static ArrayList<Integer> PurchaseOrderIds=new ArrayList<Integer>();
    public static HashMap<Integer, ArrayList<com.example.zhongqishuai.lustationery.Model.PurchaseOrder>> PurchaseOrder=new HashMap<Integer,ArrayList<com.example.zhongqishuai.lustationery.Model.PurchaseOrder>>();
    public PurchaseOrder(int pdetailId,String itemDes,int orderQty)
    {
        put("pdetailId",pdetailId);
        put("itemDes",itemDes);
        put("orderQty", orderQty);
    }
    public static void getPurchaseOrderIds()
    {
        if (PurchaseOrderIds.size()>0)
        {
            PurchaseOrderIds.clear();
        }
        JSONArray poids = JSONParser.getJSONArrayFromUrl(String.format("%s/getPOIds", baseurl));
        try
        {
            for (int i =0; i<poids.length(); i++) {
              int id=poids.getInt(i);
                PurchaseOrderIds.add(id);
            }
        }catch (Exception e){
        }
//        PurchaseOrderIds.add(9002);
    }
    public static void getPurchaseOrderDetails(int POId)
    {
        JSONArray podetails= JSONParser.getJSONArrayFromUrl(String.format("%s/POdetails/%s", baseurl, POId));
        ArrayList<com.example.zhongqishuai.lustationery.Model.PurchaseOrder> tempPO=new ArrayList<>();
        try {
            for (int i=0;i<podetails.length();i++)
            {
                JSONObject poDetail=podetails.getJSONObject(i);
                tempPO.add(new PurchaseOrder(poDetail.getInt("PurchaseDetail_Id"),poDetail.getString("Itemdesp"),
                        poDetail.getInt("OrderedQuantity")));
            }
        }
        catch (Exception e)
        {
        }
//        if (POId==9002)
//        {
//           tempPO.add(new PurchaseOrder(12345,"Whopper",30));
//        }
        PurchaseOrder.put(POId,tempPO);
    }
    public static void changePODetail(int PodId,int receiveQty)
    {
        Log.i("see the PodId???????",Integer.toString(PodId));
        String result= JSONParser.getStream(String.format("%s/ChangePODetails/%s/%s", baseurl, PodId, receiveQty));
        Log.i("Come to see result", result);
    }
    public static void confirmPO(int poid)
    {
        String result= JSONParser.getStream(String.format("%s/ConfirmPOStatus/%s", baseurl, poid));
        Log.i("see the result",result);
    }
    public static void rejectPO(int poid)
    {
        String result= JSONParser.getStream(String.format("%s/RejectPOStatus/%s", baseurl, poid));
        Log.i("see the result",result);
    }
    public static void createPo(List<ShoppingCart> cart, String supplierCode, Integer userId)
    {
        JSONArray purchaseorder=new JSONArray();

        try {

            for (int i = 0; i < cart.size(); i++) {
                JSONObject podetail=new JSONObject();
                podetail.put("ItemCode", cart.get(i).getItemCode());
                Log.i("itemcode !!!!!!!!",cart.get(i).getItemCode());
                podetail.put("OrderedQuantity",cart.get(i).getItemQuantity());
                podetail.put("SupplierCode",supplierCode);
                podetail.put("UserId",userId);
                purchaseorder.put(i,podetail);
            }
        }
        catch (Exception e)
        {
            Log.e("Error in creating po",e.toString());
        }
        Log.i("see the list",purchaseorder.toString());
        String result= JSONParser.postStream(String.format("%s/CreatePO", baseurl), purchaseorder.toString());
    }
}
