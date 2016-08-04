package com.example.zhongqishuai.lustationery.DepartmentHead;


import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import com.example.zhongqishuai.lustationery.R;

/**
 * A simple {@link Fragment} subclass.
 */
public class dhView extends Fragment {


    public dhView() {
        // Required empty public constructor
    }

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        return inflater.inflate(R.layout.fragment_dh_view, container, false);
    }

}
