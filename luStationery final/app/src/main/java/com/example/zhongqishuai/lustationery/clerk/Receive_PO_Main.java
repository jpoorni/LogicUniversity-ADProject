package com.example.zhongqishuai.lustationery.clerk;

import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
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

import com.example.zhongqishuai.lustationery.Model.PurchaseOrder;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;

/**
 * Created by zhongqishuai on 9/3/16.
 */
public class Receive_PO_Main extends Fragment implements AdapterView.OnItemSelectedListener, View.OnClickListener{
    ArrayList<String> ids=new ArrayList<String>();
    int selectedId;
    ArrayAdapter<String> dataAdapter;
    public static Button btnConfirm;
    public static Button btnReject;
    View v;
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        v = inflater.inflate(R.layout.recieve_po_main, container, false);
//        restoreInstanceState(savedInstanceState);
        new AsyncTask<Integer, Void, ArrayList<String>>() {
            @Override
            protected ArrayList<String> doInBackground(Integer... params) {

                if (ids.size()==0) {
                    PurchaseOrder.getPurchaseOrderIds();
                    for (int i = 0; i < PurchaseOrder.PurchaseOrderIds.size(); i++) {
                        ids.add(Integer.toString(PurchaseOrder.PurchaseOrderIds.get(i)));
                    }

                }
                return ids;
            }

            @Override
            protected void onPostExecute(ArrayList<String> ids) {
                // Spinner element
                Spinner spinner = (Spinner) v.findViewById(R.id.Receive_PO_Spinner);

                // Spinner click listener
                spinner.setOnItemSelectedListener(Receive_PO_Main.this);

                // Creating adapter for spinner
                dataAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, ids);

                // Drop down layout style - list view with radio button
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

                // attaching data adapter to spinner
                spinner.setAdapter(dataAdapter);

                btnConfirm=(Button)v.findViewById(R.id.btnConfirm);
                btnReject=(Button)v.findViewById(R.id.btnPOreject);
                if (ids.size()==0)
                {
                    ids.add("NO PURCHASE ORDER");
                    dataAdapter.notifyDataSetChanged();
                    btnConfirm.setEnabled(false);
                    btnReject.setEnabled(false);
//                        btnConfirm.setVisibility(v.INVISIBLE);
                }else
                {
                    btnConfirm.setEnabled(true);
                    btnReject.setEnabled(true);
                }
                btnConfirm.setOnClickListener(Receive_PO_Main.this);
                btnReject.setOnClickListener(Receive_PO_Main.this);
            }
        }.execute();
        if (ids!=null)
        {
            onSaveInstanceState(savedInstanceState);
        }

        return v;
    }
    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
        // On selecting a spinner item
        String item = parent.getItemAtPosition(position).toString();

        // Showing selected spinner item

        if (item=="NO PURCHASE ORDER") {
//            selectedId = Integer.parseInt(item);
//            displayGridView(selectedId);
            btnConfirm.setEnabled(false);
            btnReject.setEnabled(false);
        }
        else {
            Toast.makeText(parent.getContext(), "Selected: " + item, Toast.LENGTH_SHORT).show();
            selectedId = Integer.parseInt(item);
            displayPurchaseOrder(selectedId);
        }
    }
    public void onNothingSelected(AdapterView<?> arg0) {
        // TODO Auto-generated method stub


    }
    protected void displayPurchaseOrder(int selectedId){
        Bundle args1 = new Bundle();
        Log.i("qqqqqqqqqqqqqq", "check");
        args1.putInt("PurchaseOrder", selectedId);
        FrameLayout layout=(FrameLayout)v.findViewById(R.id.poDetails);
        layout.removeAllViews();
        android.app.Fragment f1 = new ReceivePO_frag();
        f1.setArguments(args1);
        getActivity().getFragmentManager().beginTransaction()
                .add(R.id.poDetails, f1)
                .commit();
    }
    @Override
    public void onClick(final View v) {
        switch (v.getId()) {
            case R.id.btnConfirm:
                    if (ReceivePO_frag.details.size() == 1 && ReceivePoAdapter.tempQty.get(0) == 0) {
                        if (ReceivePoAdapter.tempQty.get(0) == 0) {
                            Toast.makeText(getActivity(), "You'd better Reject!", Toast.LENGTH_SHORT).show();
                        }
                    }
                   else {
                        new AlertDialog.Builder(getActivity())
                                .setTitle("Complete Receiving of Purchase Order")
                                .setMessage("Are you sure you want to complete this Purchase Order?")
                                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int which) {
                                        new AsyncTask<Integer, Void, Integer>() {
                                            @Override
                                            protected Integer doInBackground(Integer... params) {
                                                PurchaseOrder.confirmPO(params[0]);
                                                for (int i = 0; i < ReceivePO_frag.details.size(); i++) {
                                                    if (ReceivePO_frag.details.size() == 1 && ReceivePoAdapter.tempQty.get(i) == 0) {
                                                        Toast.makeText(getActivity(), "You'd better Reject!", Toast.LENGTH_SHORT).show();
                                                    }
                                                    PurchaseOrder.changePODetail(
                                                            Integer.parseInt(ReceivePO_frag.details.get(i).get("pdetailId").toString()),
                                                            ReceivePoAdapter.tempQty.get(i));
                                                    Log.i("poid!!!", ReceivePO_frag.details.get(i).get("pdetailId").toString());
                                                }
                                                return params[0];
                                            }

                                            @Override
                                            protected void onPostExecute(Integer selectedId) {
                                                FrameLayout layout = (FrameLayout) getActivity().findViewById(R.id.poDetails);
                                                layout.removeAllViews();
                                                if (ids.size() > 1) {
                                                    int index = ids.indexOf(Integer.toString(selectedId));
                                                    ids.remove(Integer.toString(selectedId));
//                                Log.i("````````````", Integer.toString(ids.size()));
                                                    Log.i("````````````", Integer.toString(selectedId));
                                                    if (index >= ids.size()) {
                                                        displayPurchaseOrder(Integer.parseInt(ids.get(index - 1)));
                                                        Receive_PO_Main.this.selectedId = Integer.parseInt(ids.get(index - 1));
                                                    } else {
                                                        displayPurchaseOrder(Integer.parseInt(ids.get(index)));
                                                        Receive_PO_Main.this.selectedId = Integer.parseInt(ids.get(index));
                                                    }
                                                    dataAdapter.notifyDataSetChanged();
                                                } else {
                                                    ids.remove(0);
                                                    ids.add("NO PURCHASE ORDER");
                                                    //Toast.makeText(getActivity(), "You have NO NEW Retrievals", Toast.LENGTH_SHORT).show();
                                                    dataAdapter.notifyDataSetChanged();
                                                    v.setEnabled(false);
                                                    btnReject.setEnabled(false);
                                                }
                                            }
                                        }.execute(selectedId);
                                    }

                                })
                                .
                                        setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int which) {
                                                // do nothing
                                            }
                                        })
                                .setIcon(android.R.drawable.ic_dialog_alert)
                                .show();
                    }
                break;
            case R.id.btnPOreject:
                new AlertDialog.Builder(getActivity())
                        .setTitle("Reject Receiving of Purchase Order")
                        .setMessage("Are you sure you want to Reject this Purchase Order?")
                        .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int which) {
                                new AsyncTask<Integer, Void, Integer>() {
                                    @Override
                                    protected Integer doInBackground(Integer... params) {
                                        PurchaseOrder.rejectPO(params[0]);
                                        return params[0];
                                    }

                                    @Override
                                    protected void onPostExecute(Integer selectedId) {
                                        FrameLayout layout = (FrameLayout) getActivity().findViewById(R.id.poDetails);
                                        layout.removeAllViews();
                                        if (ids.size() > 1) {
                                            int index = ids.indexOf(Integer.toString(selectedId));
                                            ids.remove(Integer.toString(selectedId));
                                            Log.i("````````````", Integer.toString(selectedId));
                                            if (index >= ids.size()) {
                                                displayPurchaseOrder(Integer.parseInt(ids.get(index - 1)));
                                                Receive_PO_Main.this.selectedId = Integer.parseInt(ids.get(index - 1));
                                            } else {
                                                Receive_PO_Main.this.displayPurchaseOrder(Integer.parseInt(ids.get(index)));
                                                Receive_PO_Main.this.selectedId = Integer.parseInt(ids.get(index));
                                            }
                                            dataAdapter.notifyDataSetChanged();
                                        } else {
                                            ids.remove(0);
                                            ids.add("NO PURCHASE ORDER");
                                            //Toast.makeText(getActivity(), "You have NO NEW Retrievals", Toast.LENGTH_SHORT).show();
                                            dataAdapter.notifyDataSetChanged();
                                            v.setEnabled(false);
                                            btnConfirm.setEnabled(false);
                                        }
                                    }
                                }.execute(selectedId);
                            }

                        })
                        .
                                setNegativeButton(android.R.string.no, new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int which) {
                                        // do nothing
                                    }
                                })
                        .setIcon(android.R.drawable.ic_dialog_alert)
                        .show();
                break;


        }
    }


}
