package com.example.zhongqishuai.lustationery.StoreManager;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.webkit.WebViewClient;

import com.example.zhongqishuai.lustationery.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class SMReportFragment extends Fragment {


    public SMReportFragment() {
        // Required empty public constructor
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
            View view = inflater.inflate(R.layout.fragment_smreport, container, false);
           // Bundle arg = getArguments();
            //if (arg != null) {
               // String url = arg.getString("url");

                //if (url != null) {
                    WebView webView = (WebView) view.findViewById(R.id.webView);
                    webView.getSettings().setJavaScriptEnabled(true);
                    webView.setWebViewClient(new WebViewClient() {
                        @Override
                        public boolean shouldOverrideUrlLoading(WebView v, String u) {
                            v.loadUrl(u);
                            return false;
                        }
                    });
                    webView.loadUrl("");//put url here
                //}
           // }
            return (view);
        }
}
