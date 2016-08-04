package com.example.zhongqishuai.lustationery.DepartmentHead;


import android.app.DatePickerDialog;
import android.net.ParseException;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.StrictMode;
import android.support.v4.app.Fragment;
import android.text.InputType;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.Login;
import com.example.zhongqishuai.lustationery.Model.Delegate;
import com.example.zhongqishuai.lustationery.R;

import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.Locale;

/**
 * A simple {@link Fragment} subclass.
 */
public class dhDelegate extends Fragment implements AdapterView.OnItemSelectedListener, View.OnClickListener  {


    public dhDelegate() {
        // Required empty public constructor
    }
    //UI References
    private EditText fromDateEtxt;
    private EditText toDateEtxt;
    private Spinner spinner;
    private Spinner spinner1;
    private DatePickerDialog fromDatePickerDialog;
    private DatePickerDialog toDatePickerDialog;

    private SimpleDateFormat dateFormatter;
    private SimpleDateFormat dateFormatter1;

    String EmpName;
    String Reason;
    String EmpId;
    String CurrEmpName;

    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        View V= inflater.inflate(R.layout.fragment_dh_delegate, container, false);
        dateFormatter = new SimpleDateFormat("yyyy-MM-dd", Locale.US);
        final TextView delegateName = (TextView) V.findViewById(R.id.textView6);

        final EditText frmDate = (EditText) V.findViewById(R.id.etxt_fromdate);
        final EditText etxt_todate = (EditText) V.findViewById(R.id.etxt_todate);
        final Spinner spinner3 = (Spinner) V.findViewById(R.id.spinner3);
        final Spinner spinner2 = (Spinner) V.findViewById(R.id.spinner2);
        final Button button4 = (Button)  V.findViewById(R.id.button4);
        final Button button3 = (Button)  V.findViewById(R.id.button3);



        dateFormatter1 = new SimpleDateFormat("yyyy-MM-dd");
        Calendar c = Calendar.getInstance();

        String formattedDate = dateFormatter1.format(c.getTime());
        Log.i("Current time => " , formattedDate);

        c.add(Calendar.DATE, 7);
        frmDate.setText(formattedDate);
        formattedDate = dateFormatter1.format(c.getTime());
        etxt_todate.setText(formattedDate);

        new AsyncTask<Void, Void, Delegate>() {
            @Override
            protected Delegate doInBackground(Void... params) {
                //return Delegate.getcurrent("COMM");
                /****new***/
                return Delegate.getcurrent(Login.departmentCode);
                /****new***/
            }
            @Override
            protected void onPostExecute(Delegate result) {
                Log.i("Status", result.get("status"));
                if(result.get("status").equals("Open"))
                {
                    Log.i("dele status", result.toString());
                    delegateName.setText(result.get("employeeName"));
                    EmpName = result.get("employeeName");
                    EmpId = result.get("employeeId");
                    CurrEmpName = result.get("employeeName");
                    frmDate.setEnabled(false);
                    etxt_todate.setEnabled(false);
                    spinner3.setEnabled(false);
                    spinner2.setEnabled(false);
                    button4.setEnabled(false);
                    button3.setEnabled(true);
                }
                else
                {
                    delegateName.setText("None");
                    frmDate.setEnabled(true);
                    etxt_todate.setEnabled(true);
                    spinner3.setEnabled(true);
                    spinner2.setEnabled(true);
                    button4.setEnabled(true);
                    button3.setEnabled(false);
                }
            }
        }.execute();

        spinner = (Spinner) V.findViewById(R.id.spinner2);
        spinner.setOnItemSelectedListener(dhDelegate.this);

        spinner1 = (Spinner) V.findViewById(R.id.spinner3);
        spinner1.setOnItemSelectedListener(dhDelegate.this);



        new AsyncTask<Void, Void, List<Delegate>>() {
            @Override
            protected List<Delegate> doInBackground(Void... params) {
                //return Delegate.Emplist("COMM");
                /****new***/
                return Delegate.Emplist(Login.departmentCode);
                /****new***/
            }
            @Override
            protected void onPostExecute(List<Delegate> result) {
                List<String> categories = new ArrayList<String>();
                for (Delegate d: result) {

                    categories.add(d.get("employeeName"));

                }

                // Spinner click listener

                // Creating adapter for spinner
                ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, categories);

                // Drop down layout style - list view with radio button
                dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
//                dataAdapter.add(CurrEmpName);
                // attaching data adapter to spinner
                spinner.setAdapter(dataAdapter);
            }
        }.execute();

        fromDateEtxt = (EditText) V.findViewById(R.id.etxt_fromdate);
        toDateEtxt = (EditText) V.findViewById(R.id.etxt_todate);
        //final EditText reason = (EditText) V.findViewById(R.id.Reason);


        Button bb = (Button) V.findViewById(R.id.button4);
        bb.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.i("Ename", EmpName);
                Log.i("Reason", Reason);
