package com.example.zhongqishuai.lustationery;

/**
 * Created by zhongqishuai on 25/01/16.
 */
import java.io.PrintWriter;
import java.io.StringWriter;

public class StackTrace {
    public static String trace(Exception ex) {
        StringWriter outStream = new StringWriter();
        ex.printStackTrace(new PrintWriter(outStream));
        return outStream.toString();
    }
}
