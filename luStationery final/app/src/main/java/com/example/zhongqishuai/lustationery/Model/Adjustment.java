package com.example.zhongqishuai.lustationery.Model;

import android.util.Log;

import com.example.zhongqishuai.lustationery.JSONParser;
import com.example.zhongqishuai.lustationery.Login;

import org.json.JSONObject;

/**
 * Created by zhongqishuai on 8/3/16.
 */
public class Adjustment {
    private static String baseUrl="http://10.10.1.139/test/Requisition.svc/ChangeRetrieval";
    public static void makeAdjustment(String itemCode, int adjustQty,String reason,int RetrievalId,  String departmentCode,
                                      int actualQty)
    {
        Log.i("See ItemCode",itemCode);
        JSONObject RetrievalChange=new JSONObject();
        try
        {
            RetrievalChange.put("ItemCode",itemCode);
            RetrievalChange.put("AdjustmentQuantity",adjustQty);
            RetrievalChange.put("Type","AdjustOut");
            RetrievalChange.put("Reason",reason);
            RetrievalChange.put("RetrievalId",RetrievalId);
            RetrievalChange.put("DepartmentCode",departmentCode);
            RetrievalChange.put("ActualQuantity",actualQty);
            Log.i("UserId lalalalalala", Integer.toString(Login.userID));
            RetrievalChange.put("UserId", Login.userID);
            Log.i("See the post object!!!", RetrievalChange.toString());
        }
        catch (Exception e)
        {
            Log.e("JSON Post Error",e.toString());
        }

        String result= JSONParser.postStream(baseUrl, RetrievalChange.toString());
        Log.i("see post Result!!!!!!!!",result);
    }
}
