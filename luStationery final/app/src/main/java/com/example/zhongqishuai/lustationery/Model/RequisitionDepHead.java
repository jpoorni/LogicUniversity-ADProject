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
public class RequisitionDepHead extends HashMap<String, String> {

    final static String Rbaseurl = "http://10.10.1.139/test/Requisition.svc/Viewemployee/";
    final static String baseurl = "http://10.10.1.139/test";

    public RequisitionDepHead(String requisitionId, String employeeId, String employeeName, String requisitionDate, String statusDescription) {
        put("requisitionId", requisitionId);
        put("employeeId", employeeId);
        put("employeeName", employeeName);
        put("requisitionDate", requisitionDate);
        put("statusDesription", statusDescription);

    }


    public static List<RequisitionDepHead> RequisitionList(String dept) {
        List<RequisitionDepHead> list = new ArrayList<RequisitionDepHead>();
        JSONArray b = JSONParser.getJSONArrayFromUrl(Rbaseurl + dept);
        Log.i("URL", Rbaseurl + dept);
        try {
            for (int i = 0; i < b.length(); i++) {
                JSONObject a = b.getJSONObject(i);

                RequisitionDepHead R = new RequisitionDepHead(Integer.toString(a.getInt("RequisitionId")), Integer.toString(a.getInt("EmployeeID")),
                        a.getString("EmployeeName"),a.getString("RequisitionDate"),
                        a.getString("StatusDescription"));
                Log.i("Obj", R.toString());
                list.add(R);

            }
        } catch (Exception e) {
            Log.e("RequisitionList", "JSONArray error");
        }
        return (list);
    }

//    final static String imageURL = "http://10.10.1.198/nusfinder/images";
//
//    public static Bitmap getPhoto(boolean thumbnail, String faculty) {
//        try {
//            // faculty=faculty.replace(" ","");
//            Log.i("path", String.format("%s/%s.jpg", imageURL, faculty));
//
//            URL url = (thumbnail ? new URL(String.format("%s/%s.jpg", imageURL, faculty)) :
//                    new URL(String.format("%s/%s.jpg", imageURL, faculty)));
//
//            URLConnection conn = url.openConnection();
//            InputStream ins = conn.getInputStream();
//            Bitmap bitmap = BitmapFactory.decodeStream(ins);
//            ins.close();
//            return bitmap;
//        } catch (Exception e) {
//            Log.e("Employee.getPhoto()", "JSONArray error");
//        }
//        return (null);
//    }

    public static String approveRequisition(RequisitionDepHead r) {
        try {
//            Log.i("Start",r.toString());
            JSONObject Req = new JSONObject();
//            Log.i("!!!ID",r.get("requisitionId"));
            Req.put("RequisitionId", Integer.parseInt(r.get("requisitionId")));
//            Req.put("EmployeeID", Integer.parseInt(r.get("employeeId")));
            Req.put("EmployeeID", Integer.parseInt("0"));
            Req.put("EmployeeName", r.get("employeeName"));
            Req.put("RequisitionDate", r.get("requisitionDate"));
            Req.put("StatusDescription", r.get("statusDesription"));
            String json = Req.toString();
            String result = JSONParser.postStream(
                    String.format("%s/Requisition.svc/ApproveRequisition", baseurl),
                    json);
            Log.i("Json result",result.toString());
        } catch (Exception e) {
            Log.e("updateProduct", "JSON error");
        }
        return (null);
    }

}


