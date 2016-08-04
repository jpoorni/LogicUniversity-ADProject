package com.example.zhongqishuai.lustationery.Model;

import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;
import com.example.zhongqishuai.lustationery.Login;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.InputStream;
import java.net.URL;
import java.net.URLConnection;
import java.text.DecimalFormat;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

public class DisbursementDetailsRep extends HashMap<String, String> {
    final static String baseURL = "http://10.10.1.139/test/Service.svc/DisbursementDetailsListforMobile";
    //    final static String getMovieURL = "http://10.10.1.149/moviebooking/service.svc/GetMovie";
    final static String imageURL ="http://10.10.1.139/test/image";
    final static String confirmURL = "http://10.10.1.139/test/Service.svc/confirmDisbursement";

    public DisbursementDetailsRep(String ItemDes, String ReqQty, String ReceivedQuantity) {
        put("ItemDes",ItemDes);
        put("ReqQty",ReqQty);
        put("ReceivedQuantity",ReceivedQuantity);
    }
    public DisbursementDetailsRep(String departmentCode,int disId,String itemCode,int receivedQty,int adjustmentQty,String type,String reason,String clerkName)
    {
        put("departmentCode",departmentCode);
        put("disId",Integer.toString(disId));
        put("itemCode",itemCode);
        put("receivedQty",Integer.toString(receivedQty));
        put("adjustmentQty",Integer.toString(adjustmentQty));
        put("type",type);
        put("reason",reason);
        put("clerkName",clerkName);

    }


    public static String CreateDisbursement(DisbursementDetailsRep r) {
        try {
            JSONObject Coll = new JSONObject();
//                Log.i("new coll det", r.toString());
            Coll.put("DepartmentCode", r.get("departmentCode"));
            Coll.put("DisbursementId", Integer.parseInt(r.get("disId")));
            Coll.put("ItemDescription", r.get("itemCode"));
            Coll.put("ReceivedQuantity", Integer.parseInt(r.get("receivedQty"))) ;
            Coll.put("AdjustmentQuantity", Integer.parseInt(r.get("adjustmentQty")));
            Coll.put("Type", r.get("type"));
            Coll.put("Reason", r.get("reason"));
            Coll.put("UserId", r.get("clerkName"));

            Log.i("Json result", Coll.toString());
            String json = Coll.toString();
            String result = JSONParser.postStream(
                    String.format("http://10.10.1.139/test/Requisition.svc/updateDisbursement"), json);
            Log.i("Json result", result.toString());

        } catch (Exception e) {
            Log.e("Collection Point", "JSON error");
        } return (null);
    }



    public static ArrayList<DisbursementDetailsRep> getDisDetForId(String disId) {

        ArrayList<DisbursementDetailsRep> DisDetlist = new ArrayList<DisbursementDetailsRep>();
        try {
            JSONArray a = JSONParser.getJSONArrayFromUrl(baseURL + "/" + disId);
            for (int i =0; i<a.length(); i++) {
                JSONObject b = a.getJSONObject(i);
                DisDetlist.add(new DisbursementDetailsRep(b.getString("ItemDes"),b.getString("ReqQty"),b.getString("ReceivedQuantity")));
            }
        }
        catch (Exception e) {
            Log.e("getAllDisForDep()", "JSONArray error");
        }
//        DisDetlist.add(new DisbursementDetailsRep("envelope","100","100"));
//        DisDetlist.add(new DisbursementDetailsRep("eraser","10","10"));
        return DisDetlist;
    }

    public static Bitmap getPhoto(boolean thumbnail, String mid) {
        try {
            URL url = (thumbnail ? new URL(String.format("%s/small-%s.jpg",imageURL, mid)) :
                    new URL(String.format("%s/%s.jpg",imageURL, mid)));
            URLConnection conn = url.openConnection();
            InputStream ins = conn.getInputStream();
            Bitmap bitmap = BitmapFactory.decodeStream(ins);
            ins.close();
            return bitmap;
        } catch (Exception e) {
            Log.e("DisDet.getPhoto()", "JSONArray error");
        }
        return(null);
    }

    public static void ConfirmDisbursement(String disId,String deptcode){
        //URL a = new URL(approve+aid);
        String url =confirmURL+"/"+disId+"/"+deptcode;
        String s = JSONParser.getStream(url);
    }
}
