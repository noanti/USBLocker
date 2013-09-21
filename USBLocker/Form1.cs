using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;


namespace USBLocker
{
    public partial class frmUSBLocker : Form
    {
        RegistryKey rkey;

        public frmUSBLocker()
        {
            InitializeComponent();
            rkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\USBSTOR", true);
            int val = int.Parse(rkey.GetValue("Start").ToString());
            if (val == 3)
            {
                lblValue.Text = "USB Ports enabled";
            }
            else
            {
                lblValue.Text = "USB Ports disabled";
            }
        }

        private void btnDo_Click(object sender, EventArgs e)
        {
            try
            {
                
                int val = int.Parse(rkey.GetValue("Start").ToString());
                //lblValue.Text = ""+val;
                if (val == 3)
                {
                    rkey.SetValue("Start", 4);
                    lblValue.Text = "USB Ports disabled";
                }
                else {
                    rkey.SetValue("Start", 3);
                    lblValue.Text = "USB Ports enabled";
                }
                //rkey.SetValue("Start", 4);
            }catch(Exception ex){
                string s = ex.Message;
                lblValue.Text = "Program settings has been reseted.Please run application as administrator";
            }
        }

        private void frmUSBLocker_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Rumesh Eranga\nrehrumesh@hotmail.com\nUniversity of Colombo School of Computing", "About");
        }

        
    }
}
