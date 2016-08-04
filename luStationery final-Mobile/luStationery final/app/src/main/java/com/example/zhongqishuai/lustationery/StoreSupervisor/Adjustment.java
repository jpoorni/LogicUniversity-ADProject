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
 * Created by student on 7/3/16.
 */
    public class Adjustment extends HashMap<String, String> {

        final static String listbaseurl = "http://10.10.1.139/test/Requisition.svc/adjustmentList/";
        final static String detailbaseurl = "http://10.10.1.139/test/Requisition.svc/adjustmentDetails/";
        final static String approve = "http://10.10.1.139/test/Service.svc/ApproveAdjust/";
        final static String reject = "http://10.10.1.139/test/Service.svc/RejectAdjustment/";
        public Adjustment(String adjustmentId, String  employeeId, String TotalAmount, String adjustDate) {
            put("adjustmentId", adjustmentId);
            put("employeeId", employeeId);
            put("totalAmount", TotalAmount);
            put("adjustDate", adjustDate);
            //put("adjustDate", adjustDate);

        }
        public Adjustment(String itemCode,String adreason,int adQty,String type){
            put("itemCode",itemCode);
            put("adreason",adreason);
            put("adQty",Integer.toString(adQty));
            put("type",type);
        }

        public static List<Adjustment> AdjustmentList(String eid) {
            List<Adjustment> list = new ArrayList<Adjustment>();
            JSONArray b = JSONParser.getJSONArrayFromUrl(listbaseurl + eid);
            Log.i("URL", listbaseurl + eid);
            try {
                for (int i = 0; i < b.length(); i++) {
                    JSONObject a = b.getJSONObject(i);
                    Adjustment R =  new Adjustment(Integer.toString(a.getInt("AdjustmentId")), Integer.toString(a.getInt("EmployeeId")),
                            Integer.toString(a.getInt("TotalAmount")),a.getString("AdjustDate"));
                    Log.i("Obj",R.toString());
                    list.add(R);

                }
            } catch (Exception e) {
                Log.e("LUS", "JSONArray error");
            }
            return (list);
        }
    public static List<Adjustment> AdjustmentDetails(String adid) {
        List<Adjustment> list = new ArrayList<Adjustment>();
        JSONArray b = JSONParser.getJSONArrayFromUrl(detailbaseurl + adid);
        Log.i("URL", detailbaseurl + adid);
        try {
            for (int i = 0; i < b.length(); i++) {
                JSONObject a = b.getJSONObject(i);
                Adjustment R =  new Adjustment(a.getString("ItemCode"), a.getString("Reason"),
                        a.getInt("AdjustmentAmount"),a.getString("Type"));
                Log.i("Obj",R.toString());
                list.add(R);

            }
        } catch (Exception e) {
            Log.e("LUS", "JSONArray error");
        }
        return (list);
    }
    public static void Approve(String aid){
        //URL a = new URL(approve+aid);
        String url =approve+aid;
//        Intent i =new Intent(Intent.ACTION_VIEW);
//        i.setData(Uri.parse(url));
        String s = JSONParser.getStream(url);
    }
     public static void Reject(String aid){
         String url = reject+aid;
         String s = JSONParser.getStream(url);
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
