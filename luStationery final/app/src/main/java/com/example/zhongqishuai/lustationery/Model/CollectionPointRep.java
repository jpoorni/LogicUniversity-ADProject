package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONArray;
import org.json.JSONObject;
import java.util.HashMap;

/**
 * Created by student on 11/3/16.
 */
public class CollectionPointRep extends HashMap<String,String> {

    final static String baseURL = "http://10.10.1.139/test/Requisition.svc/getCollectionbydept";

    public CollectionPointRep(String CollectionPointName, String CollectionPointDescription, String CollectionPointId) {
        put("CollectionPointName", CollectionPointName);
        put("CollectionPointDescription", CollectionPointDescription);
        put("CollectionPointId", CollectionPointId);
    }

    public CollectionPointRep(String DepartmentCode, int CollectionPointId) {
        put("DepartmentCode", DepartmentCode);
        put("CollectionPointId", Integer.toString(CollectionPointId));
    }

    public static CollectionPointRep getCollectionbydept(String depId) {
        JSONObject b = JSONParser.getJSONFromUrl(baseURL + "/" + depId);
        try {
            return new CollectionPointRep(b.getString("CollectionPointName"), b.getString("CollectionPointDescription"), Integer.toString(b.getInt("CollectionPointId")));
        } catch (Exception e) {
            Log.e("getCollectionbydept()", "JSONobject error");
        }
        return (null);
    }

    public static String changeCollectionPoint(CollectionPointRep c) {
        try {
            JSONObject Coll = new JSONObject();
            Log.i("new coll det", c.toString());
            Coll.put("CollectionPointId", c.get("CollectionPointId"));
            Coll.put("DepartmentCode", c.get("DepartmentCode"));
            String json = Coll.toString();
            String result = JSONParser.postStream(
                    String.format("http://10.10.1.139/test/Requisition.svc/ChangeCollectionPoint"), json);
            Log.i("Json result", result.toString());

        } catch (Exception e) {
            Log.e("Collection Point", "JSON error");
        } return (null);
    }

}

