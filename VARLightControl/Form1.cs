using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VARLightControl
{
    public partial class Form1 : Form
    {
        public static Form1 pThis;

        private int m_dioTestStartFlag = 0;

        //private UInt16 m_doValue = 0;
        private Byte m_doValueL = 0;
        private Byte m_doValueH = 0;
        private Byte m_diValueH = 0;
        private Byte m_diValueL = 0;

        private UInt16 m_comPort = 3;
        private Int32 m_comPortOpenFlag = 0;
        private Byte m_DevId = 0x01;

        private Byte m_pwmValueCh0 = 0;
        private Byte m_pwmValueCh1 = 0;
        private Byte m_pwmValueCh2 = 0;
        private Byte m_pwmValueCh3 = 0;

        string configPath = "";

        private LCCallbackMethod pvOpenComCallback = openComCallBcak;
        private LCCallbackMethod pvCloseComCallback = closeComCallBack;

        private LCCallbackMethod pvGetCh3PwmParamsCallback = getPwmParamsCallBackCh3;
        private LCCallbackMethod pvSetCh3PwmParamsCallback = setPwmParamsCallBackCh3;
        private LCCallbackMethod pvGetCh0PwmParamsCallback = getPwmParamsCallBackCh0;
        private LCCallbackMethod pvSetCh0PwmParamsCallback = setPwmParamsCallBackCh0;
      

        public Form1()
        {
            InitializeComponent();
            pThis = this;
            this.m_comboBoxModeCh3.SelectedIndex = 0;

            this.m_comboBoxPort.Items.Add("COM3");
            this.m_comboBoxPort.SelectedItem = "COM3";

            string selectFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "select.ini");
            string selectItem = INIHelper.Read("SELECTED", "Name", " ", selectFilePath);
            string selectItemPath = INIHelper.Read("SELECTED", "ConfigPath", " ", selectFilePath);
            configPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, selectItem);
            configPath = configPath + "\\nkio_config.ini";

            if (NativeAPI.DIOLC_LibraryBaseInit(configPath) < 0)
            {
                MessageBox.Show("DIOLC_LibraryBaseInit error");
                return;
            }

            //this.labelTest.Text = configPath;
            this.timer1.Enabled = true;
        }

        // Create Connection 
        private void m_btnConnect_Click(object sender, EventArgs e)
        {
            string szComSelected = this.m_comboBoxPort.Text;
            if (szComSelected != null && szComSelected != string.Empty)
            {
                // Regular expression to strip out non - numeric characters(does not contain decimal point.)
                szComSelected = Regex.Replace(szComSelected, @"[^\d.\d]", "");
                // If it is a number, convert to decimal type
                if (Regex.IsMatch(szComSelected, @"^[+-]?\d*[.]?\d*$"))
                {
                    m_comPort = UInt16.Parse(szComSelected);
                }
            }

            if (m_comPortOpenFlag == 0)
            {
                NativeAPI.DIOLC_OpenDevice(m_comPort, this.pvOpenComCallback);

                m_comPortOpenFlag = 1;

            }
            else
            {
                NativeAPI.DIOLC_CloseDevice(m_comPort, this.pvCloseComCallback);
                m_comPortOpenFlag = 0;
            }
        }

        /// <summary>
        /// Callbacks 
        /// </summary>
        /// <param name="args"></param>

        public static void openComCallBcak(LC_CALLBACK_ARG_T args)
        {
            pThis.m_btnConnect.Text = "Disconnect";
            pThis.m_btnConnect.BackColor= Color.Green;
            // Get all of the information set when opened
            NativeAPI.LC_GetPwmParams(pThis.m_DevId, 0x08, pThis.pvGetCh3PwmParamsCallback);
            NativeAPI.LC_GetPwmParams(pThis.m_DevId, 0x01, pThis.pvGetCh0PwmParamsCallback);
        }

        public static void closeComCallBack(LC_CALLBACK_ARG_T args)
        {
            pThis.m_btnConnect.Text = "Connect";
            pThis.m_btnConnect.BackColor = Color.Red;
            //pThis.m_lblFirmwareVer.Text = "x.x.x";
            //pThis.m_lblHardwareVer.Text = "x.x.x";
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // Notification Process
            NativeAPI.DIOLC_Process();
        }

        //*************************************************** CHANNEL 3 ***************************************************//
        private void m_btnReadCh3_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_GetPwmParams(m_DevId, 0x08, this.pvGetCh3PwmParamsCallback);
        }

        private void m_btnWriteCh3_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                    0x08,
                    (byte)this.m_comboBoxModeCh3.SelectedIndex,
                    m_pwmValueCh3,
                    (byte)this.m_HoldingTimeCh3.Value,
                    m_checkBoxSwitchCh3.Checked ? (byte)0x01 : (byte)0,
                    this.pvSetCh3PwmParamsCallback);
        }

        private void m_checkBoxSwitchCh3_CheckedChanged(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                    0x08,
                    (byte)this.m_comboBoxModeCh3.SelectedIndex,
                    m_pwmValueCh3,
                    (byte)this.m_HoldingTimeCh3.Value,
                    m_checkBoxSwitchCh3.Checked ? (byte)0x01 : (byte)0,
                    this.pvSetCh3PwmParamsCallback);
            //Check ON OFF State and Change Text
            if (m_checkBoxSwitchCh3.Checked)
            {
                this.m_checkBoxSwitchCh3.Text = "ON";
                this.m_checkBoxSwitchCh3.BackColor= Color.Green;
            }
            else
            {
                this.m_checkBoxSwitchCh3.Text = "OFF";
                this.m_checkBoxSwitchCh3.BackColor = Color.Red;
            }
            // TRY Trigger Logic
            //if(m_comboBoxModeCh3.SelectedItem.ToString()=="Soft Trigger")
            //{
            //    NativeAPI.LC_SetPwmParams(m_DevId,
            //        0x08,
            //        (byte)this.m_comboBoxModeCh3.SelectedIndex,
            //        m_pwmValueCh3,
            //        (byte)this.m_HoldingTimeCh3.Value,
            //        m_checkBoxSwitchCh3.Checked ? (byte)0x0 : (byte)0,
            //        this.pvSetCh3PwmParamsCallback);
            //}
           
        }

        private void m_trackBarCh3_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh3 = (Byte)this.m_trackBarCh3.Value;
            this.m_numericUpDownCh3.Value = m_pwmValueCh3;

            if (m_checkBoxSwitchCh3.Checked)
            {
                NativeAPI.LC_SetPwmParams(m_DevId,
                    0x08,
                    (byte)this.m_comboBoxModeCh3.SelectedIndex,
                    m_pwmValueCh3,
                    (byte)this.m_HoldingTimeCh3.Value,
                    1,
                    this.pvSetCh3PwmParamsCallback);
                
            }
 
        }

        private void m_numericUpDownCh3_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh3 = (Byte)this.m_numericUpDownCh3.Value;
            this.m_trackBarCh3.Value = m_pwmValueCh3;
        }



        public static void setPwmParamsCallBackCh3(LC_CALLBACK_ARG_T args)
        {
            if (args.setPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "Set params to CH3 Error");
            }
        }
        public static void getPwmParamsCallBackCh3(LC_CALLBACK_ARG_T args)
        {
            if (args.getPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "getPwmParamsCh3 Error");
            }
            else
            {
                pThis.m_checkBoxSwitchCh3.Checked = args.getPwmParamsCallbackArg.pwmOnOff > 0 ? true : false;
                pThis.m_trackBarCh3.Value = args.getPwmParamsCallbackArg.pwmValue;
                pThis.m_comboBoxModeCh3.SelectedIndex = args.getPwmParamsCallbackArg.pwmMode;
                pThis.m_HoldingTimeCh3.Value = args.getPwmParamsCallbackArg.pwmHoldingTime;
            }
        }

        //*************************************************CHANNEL 0 ************************************************//
        public static void getPwmParamsCallBackCh0(LC_CALLBACK_ARG_T args)
        {
            if (args.setPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "Set params to CH0 Error");
            }
        }


        public static void setPwmParamsCallBackCh0(LC_CALLBACK_ARG_T args)
        {
            if (args.getPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "getPwmParamsCh0 Error");
            }
            else
            {
                pThis.m_checkBoxSwitchCh0.Checked = args.getPwmParamsCallbackArg.pwmOnOff > 0 ? true : false;
                pThis.m_trackBarCh0.Value = args.getPwmParamsCallbackArg.pwmValue;
                pThis.m_comboBoxModeCh0.SelectedIndex = args.getPwmParamsCallbackArg.pwmMode;
                pThis.m_HoldingTimeCh0.Value = args.getPwmParamsCallbackArg.pwmHoldingTime;
            }
        }
        private void m_btnReadCh0_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_GetPwmParams(m_DevId, 0x01, this.pvGetCh0PwmParamsCallback);
        }

        private void m_btnWriteCh0_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                   0x01,
                   (byte)this.m_comboBoxModeCh0.SelectedIndex,
                   m_pwmValueCh0,
                   (byte)this.m_HoldingTimeCh0.Value,
                   m_checkBoxSwitchCh0.Checked ? (byte)0x01 : (byte)0,
                   this.pvSetCh3PwmParamsCallback);
        }

        private void m_checkBoxSwitchCh0_CheckedChanged(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                    0x01,
                    (byte)this.m_comboBoxModeCh0.SelectedIndex,
                    m_pwmValueCh3,
                    (byte)this.m_HoldingTimeCh0.Value,
                    m_checkBoxSwitchCh0.Checked ? (byte)0x01 : (byte)0,
                    this.pvSetCh3PwmParamsCallback);
            //Check ON OFF State and Change Text
            if (m_checkBoxSwitchCh0.Checked)
            {
                this.m_checkBoxSwitchCh0.Text = "ON";
                this.m_checkBoxSwitchCh0.BackColor = Color.Green;
            }
            else
            {
                this.m_checkBoxSwitchCh0.Text = "OFF";
                this.m_checkBoxSwitchCh0.BackColor = Color.Red;
            }
        }

        private void m_HoldingTimeCh0_ValueChanged(object sender, EventArgs e)
        {

        }

        private void m_trackBarCh0_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh0 = (Byte)this.m_trackBarCh0.Value;
            this.m_numericUpDownCh0.Value = m_pwmValueCh0;

            if (m_checkBoxSwitchCh0.Checked)
            {
                NativeAPI.LC_SetPwmParams(m_DevId,
                    0x01,
                    (byte)this.m_comboBoxModeCh0.SelectedIndex,
                    m_pwmValueCh0,
                    (byte)this.m_HoldingTimeCh0.Value,
                    1,
                    this.pvSetCh3PwmParamsCallback);

            }
        }

        private void m_numericUpDownCh0_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh0 = (Byte)this.m_numericUpDownCh0.Value;
            this.m_trackBarCh0.Value = m_pwmValueCh0;
        }
    }
}
