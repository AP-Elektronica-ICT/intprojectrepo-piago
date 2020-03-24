using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using InTheHand;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Ports;
using InTheHand.Net.Sockets;
using System.IO;

namespace PiaGo_CSharp
{


    public partial class Bluetooth : Form
    {

        List<string> items;
        BluetoothDeviceInfo deviceInfo;
        BluetoothDeviceInfo[] devices;
        // Guid mUUID = new Guid("00001101-0000-1000-8000-00805F9834FB");
        Guid mUUID = BluetoothService.SerialPort;
        bool serverStarted = false;
        int[] message;
        byte[] mRead;
        string myPin = "1234"; //wachtwoord voor een HC-05 gebruikt voor tests

        public Bluetooth()
        {
            items = new List<string>(); // List om bluetooth device in op te slagen
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            startScan(); // Methode om Bluetooth devices te zoeken
        }

        private void startScan()
        {
            listBox1.DataSource = null; // eerst gevonde lijst resetten om geen niet meer beschikbare bluetooth devices te kunnen selecteren en de listbox leegmaken
            listBox1.Items.Clear();
            items.Clear();
            Thread bluetoothScanThread = new Thread(new ThreadStart(scan)); // opstarten van een nieuwe thread die effectief bluetooth devices gaat zoeken.
            bluetoothScanThread.Start();
        }


        private void scan()
        {

            updateUI("Starting scan...");
            BluetoothClient client = new BluetoothClient(); // aanmaken van een BTClient
            devices = client.DiscoverDevicesInRange(); // zoeken naat BT devices
            updateUI("Scan Complete");
            updateUI(devices.Length.ToString() + " devices found");
            foreach (BluetoothDeviceInfo d in devices)
            {
                items.Add(d.DeviceName); //toevogen van alle gevonde BT devices aan de items List
            }

            updateDeviceList(); // methode die de list met BT devices print

        }


        private void updateUI(string message) // updates Textbox om progressie te volgen 
        {
            Func<int> del = delegate ()
            {
                tbOutput.AppendText(message + System.Environment.NewLine);
                return 0;
            };
            Invoke(del);

        }

        private void updateDeviceList() //updates Listbox1 met beschikbare BT devices
        {
            Func<int> del = delegate ()
            {
                listBox1.DataSource = items;
                return 0;
            };
            Invoke(del);

        }

        private void ClientConnectThread()
        {
            BluetoothClient client = new BluetoothClient(); // aanmaken van een neiuwe client video geeft hier niets van uitleg over en heir begint het moeilijk te worden
            updateUI("attempting connection");
            client.BeginConnect(deviceInfo.DeviceAddress, mUUID, this.BluetoothClientConnectCallback, client); // mUUID is een soort van sleutel  voor een private connection
        }



        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            deviceInfo = devices.ElementAt(listBox1.SelectedIndex); // koppelen we het geselecteerde device aan het object device info
            updateUI(deviceInfo.DeviceName + "Was Selected, attempting connection"); // controleert ineens of deze koppeling gelukt is

            if (pairDevice() == true) // methode gaat na of het pair request gelukt is of niet.
            {
                updateUI("device paired ...");
                updateUI("Starting connect thread");
                Thread bluetoothClientThread = new Thread(new ThreadStart(ClientConnectThread)); //aanmaken van een thread die zorg dat we kunnen werken via de Bt connection
                bluetoothClientThread.Start();
            }
            else
            {
                updateUI("Pair failed"); // hier kunnen we mischien nog alles resetten
            }
        }


        


        private bool pairDevice() //controleren of er een probleem is met authenteticatie.
        {
            if (!deviceInfo.Authenticated)
            {
                updateUI("Device not Authenticated!!!");

                if (!BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, myPin))
                {

                    updateUI("password not correct!!!");
                    return false;
                }
            }
            return true;
        }


        void BluetoothClientConnectCallback(IAsyncResult result)
        {
            updateUI("attempting Callback from bluetooth Device");
            BluetoothClient client = (BluetoothClient)result.AsyncState;
            client.EndConnect(result);


            Stream stream = client.GetStream();


            /*
            byte[] B = new byte[stream.Length];
            int numbytestoread = (int)stream.Length;
            int numbytesread = 0;
            while (numbytesread > 0)
            {
                int n = stream.Read(B, numbytesread, numbytestoread);
                if (n == 0)
                {
                    break;
                }
                numbytesread += n;
                numbytestoread -= n;
            }
            */

            stream.ReadTimeout = 1000;

            while (true) // waneer dit window wordt gesloten blijft de arduino verbonden
            {
                
            }
        }


    }
}
