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

import com.example.zhongqishuai.lustationery.Model.Retrieval;
import com.example.zhongqishuai.lustationery.R;

import java.util.ArrayList;

/**
 * Created by zhongqishuai on 2/3/16.
 */
public class retrieval_Main extends Fragment implements AdapterView.OnItemSelectedListener, View.OnClickListener {
//    GridView gv;
    ArrayList<String> ids=new ArrayList<String>();;
    int selectedId;
    ArrayAdapter<String> dataAdapter;
    Button btnConfirm;
//    public static String [] prgmNameList={"Clip","Envelop","Eraser","Exercise","Forder","Pad","Paper","Pen"
//    ,"Puncher","Ruler","Scissor","Sharpner","Tape","Shorthand","Stapler","Tack","Tparency","Tray"};
//    public static int [] prgmImages={R.drawable.clip,R.drawable.envelope,R.drawable.eraser,R.drawable.exercise,
//    R.drawable.file,R.drawable.pad,R.drawable.paper,R.drawable.pen,R.drawable.puncher,R.drawable.ruler,R.drawable.scissor
//    ,R.drawable.sharpner,R.drawable.tape,R.drawable.shorthand,R.drawable.stapler,R.drawable.tack,R.drawable.tparency,
//            R.drawable.tray};
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        final View v = inflater.inflate(R.layout.retrieval_main_frag, container, false);
        restoreInstanceState(savedInstanceState);
//        Log.i("!!!!!!!!!!!!!",ids.toString());
            new AsyncTask<Integer, Void, ArrayList<String>>() {
                @Override
                protected ArrayList<String> doInBackground(Integer... params) {

                    if (ids.size()==0) {
                        Retrieval.getAllRetrievalId();
                        for (int i = 0; i < Retrieval.RetrievalIds.size(); i++) {
                            ids.add(Integer.toString(Retrieval.RetrievalIds.get(i)));
                        }

                    }
                    return ids;
                }

                @Override
                protected void onPostExecute(ArrayList<String> ids) {
                    // Spinner element
                    Spinner spinner = (Spinner) v.findViewById(R.id.spinner);

                    // Spinner click listener
                    spinner.setOnItemSelectedListener(retrieval_Main.this);

                    // Creating adapter for spinner
                    dataAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, ids);

                    // Drop down layout style - list view with radio button
                    dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);

                    // attaching data adapter to spinner
                    spinner.setAdapter(dataAdapter);

                    btnConfirm=(Button)v.findViewById(R.id.btnConfirm);
                    if (ids.size()==0)
                    {
                        ids.add("NO RETRIEVAL");
                        dataAdapter.notifyDataSetChanged();
                        btnConfirm.setEnabled(false);
//                        btnConfirm.setVisibility(v.INVISIBLE);
                    }else
                    {
                        btnConfirm.setEnabled(true);
                    }
                    btnConfirm.setOnClickListener(retrieval_Main.this);
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

        if (item=="NO RETRIEVAL") {
//            selectedId = Integer.parseInt(item);
//            displayGridView(selectedId);
            btnConfirm.setEnabled(false);
        }
        else {
            Toast.makeText(parent.getContext(), "Selected: " + item, Toast.LENGTH_SHORT).show();
            selectedId = Integer.parseInt(item);
            displayGridView(selectedId);
        }
    }
    public void onNothingSelected(AdapterView<?> arg0) {
        // TODO Auto-generated method stub


    }

//    public void onClick(View v) {
//        Intent intent = new Intent(getActivity(), Retrieval_Confirm.class);
//        startActivity(intent);
//    }
    protected void displayGridView(int selectedId){
        String id = Integer.toString(selectedId);
        Bundle args1 = new Bundle();
        Log.i("qqqqqqqqqqqqqq", "check");
        args1.putString("RetrievalId", id);
        FrameLayout layout=(FrameLayout)getActivity().findViewById(R.id.retrievals);
        layout.removeAllViews();
        android.app.Fragment f1 = new retrieval_gridView_Frag();
        f1.setArguments(args1);
        getActivity().getFragmentManager().beginTransaction()
                .add(R.id.retrievals, f1)
                .commit();
    }
    @Override
    public void onSaveInstanceState(Bundle outState) {
        super.onSaveInstanceState(outState);
        if ((outState!=null)) {
            outState.putStringArrayList("rids", ids);
            Log.i("hhhhhhhhhhhhhhhhh", "im here");
        }
    }

    public void restoreInstanceState(Bundle state) {
        if (state != null) {
            ids = state.getStringArrayList("rids");
            Log.i("hhhhhhhhhhhhhhhhh", "im here !!");
        }
    }
    @Override
    public void onClick(final View v) {
        new AlertDialog.Builder(getActivity())
                .setTitle("Confirm Retrieval")
                .setMessage("Are you sure you want to confirm this Retrieval?")
                .setPositiveButton(android.R.string.yes, new DialogInterface.OnClickListener() {
                    public void onClick(DialogInterface dialog, int which) {
                        new AsyncTask<Integer, Void, Integer>() {
                            @Override
                            protected Integer doInBackground(Integer... params) {
                                Retrieval.confirmRetrieval(params[0]);
                                return params[0];
                            }

                            @Override
                            protected void onPostExecute(Integer selectedId) {
                                FrameLayout layout = (FrameLayout) getActivity().findViewById(R.id.retrievals);
                                layout.removeAllViews();
                                if (ids.size() > 1) {
                                    int index=ids.lastIndexOf(Integer.toString(selectedId));
                                    Log.i("index!!!!!!",Integer.toString(index));
                                    ids.remove(Integer.toString(selectedId));
//                                Log.i("````````````", Integer.toString(ids.size()));
                                    if (index>=ids.size())
                                    {
                                        displayGridView(Integer.parseInt(ids.get(index - 1)));
                                        retrieval_Main.this.selectedId=Integer.parseInt(ids.get(index - 1));
                                    }
                                    else {
                                        displayGridView(Integer.parseInt(ids.get(index)));
                                        retrieval_Main.this.selectedId=Integer.parseInt(ids.get(index));
                                    }
                                    dataAdapter.notifyDataSetChanged();
                                } else {
                                    ids.remove(0);
                                    ids.add("NO RETRIEVAL");
                                    //Toast.makeText(getActivity(), "You have NO NEW Retrievals", Toast.LENGTH_SHORT).show();
                                    dataAdapter.notifyDataSetChanged();
                                    v.setEnabled(false);
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
                }
