package com.example.zhongqishuai.lustationery.Representative;


import android.annotation.TargetApi;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Employee.CustomAdapter;
import com.example.zhongqishuai.lustationery.Employee.ItemDetails;
import com.example.zhongqishuai.lustationery.Employee.ItemRequestAdapter;
import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.DisbursementDetailsRep;
import com.example.zhongqishuai.lustationery.Model.Item;
import com.example.zhongqishuai.lustationery.Model.ShoppingCart;
import com.example.zhongqishuai.lustationery.R;

import org.w3c.dom.Text;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class DisbursementDetailsFragment extends Fragment implements AdapterView.OnItemClickListener {

    ListView listViewDisDet;
    DisbursementDetailsRep disbursementDetailsRep;
    String disId;
    String ClerkName;
    public static HashMap<String, DisbursementDetailsRep> rs=new HashMap<String, DisbursementDetailsRep>();
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {


        final View v = inflater.inflate(R.layout.fragment_disbursement_details, container, false);

        listViewDisDet = (ListView) v.findViewById(R.id.listViewDisDet);

        Bundle arg = getArguments();
        Log.i("args", arg.toString());

        if (arg != null) {
            disId = arg.getString("disId");
            ClerkName = arg.getString("ClerkName");

            if (disId != null) {

                new AsyncTask<Void, Void, ArrayList<DisbursementDetailsRep>>() {
                    @Override
                    protected ArrayList<DisbursementDetailsRep> doInBackground(Void... params) {
                        return disbursementDetailsRep.getDisDetForId(disId);
                    }

                    @Override
                    protected void onPostExecute(final ArrayList<DisbursementDetailsRep> result) {
//                        Log.i("post execute", result.toString());
                        listViewDisDet.setClickable(true);
                        listViewDisDet.setItemsCanFocus(false);
                        listViewDisDet.setAdapter(new DisbursementDetRepAdapter(getActivity(), R.layout.row_dis_det_rep, result));
                        listViewDisDet.setOnItemClickListener(DisbursementDetailsFragment.this);
                    }

                }.execute();
            }
        }
        return v;
    }


    @TargetApi(Build.VERSION_CODES.LOLLIPOP)
    @Override
    public void onItemClick(final AdapterView<?> av, final View v, final int position, long id) {
        final DisbursementDetailsRep item = (DisbursementDetailsRep) av.getAdapter().getItem(position);

        LayoutInflater li = LayoutInflater.from(getContext());
        final View promptsView = li.inflate(R.layout.prompts_dis,null);

        AlertDialog.Builder alertDialogBuilder = new AlertDialog.Builder(
                getActivity());

        // set prompts.xml to alertdialog builder
        alertDialogBuilder.setView(promptsView);
        final EditText userInput1 = (EditText) promptsView
                .findViewById(R.id.editTextDialogUserInput);

        final TextView ReqQty = (TextView) av.findViewById(R.id.textViewReqQty);
        final TextView ReceivedQty = ((TextView) av.findViewById(R.id.textViewRecQty));

        final TextView ItemDesc = ((TextView) av.findViewById(R.id.textViewDisDet));
        final RadioGroup rg=(RadioGroup)promptsView.findViewById(R.id.radioGroup);

//        Log.i("Item Description^%$^%^%", ItemDesc.getText().toString());
        // set dialog message
        AlertDialog.Builder builder = alertDialogBuilder
                .setCancelable(false)
                .setPositiveButton("OK",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                //Log.i("item new qty", userInput1.getText().toString());
                                int newQty = Integer.parseInt(userInput1.getText().toString());
                                //old ------ int oldQty = Integer.parseInt(ReqQty.getText().toString());
                                int oldQty = Integer.parseInt(item.get("ReqQty"));
                                String temp = userInput1.getText().toString();
                                //Log.i("item old qty", t1.getText().toString());

                                int selectedrId=rg.getCheckedRadioButtonId();
                                RadioButton rb=(RadioButton)promptsView.findViewById(selectedrId);
                                if (rb.getText().equals("")||rb.getText().equals(null))
                                {
                                    Toast.makeText(getContext(), "Please select a reason!", Toast.LENGTH_SHORT).show();
                                }
                                else {
                                    String reason=rb.getText().toString();
                                    Log.i("see the reason!!!!", reason);
                                    if (newQty > oldQty) {
                                        Log.i("item new qty", Integer.toString(newQty));
                                        Log.i("item old qty", Integer.toString(oldQty));
                                        Toast.makeText(getContext(), "Received Qty cannot be less than Requested Qty!", Toast.LENGTH_SHORT).show();
                                    } else {
                                        Log.i("item new qty", Integer.toString(newQty));
                                        Log.i("item old qty", Integer.toString(oldQty));
                                        //the old quantity doesn't refreshed
                                        item.put("ReceivedQuantity", temp);
                                        listViewDisDet.invalidateViews();
                                        ((DisbursementDetRepAdapter) av.getAdapter()).notifyDataSetChanged();
                                        /****new****/
                                        int adjustQty = oldQty - newQty;
                                        //DisbursementDetailsRep r = new DisbursementDetailsRep(Login.departmentCode, Integer.parseInt(disId), item.get("ItemDes"), Integer.parseInt(temp), adjustQty, "AdjustOut", reason, "Ajith");
                                        DisbursementDetailsRep r = new DisbursementDetailsRep(Login.departmentCode, Integer.parseInt(disId), item.get("ItemDes"), Integer.parseInt(temp), adjustQty, "AdjustOut", reason, ClerkName);
//                                        StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
//                                        DisbursementDetailsRep.CreateDisbursement(r);
                                        rs.put(item.get("ItemDes"),r);
                                        /****new****/
                                    }
                                }
                            }
                        })
                .setNegativeButton("Cancel",
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });

        // create alert dialog
        AlertDialog alertDialog = alertDialogBuilder.create();

        // show it
        alertDialog.show();
    }

}


