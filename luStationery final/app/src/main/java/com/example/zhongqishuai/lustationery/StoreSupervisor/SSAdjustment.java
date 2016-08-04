package com.example.zhongqishuai.lustationery.StoreSupervisor;

import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.support.v4.app.Fragment;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ListView;
import android.widget.PopupWindow;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.R;

import java.util.List;

/**
 * A simple {@link Fragment} subclass.
 */
public class SSAdjustment extends Fragment implements AdapterView.OnItemClickListener{

    private PopupWindow popupWindow;
    public SSAdjustment() {
        // Required empty public constructor
    }


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
//        FragmentTransaction ft = getFragmentManager().beginTransaction();
//        ft.detach(this).attach(this).commit();
        final View v = inflater.inflate(R.layout.fragment_ssadjustment, container, false);

        new AsyncTask<Void, Void, List<Adjustment>>() {
            @Override
            protected List<Adjustment> doInBackground(Void... params) {

                //return Adjustment.AdjustmentList("1027");
                /****new***/
                return Adjustment.AdjustmentList(Integer.toString(Login.userID));
                /****new***/
            }
            @Override
            protected void onPostExecute(List<Adjustment> result) {
                AdjustmentAdapter adapter = new AdjustmentAdapter(getActivity(), R.layout.adjustlistrow, result) ;

                    ListView list = (ListView) v.findViewById(R.id.listView);
                    list.setAdapter(adapter);
                    //setListAdapter(adapter);
                    list.setOnItemClickListener(SSAdjustment.this);
                }
        }.execute();

        return  v;
    }
    public void onItemClick(AdapterView<?> av, View v, int position, long id) {

       // Log.i("Start","");

        //Adjustment item = (Adjustment) av.getAdapter().getItem(position);
        //String Reqid = item.get("adjustmentId");
        //Intent intent = new Intent(getActivity(), dhRequisitionDetails.class);
        //intent.putExtra("aid", Reqid);
        //startActivity(intent);
        //popupWindow();
//        AlertDialog.Builder alertDialog = new AlertDialog.Builder(getActivity());
//        alertDialog.setTitle("Details of this adjustmentList");
//        final ListView detaillist = new ListView(getActivity());
//        new AsyncTask<Void, Void, List<Adjustment>>() {
//            @Override
//            protected List<Adjustment> doInBackground(Void... params) {
//                return Adjustment.AdjustmentDetails("8001");
//            }
//            @Override
//            protected void onPostExecute(List<Adjustment> result) {
//                AdjustDetailAdapter adapter = new AdjustDetailAdapter(getActivity(), R.layout.adjustlistrow, result);
//                detaillist.setAdapter(adapter);
//                //setListAdapter(adapter);
//            }
//        }.execute();
//        //alertDialog.create();
//        alertDialog.setView(detaillist);
//        alertDialog.show();
        Log.i("Start","");

        Adjustment item = (Adjustment) av.getAdapter().getItem(position);
        String adid = item.get("adjustmentId");
        Intent intent = new Intent(getActivity(), SSAdjustDetail.class);
        intent.putExtra("RID", adid);
        startActivityForResult(intent, 1);

    }
    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {

        if (requestCode == 1) {
            getActivity().recreate();
        }
    }//onActivityResult
        /*private PopupWindow popupWindow() {

            // initialize a pop up window type
            //popupWindow  = new PopupWindow(getActivity());
            //popupWindow.setFocusable(true);

            ArrayList<String> sortList = new ArrayList<String>();
            sortList.add("A to Z");
            sortList.add("Z to A");
            sortList.add("Low to high price");

            ArrayAdapter<String> adapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_dropdown_item_1line,
                    sortList);
            // the drop down list is a list view
            ListView listViewSort = new ListView(getActivity());

            // set our adapter and pass our pop up window contents
            listViewSort.setAdapter(adapter);

            // set on item selected
            //listViewSort.setOnItemClickListener(onItemClickListener());

            // some other visual settings for popup window
            popupWindow.setFocusable(true);
            popupWindow.setWidth(250);
            // popupWindow.setBackgroundDrawable(getResources().getDrawable(R.drawable.white));
            popupWindow.setHeight(WindowManager.LayoutParams.WRAP_CONTENT);

            // set the list view as pop up window content
            popupWindow.setContentView(listViewSort);

            return popupWindow;
        }*/
}
