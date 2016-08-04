package com.example.zhongqishuai.lustationery;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.graphics.Color;
import android.os.AsyncTask;
import android.support.v7.app.ActionBar;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.example.zhongqishuai.lustationery.DepartmentHead.departmentheadMainActivity;
import com.example.zhongqishuai.lustationery.Employee.emp_Main;
import com.example.zhongqishuai.lustationery.Model.Supplier;
import com.example.zhongqishuai.lustationery.Model.User;
import com.example.zhongqishuai.lustationery.Representative.rep_Main;
import com.example.zhongqishuai.lustationery.StoreManager.StoreManagerMainActivity;
import com.example.zhongqishuai.lustationery.StoreSupervisor.StoreSupervisorMainActivity;
import com.example.zhongqishuai.lustationery.clerk.clerk_Main;

public class Login extends AppCompatActivity {

    Button b1;
    EditText ed1,ed2;
    TextView tx1;
    int counter = 3;
    int role;
    //    User newUser;
    public static int userID;
    public static String departmentCode;
    public static String departmentName;
    SharedPreferences prefs;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_login);
        ActionBar actionBar=getSupportActionBar();
        actionBar.setDisplayShowHomeEnabled(true);
        actionBar.setIcon(R.drawable.logo);
        actionBar.setDisplayUseLogoEnabled(true);
//        prefs = PreferenceManager.getDefaultSharedPreferences(this);
        prefs=getSharedPreferences("loginPrefs", Context.MODE_PRIVATE);
//        Intent intent=getIntent();
//        if (intent.hasExtra("finish")) {
//            if (intent.getExtras().getBoolean("finish")) {
//                SharedPreferences.Editor editor1 = prefs.edit();
//                editor1.putBoolean("firstTime", false);
//                Log.i("aaaaaaaaaaaaa","Log out");
//            }
//        }
        if (!prefs.getBoolean("firstTime", false)) {
            b1=(Button)findViewById(R.id.login_button);
            ed1=(EditText)findViewById(R.id.editText);
            ed2=(EditText)findViewById(R.id.editText2);
            tx1=(TextView)findViewById(R.id.textView3);
            tx1.setVisibility(View.GONE);
            b1.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    new AsyncTask<String, Void, User>() {
                        @Override
                        protected User doInBackground(String... params) {
                            Supplier.getSupplier();
                            return User.getUser(params[0],params[1]);
                        }
                        @Override
                        protected void onPostExecute(User user) {
                            role=user.getRole();
                            userID=user.getUserId();
                            departmentCode=user.getDepartmentCode();
                            departmentName=user.getDepartmentName();
                            Log.i("user role !!!!!!",Integer.toString(role));
//                    role=1;
//                    userID=1001;
                            if (role!=0){
                                gotoClerk(role);
                                Toast.makeText(getApplicationContext(), "Right Credentials", Toast.LENGTH_SHORT).show();
                                SharedPreferences.Editor editor = prefs.edit();
                                editor.putBoolean("firstTime", true);
                                editor.putInt("role", role);
                                editor.putInt("userId", userID);
                                editor.putString("departmentCode", departmentCode);
                                editor.putString("departmentName",departmentName);
                                editor.commit();

                            }
                            else{
                                Toast.makeText(getApplicationContext(), "Wrong Credentials", Toast.LENGTH_SHORT).show();

                                tx1.setVisibility(View.VISIBLE);
                                tx1.setBackgroundColor(Color.RED);
                                counter--;
                                tx1.setText(Integer.toString(counter));

                                if (counter == 0) {
                                    b1.setEnabled(false);
                                }
                            }
                        }
                    }.execute(ed1.getText().toString(),ed2.getText().toString());

                }

            });
        }
        else{
            gotoClerk(prefs.getInt("role", 0));
            userID=prefs.getInt("userId",0);
            //hard coded for all departments is it ?? **/
            departmentCode=prefs.getString("departmentCode","COMM");
            departmentName=prefs.getString("departmentName","Commerce");
            //hard coded for all departments is it ?? **/
        }
    }
    public void gotoClerk(int r){
        switch (r) {
            case 11000:
                Intent intent = new Intent(this, clerk_Main.class);
                startActivity(intent);
                finish();
                break;

            case 11004:
                Log.i("role id for emp", Integer.toString(role));
                Intent intent1 = new Intent(this, emp_Main.class);
                startActivity(intent1);
                finish();
                break;

            case 11005:
                Intent intent2 = new Intent(this, rep_Main.class);
                startActivity(intent2);
                finish();
                break;

            case 11001:
                Intent intent3 = new Intent(this, StoreSupervisorMainActivity.class);
                startActivity(intent3);
                finish();
                break;
            case 11003:
                Intent intent5 = new Intent(this, departmentheadMainActivity.class);
                startActivity(intent5);
                finish();
                break;
            case 11002:
                Intent intent6 = new Intent(this, StoreManagerMainActivity.class);
                startActivity(intent6);
                finish();
                break;
            case 11006:
                Intent intent7 = new Intent(this, departmentheadMainActivity.class);
                startActivity(intent7);
                finish();
                break;
        }

    }
}
