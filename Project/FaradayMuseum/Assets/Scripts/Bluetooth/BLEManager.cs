using System;
using System.Collections;
using System.Collections.Generic;
using ArduinoBluetoothAPI;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(ParserData))]
public class BLEManager : MonoBehaviour
{
    [Tooltip("To enable or disable the BLE conection. " +
        "Make sure it's true when build!")]
    public bool connectBLE;

    [SerializeField]
    [Tooltip("Arduino device name")]
    private string deviceName = "ASTRA_K_LED_BLE";

    [SerializeField]
    [Tooltip("UART service UUID")]
    private string UUID = "6E400001-B5A3-F393-E0A9-E50E24DCCA9E";

    [SerializeField]
    [Tooltip("UUID_RX -> recive from arduino")]
    private string UUID_RX = "6E400002-B5A3-F393-E0A9-E50E24DCCA9E";

    [SerializeField]
    [Tooltip("UUID_TX -> to write on arduino")]
    private string UUID_TX = "6E400003-B5A3-F393-E0A9-E50E24DCCA9E";

    private ParserData parserData;
    private BluetoothHelper bluetoothHelper;

    private string queue;
    private bool awatingMsg;

    void Start()
    {
        queue = "";
        awatingMsg = false;
        TryToConnect();
    }

    private void TryToConnect()
    {
        Debug.Log("App started Search for BLE connection: " + connectBLE);

        if (connectBLE == true)
        {
            try
            {
                awatingMsg = false;

                BluetoothHelper.BLE = true;  //use Bluetooth Low Energy Technology
                bluetoothHelper = BluetoothHelper.GetInstance("TEST");

                bluetoothHelper.setTerminatorBasedStream("\n");

                Debug.Log(bluetoothHelper.getDeviceName());
                Debug.Log("Device name: " + bluetoothHelper.getDeviceName());

                bluetoothHelper.OnConnected += () => {

                    Debug.Log("Connected");

                    awatingMsg = false;
                    bluetoothHelper.StartListening();
                };

                bluetoothHelper.OnConnectionFailed += () => {
                    Debug.Log("Connection failed");
                };

                bluetoothHelper.OnScanEnded += OnScanEnded;

                bluetoothHelper.OnDataReceived += BluetoothHelper_OnDataReceived;

                BluetoothHelperCharacteristic txC = new BluetoothHelperCharacteristic(UUID_TX);
                txC.setService(UUID);

                BluetoothHelperCharacteristic rxC = new BluetoothHelperCharacteristic(UUID_RX);
                rxC.setService(UUID);


                bluetoothHelper.setRxCharacteristic(rxC);
                bluetoothHelper.setTxCharacteristic(txC);

                bluetoothHelper.ScanNearbyDevices();
            }
            catch (Exception ex)
            {
                Debug.LogError("Exception founded: " + ex);
            }
        }
    }

    private void OnScanEnded(LinkedList<BluetoothDevice> devices){
        Debug.Log("Found " + devices.Count);

        if (devices.Count == 0){
            bluetoothHelper.ScanNearbyDevices();
            return;
        }
            
        try
        {
            bluetoothHelper.setDeviceName(deviceName);
            bluetoothHelper.Connect();

            Debug.Log("Connecting");
        }
        catch (Exception ex)
        {
            Debug.LogError("Exception founded: " + ex);
        }
    }
    
    //call this to send data to the arduino
    public void MySendData(string s){
        Debug.Log("Trying to send ");

        // need to concatunate the string, because c# reoder strings to optimize things
        queue += s + "|";

        SendNext();
    }


    private void SendNext()
    {

        if (awatingMsg || bluetoothHelper == null)
            return;

        //Debug.Log("queue: " + queue);

        int x = queue.IndexOf('|');
        if(x <= 0) 
        {
            queue = "";
            return;
        }
        string msg = queue.Substring(0, x);
        queue = queue.Substring(x + 1);
        awatingMsg = true;

        Debug.Log("Sending " + msg);

        bluetoothHelper.SendData(msg);
    }

    private void BluetoothHelper_OnDataReceived()
    {
        awatingMsg = false;

        string aux = bluetoothHelper.Read();
        Debug.Log("Received: " +  aux);

        //Parse the data received by the arduino
        parserData.Parser(aux);

        // send the next message only when the previous message response is received.
        SendNext();
        
    }

    void OnDestroy()
    {
        if (bluetoothHelper != null)
            bluetoothHelper.Disconnect();
    }

    public BluetoothHelper GetBluetoothHelper()
    {
        return bluetoothHelper;
    }
}