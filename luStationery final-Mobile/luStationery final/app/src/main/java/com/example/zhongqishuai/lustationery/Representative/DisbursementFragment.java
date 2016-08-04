package com.example.zhongqishuai.lustationery.Representative;

import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v4.app.Fragment;
import android.support.v4.app.FragmentManager;
import android.support.v4.app.FragmentTransaction;
import android.support.v7.app.AlertDialog;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.Spinner;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.CollectionPointRep;
import com.example.zhongqishuai.lustationery.Model.DisbursementDetailsRep;
import com.example.zhongqishuai.lustationery.Model.DisbursementRep;
import com.example.zhongqishuai.lustationery.Model.Retrieval;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;
import java.util.List;


public class DisbursementFragment extends Fragment implements AdapterView.OnItemSelectedListener, View.OnClickListener {

    ArrayList<String> ids = new ArrayList<String>();;
    String selectedId;
    ArrayAdapter<String> dataAdapter;
    ArrayAdapter<String> dataAdapterClerk;
    Button btnConfirm;
    DisbursementRep disbursementRep;
    String ClerkName;
    Spinner spinner;

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment

        final View v = inflater.inflate(R.layout.fragment_disbursement, container, false);

//        GetDisId(v);

        btnConfirm = (Button) v.findViewById(R.id.btnConfirm);
        new AsyncTask<Void, Void, List<String>>() {
            @Override
            protected List<String> doInBackground(Void... params) {
//                return  disbursementRep.getAllDisForDep("COMM");
                /****new***/
                return  disbursementRep.getAllClerk();
                /****new***/
            }

            @Override
            protected void onPostExecute(List<String> result) {

//                Log.i("&&&&Dis list&&&&&&",Integer.toString(result.size()));
                // Spinner element
                Spinner spinnerClerk = (Spinner) v.findViewById(R.id.spinnerClerk);

                // Spinner click listener
                spinnerClerk.setOnItemSelectedListener(DisbursementFragment.this);

                // Creating adapter for spinner
                dataAdapterClerk = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, result);

                // Drop down layout style - list view with radio button
                dataAdapterClerk.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

                // attaching data adapter to spinner
                spinnerClerk.setAdapter(dataAdapterClerk);
                ClerkName = result.get(0);
                Log.i("clerk name!!!",ClerkName);
            }
        }.execute();
        new AsyncTask<Void, Void, List<Integer>>() {
            @Override
            protected List<Integer> doInBackground(Void... params) {
                /****new***/
                return  disbursementRep.getAllDisForDep(Login.departmentCode);
                //return  disbursementRep.getAllDisForDep("COMM");
                /****new***/
            }

            @Override
            protected void onPostExecute(List<Integer> result) {

//                Log.i("&&&&Dis list&&&&&&",Integer.toString(result.size()));
                // Spinner element
                for (int i=0;i<result.size();i++)
                {
                    ids.add(Integer.toString(result.get(i)));
                }
                Log.i("spinner size", String.valueOf(ids.size()));
                if (ids.size()==0) {
                    btnConfirm.setEnabled(false);
                } else {
                    btnConfirm.setEnabled(true);
                }

                spinner = (Spinner) v.findViewById(R.id.spinner);

                // Spinner click listener
                spinner.setOnItemSelectedListener(DisbursementFragment.this);

                // Creating adapter for spinner
                dataAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, ids);

                // Drop down layout style - list view with radio button
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

                // attaching data adapter to spinner
                spinner.setAdapter(dataAdapter);

            }
        }.execute();


        //For adding clerk names


        btnConfirm.setOnClickListener(DisbursementFragment.this);
        return v;
    }


    @Override
    public void onClick(final View v) {
//
        AlertDialog.Builder builder1 = new AlertDialog.Builder(getActivity());
        builder1.setMessage("Confirm This Disbursement?");
        builder1.setCancelable(true);

        builder1.setPositiveButton(
                "Yes",
                new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int id) {
//                        StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
                        new AsyncTask<Void,Void,String>() {
                            @Override
                            protected String doInBackground(Void... params) {
                                if (DisbursementDetailsFragment.rs.size() > 0) {
                                    String[] rsdes = DisbursementDetailsFragment.rs.keySet().toArray(new String[DisbursementDetailsFragment.rs.size()]);
                                    for (int i = 0; i < rsdes.length; i++) {
                                        DisbursementDetailsRep.CreateDisbursement(DisbursementDetailsFragment.rs.get(rsdes[i]));
                                    }
                                }
                                return selectedId;
                            }

                            @Override
                            protected void onPostExecute(String sid) {
                                //Calling the server to referesh the disbursement list *****/
                                DisbursementDetailsRep.ConfirmDisbursement(sid, Login.departmentCode);
                                FrameLayout layout = (FrameLayout) getActivity().findViewById(R.id.disbursementDetailsFrame);
                                layout.removeAllViews();
                                if (ids.size() > 1) {
                                    int index = ids.lastIndexOf(sid);
                                    Log.i("index!!!!!!", Integer.toString(index));
                                    Log.i("selectedId !!!!!!", sid);
                                    ids.remove(sid);
//                                Log.i("````````````", Integer.toString(ids.size()));
                                    if (index >= ids.size()) {
//                                displayDisDetList(Integer.toString(Integer.parseInt(ids.get(index - 1))));
                                        Log.i("index!!!!!!", Integer.toString(index - 1));
                                    } else {
                                        Log.i("index!!!!!!", Integer.toString(index));
//                                displayDisDetList(Integer.toString(Integer.parseInt(ids.get(index))));
                                    }
                                    dataAdapter.notifyDataSetChanged();
                                } else {
                                    ids.remove(0);
                                    spinner.setEnabled(false);
                                    btnConfirm.setEnabled(false);
                                    //ids.add("NO RETRIEVAL");
                                    //Toast.makeText(getActivity(), "You have NO NEW Retrievals", Toast.LENGTH_SHORT).show();
                                    dataAdapter.notifyDataSetChanged();
                                    v.setEnabled(false);
                                }
                            }
                        }.execute();
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

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {


        switch (parent.getId()){
            case R.id.spinnerClerk:
                ClerkName = parent.getSelectedItem().toString();
                // Reason = parent.getSelectedItem().toString();
//                Toast.makeText(getActivity(), Reason, Toast.LENGTH_LONG).show();
                break;
            case R.id.spinner:
                // On selecting a spinner item
                String item = parent.getItemAtPosition(position).toString();

                // Showing selected spinner item
                if (item == "No Disbursement") {
                    btnConfirm.setEnabled(false);
                }
                else {
                    Toast.makeText(parent.getContext(), "Selected: " + item, Toast.LENGTH_SHORT).show();
                    selectedId = item;
                    displayDisDetList(selectedId,ClerkName);
                }
                break;


        }
    }


    public void onNothingSelected(AdapterView<?> arg0) {
        // TODO Auto-generated method stub
    }

    void displayDisDetList(String disId, String clerkName) {
        final String TAG = "DisbursementDetails";
        FragmentManager fm = getFragmentManager();
        FragmentTransaction trans = fm.beginTransaction();

        Fragment frag = new DisbursementDetailsFragment();
        Bundle args = new Bundle();
        args.putSerializable("disId", disId);
        args.putSerializable("ClerkName", clerkName);
//        Log.i("Clerk Name!!!!",ClerkName);
        frag.setArguments(args);
        if (fm.findFragmentByTag(TAG) == null) {
            // fragment not found -- to be added
//            Log.i("1234---", "not found fragment");
            trans.add(R.id.disbursementDetailsFrame, frag, TAG);
        }
        else {
            // fragment found -- to be replaced
//            Log.i("abcd---", "found fragment");
            trans.replace(R.id.disbursementDetailsFrame, frag, TAG);
        }
        trans.commit();
    }






    void GetDisId(final View v)
    { }

}