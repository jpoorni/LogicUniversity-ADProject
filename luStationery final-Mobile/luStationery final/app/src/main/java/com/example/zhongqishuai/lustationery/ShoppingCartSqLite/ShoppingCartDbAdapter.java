package com.example.zhongqishuai.lustationery.ShoppingCartSqLite;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.util.Log;

/**
 * Created by zhongqishuai on 20/1/16.
 */
public class ShoppingCartDbAdapter {
    public static final String KEY_ROWID = "_id";
    public static final String KEY_Item_Code = "ItemCode";
    public static final String KEY_Item = "ItemDesc";
    public static final String KEY_Quantity= "Quantity";
    public static final String KEY_Supplier="Supplier";
    public static final String KEY_UserID="UserId";
    private static final String DATABASE_TABLE = "ShoppingCart";
    private Context context;
    private SQLiteDatabase database;
    private ShoppingCartDatabaseHelper dbHelper;

    public ShoppingCartDbAdapter(Context context) {
        this.context = context;
    }

    public ShoppingCartDbAdapter open() throws SQLException {
        dbHelper = new ShoppingCartDatabaseHelper(context);
        database = dbHelper.getWritableDatabase();
        return this;
    }

    public void close() {
        dbHelper.close();
    }

    public long createShoppingCartItem(String itemCode,String itemDesc,int quantity,String supplier,int UserID) {
        ContentValues initialValues = createContentValues(itemCode,itemDesc,quantity,supplier,UserID);
        long row = database.insert(DATABASE_TABLE, null, initialValues);
        Log.i("DATABASE", Long.toString(row));
        return row;
    }

    public boolean updateCustomer(long rowId, String itemCode,String itemDesc,int quantity,String supplier,int UserID) {
        ContentValues updateValues = createContentValues(itemCode,itemDesc,quantity,supplier,UserID);

        return database.update(DATABASE_TABLE, updateValues, KEY_ROWID + "="
                + rowId, null) > 0;
    }

    public boolean deleteCustomer(long rowId) {
        return database.delete(DATABASE_TABLE, KEY_ROWID + "=" + rowId, null) > 0;
    }

    public Cursor fetchAllCustomers(String supplier,int UserId) {
        return database.query(true,DATABASE_TABLE, new String[] { KEY_ROWID,
                        KEY_Item_Code,KEY_Item,KEY_Quantity },
               KEY_Supplier+" = ? and "+KEY_UserID+" = ?",new String[]{supplier, Integer.toString(UserId)}, null,null,null, null);
    }

//    public Cursor fetchCustomer(long rowId) throws SQLException {
//        Cursor mCursor = database.query(true, DATABASE_TABLE, new String[] {
//                        KEY_ROWID, KEY_NAME, KEY_COMPANY, KEY_ADDRESS, KEY_CREDITLIMIT },
//                KEY_ROWID + "=?", new String[] { Long.toString(rowId) } ,
//                null, null, null, null);
//        if (mCursor != null)
//            mCursor.moveToFirst();
//        return mCursor;
//    }

    private ContentValues createContentValues(String itemCode,String itemDesc,int quantity,String supplier,int UserID) {
        ContentValues values = new ContentValues();
        values.put(KEY_Item_Code, itemCode);
        values.put(KEY_Item,itemDesc);
        values.put(KEY_Quantity, quantity);
        values.put(KEY_Supplier,supplier);
        values.put(KEY_UserID,UserID);
        return values;
    }

}

