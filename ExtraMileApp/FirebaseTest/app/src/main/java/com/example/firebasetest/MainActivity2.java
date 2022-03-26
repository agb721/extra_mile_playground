package com.example.firebasetest;


import androidx.appcompat.app.AppCompatActivity;

import android.content.ComponentName;
import android.content.Intent;
import android.content.ServiceConnection;
import android.content.pm.ResolveInfo;
import android.content.pm.ServiceInfo;
import android.graphics.Canvas;
import android.graphics.drawable.Drawable;
import android.os.Bundle;
import android.os.IBinder;
import android.os.RemoteException;
import android.util.Log;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

import io.neuos.INeuosSdk;
import io.neuos.INeuosSdkListener;
import io.neuos.NeuosSDK;

public class MainActivity2 extends AppCompatActivity {
    // storing neuos values
    private int focusValue;
    private int enjoymentValue;
    private int zoneValue;
    private int heartRateValue;
    private INeuosSdk mService;
    final String TAG = "Neuos";
    private ArrayList<String> list = new ArrayList<String>();
    ListView lv = findViewById(R.id.listView);


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        doBindService();
    }

    // update the neuos values and invalidate the screen to re-draw
    public void updateNeuosValue(String key , float value){
        switch (key){
            case NeuosSDK.PredictionValues.ZONE_STATE:{
                zoneValue = (int) value;
                break;
            }
            case NeuosSDK.PredictionValues.ENJOYMENT_STATE:{
                enjoymentValue = (int)value;
                break;
            }
            case NeuosSDK.PredictionValues.FOCUS_STATE:{
                focusValue = (int)value;
                break;
            }
            case NeuosSDK.PredictionValues.HEART_RATE:{
                heartRateValue = (int)value;
                break;
            }
        }
    }
    // Neuos SDK Listener
    private final INeuosSdkListener mCallback = new INeuosSdkListener.Stub() {
        @Override
        public void onConnectionChanged(int previousConnection, int currentConnection) throws RemoteException {
        }
        @Override
        public void onValueChanged(String key, float value) throws RemoteException {
            // update our view with proper values
            //view.updateNeuosValue(key, Math.round(value));
            list.add(String.valueOf(Math.round(value)));

        }
        @Override
        public void onQAStatus(boolean passed , int type){
        }

        @Override
        public void onSessionComplete() throws RemoteException {
//            ArrayAdapter<String> arrayAdapter = new ArrayAdapter<String>(
//                    this,
//                    android.R.layout.lvitem,
//                    list );
            // ArrayAdapter arrayAdapter = new ArrayAdapter<String>(this, R.layout.listitem,R.id.textview, list);

            //  lv.setAdapter(arrayAdapter);
            Log.d(TAG,"workssssssssssssssssssssssssss");
        }


        @Override
        public void onError(int errorCode, String message) throws RemoteException {
        }
    };

    /**
     * Class for interacting with the main interface of the service.
     */
    private final ServiceConnection mConnection = new ServiceConnection() {
        public void onServiceConnected(ComponentName className,
                                       IBinder service) {
            mService = INeuosSdk.Stub.asInterface(service);
            try {
                int response = mService.registerSDKCallback(mCallback);
                if ( response != NeuosSDK.ResponseCodes.SUCCESS){
                    Log.i(TAG, "registerSDKCallback: failed with code " + response);
                    showError("registerSDKCallback failed with code " + response);
                }

            }
            catch (RemoteException e) {
                Log.e(TAG, e.getLocalizedMessage());
            }
        }

        public void onServiceDisconnected(ComponentName className) {
            Log.d(TAG, "Detached.");
        }
    };

    private boolean doBindService() {
        try {
            // Create an intent based on the class name
            Intent serviceIntent = new Intent(INeuosSdk.class.getName());
            // Use package manager to find intent reciever
            List<ResolveInfo> matches=getPackageManager()
                    .queryIntentServices(serviceIntent, 0);
            if (matches.size() == 0) {
                Log.d(TAG, "Cannot find a matching service!");
                showError("Cannot find a matching service!");
            }
            else if (matches.size() > 1) {
                // This is really just a sanity check
                // and should never occur in a real life scenario
                showError("Found multiple matching services!");
            }
            else {
                // Create an explicit intent
                Intent explicit=new Intent(serviceIntent);
                ServiceInfo svcInfo=matches.get(0).serviceInfo;
                ComponentName cn=new ComponentName(svcInfo.applicationInfo.packageName,
                        svcInfo.name);
                explicit.setComponent(cn);
                // Bind using AUTO_CREATE
                if (bindService(explicit, mConnection,  BIND_AUTO_CREATE)){
                    Log.d(TAG, "Bound to Neuos Service");
                } else {
                    Log.d(TAG, "Failed to bind to Neuos Service");
                    showError("Failed to bind to Neuos Service");
                }
            }
        } catch (Exception e) {
            Log.e(TAG, "can't bind to NeuosService, check permission in Manifest");
            showError("can't bind to NeuosService, check permission in Manifest");
        }
        return false;
    }

    private void showError(String message){
        Toast.makeText(this, message, Toast.LENGTH_LONG).show();
    }

}