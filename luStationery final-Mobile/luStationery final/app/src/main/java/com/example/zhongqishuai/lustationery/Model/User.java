package com.example.zhongqishuai.lustationery.Model;

import com.example.zhongqishuai.lustationery.JSONParser;

import org.json.JSONObject;

/**
 * Created by zhongqishuai on 2/3/16.
 */
public class User {
//    private String userName;
//    private String password;
    private int role;
    private int userId;
    private String departmentCode;
    private String departmentName;
    final static String baseurl = "http://10.10.1.139/test/Requisition.svc";

//    public User(String userName, String password){
//        this.userName=userName;
//        this.password=password;
//    }
    public User(int userRole, int userId, String departmentCode, String departmentName)
    {
        this.role=userRole;
        this.userId=userId;
        this.departmentCode=departmentCode;
        this.departmentName=departmentName;
    }

    public User(int userRole)
    {
        this.role=userRole;
    }
    public int getRole() {
        return role;
    }

    public int getUserId() {
        return userId;
    }

    public String getDepartmentName() {
        return departmentName;
    }

    public String getDepartmentCode()
    {
        return departmentCode;
    }

    public static User getUser(String userName,String password)
    {
        String newname=userName.replace(" ", "%20");
        try {
            JSONObject user= JSONParser.getJSONFromUrl(String.format("%s/Login/%s/%s", baseurl, newname, password));
            if (user==null)
            {
                return new User(0);
            }
            else {
                return new User(user.getInt("RoleId"), user.getInt("UserId"), user.getString("DepartmentCode"),user.getString("DepartmentName"));
            }
        }
        catch( Exception e) {
    }
        return null;
    }
}
