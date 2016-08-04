package com.example.zhongqishuai.lustationery.Model;

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
 * Created by student on 5/3/16.
 */
public class Item extends HashMap<String, String> {
    final static String baseURL = "http://10.10.1.139/test/Requisition.svc/getItemsByCategory";
    final static String imageURL ="http://10.10.1.139/test/images";

//    public Item(String itemCode, String categoryId, String itemDescription, String quantity,String Photos) {
//        put("itemCode",itemCode);
//        put("categoryId",categoryId);
//        put("itemDescription",itemDescription);
//        put("quantity",quantity);
//        put("Photos",Photos);
//    }

    public Item(String CategoryId, String ItemDescription,String Photos,String Uom,String Itemcode,String ImageUrl) {
        put("CategoryId",CategoryId);
        put("ItemDescription",ItemDescription);
        put("Photos",Photos);
        put("Uom",Uom);
        put("Itemcode",Itemcode);
        put("ImageUrl",ImageUrl);
    }

    //List item by Category
    public static List<Item> getItemList(String mid) {
        Log.i("code------", mid);
        List<Item> list = new ArrayList<>();
        try {
            JSONArray a = JSONParser.getJSONArrayFromUrl(baseURL + "/" +mid);
            for (int i =0; i<a.length(); i++) {
                JSONObject b = a.getJSONObject(i);
                String imageUrl = imageURL+"/"+b.getString("Photos");
                list.add(new Item(b.getString("CategoryId"),
                                b.getString("ItemDescription"),
                                b.getString("Photos"),
                                b.getString("Uom"),
                                b.getString("Itemcode"),
                                imageUrl)
                );
            }
        }
            catch (Exception e) {
            Log.e("getItem.list()", "JSONArray error");
        }
        Log.i("items", Integer.toString(list.size()));
        return(list);
    }

    public static Bitmap getPhoto(String photoID) {
        try {
//            URL url = (thumbnail ? new URL(String.format("%s/small-%s",imageURL, photoID)) :
//                    new URL(String.format("%s/%s",imageURL, photoID)));
            URL url = new URL(photoID);
//            Log.i("item pic",url.toString());
            URLConnection conn = url.openConnection();
            InputStream ins = conn.getInputStream();
            Bitmap bitmap = BitmapFactory.decodeStream(ins);
            ins.close();
            return bitmap;
        } catch (Exception e) {
            Log.e("Item.getPhoto()", "JSONArray error");
        }
        return(null);
    }
    public static Integer getDefaultReorderQty(String itemCode)
    {
        String item=JSONParser.getStream("http://10.10.1.139/test/Service.svc/DefaultReorderQuantity/" + itemCode);
        int quantity=0;
        try
        {
            Log.i("see the quantity!!!!!",item);
            Log.i("see the length of qty",Integer.toString(item.length()));
            quantity=Integer.parseInt(item.substring(0,item.length()-1));
        }
        catch (Exception e)
        {
            Log.e("JSON Error!",e.toString());
        }
        return quantity;
    }


}
