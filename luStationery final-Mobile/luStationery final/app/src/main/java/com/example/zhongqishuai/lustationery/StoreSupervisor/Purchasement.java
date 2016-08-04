package com.example.zhongqishuai.lustationery.StoreSupervisor;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;

import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * Created by student on 9/3/16.
 */
public class Purchasement extends HashMap<String, String> {
    final static String listbaseurl = "http://10.10.1.139/test/Requisition.svc/purchaseorderlist/";
    final static String detailbaseurl = "http://10.10.1.139/test/Requisition.svc/purchaseorderdetails/";
    final static String changurl = "http://10.10.1.139/test/Service.svc/ChangeStatus/";
    public Purchasement(int purchaseorderno,String purchaseDate,int totalAmount)
    {
        put("Purchaseorderno",Integer.toString(purchaseorderno));
        put("purchaseDate",purchaseDate);
        put("TotalAmount",Integer.toString(totalAmount));
    }

    public Purchasement(String itemCode,int orderedQuantity,int price,int amount)
    {
        put("ItemCode",itemCode);
        put("OrderedQuantity",Integer.toString(orderedQuantity));
        put("Price",Integer.toString(price));
        put("Amount",Integer.toString(amount));
    }
    public static List<Purchasement> PurchasementList(String eid) {
        List<Purchasement> list = new ArrayList<Purchasement>();
        JSONArray b = JSONParser.getJSONArrayFromUrl(listbaseurl + eid);
        Log.i("URL", listbaseurl + eid);
        try {
            for (int i = 0; i < b.length(); i++) {
                JSONObject a = b.getJSONObject(i);
                Purchasement R =  new Purchasement(a.getInt("Purchaseorderno"), a.getString("PurchaseDate"),
                        a.getInt("TotalAmount"));
                Log.i("Obj",R.toString());
                list.add(R);

            }
        } catch (Exception e) {
            Log.e("LUS", "JSONArray error");
        }
        return (list);
    }

    public static List<Purchasement> PurchasementDetails(String pid)
    {
        List<Purchasement> list = new ArrayList<Purchasement>();
        JSONArray b = JSONParser.getJSONArrayFromUrl(detailbaseurl + pid);
        Log.i("URL", detailbaseurl + pid);
        try {
            for (int i = 0; i < b.length(); i++) {
                JSONObject a = b.getJSONObject(i);
                Purchasement R =  new Purchasement(a.getString("ItemCode"), a.getInt("OrderedQuantity"),
                        a.getInt("Price"),a.getInt("Amount"));
                Log.i("Obj",R.toString());
                list.add(R);

            }
        } catch (Exception e) {
            Log.e("LUS", "JSONArray error");
        }
        return (list);
    }

    public static void ChangeStatus(String poId,String status)
    {
        String url = String.format("%s/%s/%s", changurl, poId,status) ;
        Log.e("WHY wwwww",url);
        String result = JSONParser.getStream(url);
    }

    final static String imageURL = "http://10.10.1.139/test/images/";

    public static Bitmap getPhoto(String icode) {
        try {
            // faculty=faculty.replace(" ","");
            //Log.i("path", String.format("%s/%s.jpg", imageURL, faculty));

            //URL url = (thumbnail ? new URL(String.format("%s/%s.jpg", imageURL, faculty)) :
            //new URL(String.format("%s/%s.jpg", imageURL, faculty)));
            URL url = new URL(imageURL+icode+".jpg");
            URLConnection conn = url.openConnection();
            InputStream ins = conn.getInputStream();
            Bitmap bitmap = BitmapFactory.decodeStream(ins);
            ins.close();
            return bitmap;
        } catch (Exception e) {
            Log.e("Employee.getPhoto()", "Picture error");
        }
        return (null);
    }
}
