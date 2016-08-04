package com.example.zhongqishuai.lustationery.clerk;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.graphics.Color;
import android.os.AsyncTask;
import android.util.Log;
import android.view.KeyEvent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.EditorInfo;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Model.Adjustment;
import com.example.zhongqishuai.lustationery.Model.Retrieval;
import com.example.zhongqishuai.lustationery.R;

import java.util.HashMap;
import java.util.List;

/**
 * Created by zhongqishuai on 4/3/16.
 */
public class RetrievalListAdapter extends ArrayAdapter<Retrieval> {
    private List<Retrieval> retrievals;
//    Retrieval r;
    HashMap<Integer,Integer> tempQty;
    final String[] reasons = {" Items Broken "," Items Lost "};
    AlertDialog reasonDialog;
    ViewHolder holder;
    View convertView;
    TextView itemName;
    EditText itemQty;
    ImageView departmentView;
    Button btnChange;
    public RetrievalListAdapter(Context context, int resource, List<Retrieval> retrievals) {
        super(context, resource, retrievals);
        this.retrievals=retrievals;
        tempQty=new HashMap<Integer,Integer>();
//        holder = new ViewHolder();
    }
    @Override
    public View getView(final int position, View view, ViewGroup parent) {
        convertView=view;
        if (convertView == null) {
            LayoutInflater inflater = (LayoutInflater) getContext()
                    .getSystemService(Activity.LAYOUT_INFLATER_SERVICE);
            convertView = inflater.inflate(R.layout.retrievalrow, null);
            Log.i("see retrieval size", Integer.toString(retrievals.size()));
//            new AsyncTask<Integer, Void, Retrieval>() {
//                @Override
//                protected Retrieval doInBackground(Integer... params) {
//                    r = retrievals.get(position);
                    Log.i("<<<<<<<<<<<<<<<<<<", Integer.toString(position));
//                    return r;
//                }

//            Log.i(">>>>>>>>>>>>>>>>>>",r.get("itemCode").toString());
//        if (r!= null) {

//                @Override
//                protected void onPostExecute(Retrieval r) {
            Log.i(">>>>>>>>>>>>>>>", retrievals.get(position).get("itemCode"));
            itemName = (TextView) convertView.findViewById(R.id.itemName);
            itemQty = (EditText) convertView.findViewById(R.id.itemQty);
            departmentView = (ImageView) convertView.findViewById(R.id.depImage);
            btnChange = (Button) convertView.findViewById(R.id.btnChange);
            itemName.setText(retrievals.get(position).get("itemDes"));
            itemQty.setText(retrievals.get(position).get("Qty"));
            itemQty.setId(position);
            tempQty.put(position, Integer.parseInt(retrievals.get(position).get("Qty")));
            departmentView.setBackgroundResource(convertView.getResources().getIdentifier(retrievals.get(position).get("departmentCode").toLowerCase(),
                    "drawable", getContext().getPackageName()));

            btnChange.setId(position);
            btnChange.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    final int position = view.getId();
                    if (tempQty.get(position) > Integer.parseInt(retrievals.get(position).get("Qty"))) {
                        Toast.makeText(getContext(), "Can not Change to a BIGGER Quantity!", Toast.LENGTH_SHORT).show();
                    } else if (tempQty.get(position) == Integer.parseInt(retrievals.get(position).get("Qty"))) {
                        Toast.makeText(getContext(), "You Haven't Changed Anything", Toast.LENGTH_SHORT).show();
                    } else {
//                    view.setEnabled(false);
//                    view.setVisibility(view.INVISIBLE);
                        AlertDialog.Builder builder = new AlertDialog.Builder(getContext());
                        builder.setTitle("Select The Change Reason");
                        builder.setSingleChoiceItems(reasons, -1, new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int reason) {

                                switch (reason) {
                                    case 0:
                                        Log.i(">>>>>>>>>>>>>>", "case 0");
                                        changeRetrieval(position, reason);
//                                        retrievals.get(position).put("Qty", Integer.toString(tempQty.get(position)));

                                        break;
                                    case 1:
                                        Log.i(">>>>>>>>>>>>>>", "case 1");
                                        changeRetrieval(position, reason);
//                                        retrievals.get(position).put("Qty", Integer.toString(tempQty.get(position)));
                                        break;

                                }
                                reasonDialog.dismiss();
                            }
                        });
                        reasonDialog = builder.create();
                        reasonDialog.show();
                    }
                }
            });
            itemQty.setOnFocusChangeListener(new View.OnFocusChangeListener() {

                @Override
                public void onFocusChange(View v, boolean hasFocus) {
                    if (!hasFocus) {
                        judgeQty(v);
                    }
                }
            });
            itemQty.setOnEditorActionListener(new TextView.OnEditorActionListener() {
                @Override
                public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                    if (actionId == EditorInfo.IME_ACTION_SEARCH ||
                            actionId == EditorInfo.IME_ACTION_DONE ||
                            event.getAction() == KeyEvent.ACTION_DOWN &&
                                    event.getKeyCode() == KeyEvent.KEYCODE_ENTER) {
                        final int position = v.getId();
                        final EditText Qty = (EditText) v;
                        Qty.clearFocus();
                        return true;

                    }
                    return false;
                }
            });
//        }
                    convertView.setTag(holder);
//                }
//            }.execute(position);
        }

                else

                {
                    holder = (ViewHolder) convertView.getTag();
                }



        return convertView;
    }
    void judgeQty(View v)
    {
        final int position = v.getId();
        final EditText Qty = (EditText) v;
//        final Button btn=(Button)v.getTag(position);
        if (Qty.getText().toString().equals(""))
        {
            Qty.setText("0");
//            Log.i("iiiiiiiiiiiii",retrievals.get(position).get("orderQty"));
        }
        if (Integer.parseInt(Qty.getText().toString())>Integer.parseInt(retrievals.get(position).get("Qty")))
        {
            Log.i("~~~~~~~~~~~~~","I was touched");
//            Button btn=(Button)v.findViewById(position+1000);
//            btn.setEnabled(false);
            tempQty.put(position, Integer.parseInt(Qty.getText().toString()));
            Log.i("!!!!!!!!!!!!!!!!!",Qty.getText().toString());
//            Qty.setBackgroundColor(Color.parseColor("#FF4081"));
            Qty.setError("You cannot put a bigger number");
        }
        else {
            tempQty.put(position, Integer.parseInt(Qty.getText().toString()));
            Log.i(":::::::::::",Qty.getText().toString());
            Qty.setBackgroundColor(Color.parseColor("#FFFFFF"));
    }
    }
    class ViewHolder {
//        TextView itemName;
//        EditText itemQty;
//        ImageView departmentView;
//        Button btnChange;

    }
    void changeRetrieval(int position,int reasonNum)
    {
        new AsyncTask<Integer,Void,Integer>() {
            @Override
            protected Integer doInBackground(Integer... params) {
                int adjustQty = Integer.parseInt(retrievals.get(params[0]).get("Qty")) - tempQty.get(params[0]);
                Adjustment.makeAdjustment(retrievals.get(params[0]).get("itemCode"), adjustQty,reasons[params[1]],
                        Integer.parseInt(retrievals.get(params[0]).get("RetrievalId")),
                        retrievals.get(params[0]).get("departmentCode"),tempQty.get(params[0]));
                return params[0];
            }

            @Override
            protected void onPostExecute(Integer position) {
                retrievals.get(position).put("Qty", Integer.toString(tempQty.get(position)));
                Toast.makeText(getContext(), "Change Made", Toast.LENGTH_SHORT).show();
            }
        }.execute(position,reasonNum);
    }
}
