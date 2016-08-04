package com.example.zhongqishuai.lustationery.Model;

import java.util.List;
import java.util.Vector;

/**
 * Created by student on 6/3/16.
 */
public class ShoppingCart {

        private int sqliteid;
        private String itemCode;
        private String ItemDescription;
        private int itemQuantity;
        private static List<ShoppingCart> cart;

    public ShoppingCart() {

    }

        public ShoppingCart(String ItemDescription, int itemQuantity, String itemCode) {
            this.ItemDescription= ItemDescription;
            this.itemCode = itemCode;
            this.itemQuantity = itemQuantity;
        }
    public ShoppingCart(int sqliteid,String itemCode, String itemDesc,int itemQuantity)
    {
        this.sqliteid=sqliteid;
        this.itemCode=itemCode;
        this.ItemDescription=itemDesc;
        this.itemQuantity=itemQuantity;
    }
    public int getSqliteid(){ return sqliteid;}
        public String getItemCode() {
            return itemCode;
        }

    public String getItemDescription() {
        return ItemDescription;
    }

        public int getItemQuantity() {
            return itemQuantity;
        }

    //Setter

        public void setItemQuantity(int itemQuantity) {
            this.itemQuantity = itemQuantity;
        }

    public void setItemCode(String itemCode) {
        this.itemCode = itemCode;
    }

    public void setItemDescription(String ItemDescription) {
        this.ItemDescription = ItemDescription;
    }

    public static List<ShoppingCart> getCart() {
        if(cart == null) {
            cart = new Vector<ShoppingCart>();
        }

        return cart;
    }



    }