//              Log.i("Date", fromDateEtxt.getText().toString());
                try{

                    Date date1 = dateFormatter.parse(fromDateEtxt.getText().toString());
                    Date date2 = dateFormatter.parse(toDateEtxt.getText().toString());

//                    fromDateEtxt.getText().toString()
                    if (date1.compareTo(date2)>0)
                    {
                        Log.i("ToDate >  FromDate",date1.toString() + " " + date2.toString());
                        Toast.makeText(getActivity(), "StartDate cannot be greater than EndDate", Toast.LENGTH_LONG).show();
                    }
                    else
                    {
                        Log.i("Date entry 'ok'",date1.toString() + " " + date2.toString());
                        Delegate d =
                                new Delegate(EmpName,fromDateEtxt.getText().toString(),toDateEtxt.getText().toString(), Reason,"Open");
                        Log.i("Delegate", d.toString());
//
                        StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
                        Delegate.InsertDelegate(d);
                        Toast.makeText(getActivity(), "Delegation changed sucessfully..'", Toast.LENGTH_LONG).show();
                        //add confirm dialog
                        delegateName.setText(EmpName);
                        frmDate.setEnabled(false);
                        etxt_todate.setEnabled(false);
                        spinner3.setEnabled(false);
                        spinner2.setEnabled(false);
                        button4.setEnabled(false);
                        button3.setEnabled(true);
                    }

                }catch (ParseException e1){
                    e1.printStackTrace();
                } catch (java.text.ParseException e) {
                    e.printStackTrace();
                }
            }
        });

        //final Button button3 = (Button)  V.findViewById(R.id.button3);
        button3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Log.i("Ename", EmpName);

                StrictMode.setThreadPolicy(StrictMode.ThreadPolicy.LAX);
                Delegate.EndDelegate(EmpId);
//                ((BaseAdapter) varSpinner.getAdapter()).notifyDataSetChanged();
                delegateName.setText("None");



                new AsyncTask<Void, Void, List<Delegate>>() {
                    @Override
                    protected List<Delegate> doInBackground(Void... params) {
                        //return Delegate.Emplist("COMM");
                        /****new***/
                        return Delegate.Emplist(Login.departmentCode);
                        /****new***/
                    }
                    @Override
                    protected void onPostExecute(List<Delegate> result) {
                        List<String> categories = new ArrayList<String>();
                        for (Delegate d: result) {

                            categories.add(d.get("employeeName"));

                        }

                        // Spinner click listener

                        // Creating adapter for spinner
                        ArrayAdapter<String> dataAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, categories);

                        // Drop down layout style - list view with radio button
                        dataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
//                dataAdapter.add(CurrEmpName);
                        // attaching data adapter to spinner
                        spinner.setAdapter(dataAdapter);
                    }
                }.execute();


                frmDate.setEnabled(true);
                etxt_todate.setEnabled(true);
                spinner3.setEnabled(true);
                spinner2.setEnabled(true);
                button4.setEnabled(true);
                button3.setEnabled(false);
            }
        });

        findViewsById(V);
        /**for what***/
        Button Btndel = (Button) V.findViewById(R.id.button4);
        setDateTimeField();
        /****for what ***/
        return  V;
    }

    private void findViewsById(View V) {
        fromDateEtxt = (EditText) V.findViewById(R.id.etxt_fromdate);
        fromDateEtxt.setInputType(InputType.TYPE_NULL);
        fromDateEtxt.requestFocus();

        toDateEtxt = (EditText) V.findViewById(R.id.etxt_todate);
        toDateEtxt.setInputType(InputType.TYPE_NULL);
    }

    private void setDateTimeField() {
        fromDateEtxt.setOnClickListener(this);
        toDateEtxt.setOnClickListener(this);

        Calendar newCalendar = Calendar.getInstance();
        fromDatePickerDialog = new DatePickerDialog(getActivity(), new DatePickerDialog.OnDateSetListener() {
            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                Calendar newDate = Calendar.getInstance();
                newDate.set(year, monthOfYear, dayOfMonth);
                fromDateEtxt.setText(dateFormatter.format(newDate.getTime()));
            }

        },newCalendar.get(Calendar.YEAR), newCalendar.get(Calendar.MONTH), newCalendar.get(Calendar.DAY_OF_MONTH));

        toDatePickerDialog = new DatePickerDialog(getActivity(), new DatePickerDialog.OnDateSetListener() {

            public void onDateSet(DatePicker view, int year, int monthOfYear, int dayOfMonth) {
                Calendar newDate = Calendar.getInstance();
                newDate.set(year, monthOfYear, dayOfMonth);
                toDateEtxt.setText(dateFormatter.format(newDate.getTime()));
            }

        },newCalendar.get(Calendar.YEAR), newCalendar.get(Calendar.MONTH), newCalendar.get(Calendar.DAY_OF_MONTH));
    }

    @Override
    public void onClick(View view) {
        if(view == fromDateEtxt) {
            fromDatePickerDialog.show();
        } else if(view == toDateEtxt) {
            toDatePickerDialog.show();
        }
    }

    @Override
    public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {

//        if(view==spinner) {
//            EmpName = parent.getItemAtPosition(position).toString();
//            Log.i("Name",EmpName.toString());
//        }
//        else if(view==spinner1)
//        {
//            Reason = parent.getItemAtPosition(position).toString();
//            Log.i("Reason",Reason.toString());
//        }
//        else
//        {
//
//        }


        switch (parent.getId()){
            case R.id.spinner2:
                EmpName = parent.getSelectedItem().toString();
//                Toast.makeText(getActivity(), EmpName, Toast.LENGTH_LONG).show();
                break;
            case R.id.spinner3:
                Reason = parent.getSelectedItem().toString();
//                Toast.makeText(getActivity(), Reason, Toast.LENGTH_LONG).show();
                break;
        }

    }

    @Override
    public void onNothingSelected(AdapterView<?> parent) {

    }
}
