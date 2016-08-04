package com.example.zhongqishuai.lustationery.DepartmentHead;

import android.app.Activity;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v4.app.Fragment;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.CollectionPointRep;
import com.example.zhongqishuai.lustationery.Model.DisbursementDetailsRep;
import com.example.zhongqishuai.lustationery.R;
import com.example.zhongqishuai.lustationery.Representative.DisbursementDetRepAdapter;

import java.util.ArrayList;

public class CollectionPoints extends Fragment {

    public CollectionPoints() {
        // Required empty public constructor
    }

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

//    @Override
//    protected void onCreate(Bundle savedInstanceState) {
//        super.onCreate(savedInstanceState);
//        setContentView(R.layout.activity_collection_points);

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View V= inflater.inflate(R.layout.activity_collection_points, container, false);

        final TextView textViewDepName = (TextView) V.findViewById(R.id.textViewDepName);
        final TextView textViewCollPnt = (TextView) V.findViewById(R.id.textViewCollPnt);

        final ImageView imageViewLocation = (ImageView) V.findViewById(R.id.imageViewLocation);

        /***hardcoded dept code***/
        String DeptCode = null;
        //DeptCode = "ZOOL";
        DeptCode = Login.departmentCode;
        /***hardcoded dept code***/

        if  (DeptCode.trim().matches("ENGL")) { imageViewLocation.setImageResource(R.drawable.english_dep);}
        if  (DeptCode.trim().matches("CPSC")) {imageViewLocation.setImageResource(R.drawable.computer_dep);}
        if  (DeptCode.trim().matches("COMM")) {imageViewLocation.setImageResource(R.drawable.commerce_dep);}
        if  (DeptCode.trim().matches("REGR")) {imageViewLocation.setImageResource(R.drawable.registrar_dep);}
        if  (DeptCode.trim().matches("ZOOL")) {imageViewLocation.setImageResource(R.drawable.zoology_dep);}


        Button btnChangeCollectionPoint = (Button) V.findViewById(R.id.buttonChange);

        final Spinner spinner2 = (Spinner) V.findViewById(R.id.spinner2);

        btnChangeCollectionPoint.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                final String selectedItem = spinner2.getSelectedItem().toString();
                int CollectionPointID = 0;

                if (selectedItem.trim().matches("Administrative Building")) { CollectionPointID = 3001; }
                if (selectedItem.trim().matches("Management School")) { CollectionPointID = 3002; }
                if (selectedItem.trim().matches("Medical School")) { CollectionPointID = 3003; }
                if (selectedItem.trim().matches("Engineering School")) { CollectionPointID = 3004; }
                if (selectedItem.trim().matches("Science School")) { CollectionPointID = 3005; }
                if (selectedItem.trim().matches("University Hospital")) { CollectionPointID = 3006; }

                final int finalCollectionPointID = CollectionPointID;

                /*** hardcoded dept id. & name Get from shared preference. Also get dept names***/
                StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
                //final CollectionPointRep c = new CollectionPointRep("ENGL", finalCollectionPointID);
                /****new****/
                final CollectionPointRep c = new CollectionPointRep(Login.departmentCode, finalCollectionPointID);
                /****new****/
                AlertDialog.Builder builder1 = new AlertDialog.Builder(getActivity());
                builder1.setMessage("Confirm new collection point?");
                builder1.setCancelable(true);

                builder1.setPositiveButton(
                        "Yes",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                String t = CollectionPointRep.changeCollectionPoint(c);
                                textViewCollPnt.setText(selectedItem);
                                Toast.makeText(getActivity(), "Collection Point changed Successfully...", Toast.LENGTH_SHORT).show();
                            }
                        });

                builder1.setNegativeButton(
                        "No",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

                AlertDialog alert11 = builder1.create();
                alert11.show();
            }
        });

        new AsyncTask<Void, Void, CollectionPointRep>() {
            @Override
            protected CollectionPointRep doInBackground(Void... params) {
                /*** hardcoded dept id. & name Get from shared preference. Also get dept names***/
                //return CollectionPointRep.getCollectionbydept("ENGL");

                /****new****/
                return CollectionPointRep.getCollectionbydept(Login.departmentCode);
                /****new****/
            }

            @Override
            protected void onPostExecute(CollectionPointRep result) {
                /*****get from shared preferences***/
                //textViewDepName.setText("English Department");
                /*****get from shared preferences***/

                /****new****/
                textViewDepName.setText(Login.departmentName);
                /****new****/

                textViewCollPnt.setText(result.get("CollectionPointName"));
            }
        }.execute();

        return V;
    }

}




