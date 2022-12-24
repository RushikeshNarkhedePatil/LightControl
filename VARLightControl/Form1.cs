using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
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
        private int isOpen=0;       // check device open or not 

        // Light Control Values
        private UInt16 m_comPort = 3;
        private Int32 m_comPortOpenFlag = 0;
        private Byte m_DevId = 0x01;
        private Byte pwmMode = 0;

        private Byte m_pwmValueCh0 = 0;
        private Byte m_pwmValueCh1 = 0;
        private Byte m_pwmValueCh2 = 0;
        private Byte m_pwmValueCh3 = 0;

        string configPath = "";

        private LCCallbackMethod pvOpenComCallback = openComCallBcak;
        private LCCallbackMethod pvCloseComCallback = closeComCallBack;
        private LCCallbackMethod isOpenComCallback;
        private LCCallbackMethod pvSetGeneralParameterCallback= SetGeneralParameterCallback;
        private LCCallbackMethod pvgetGeneralParameterCallback= GetGeneralParameterCallback;

        private LCCallbackMethod pvGetCh3PwmParamsCallback = getPwmParamsCallBackCh3;
        private LCCallbackMethod pvSetCh3PwmParamsCallback = setPwmParamsCallBackCh3;
        private LCCallbackMethod pvGetCh0PwmParamsCallback = getPwmParamsCallBackCh0;
        private LCCallbackMethod pvSetCh0PwmParamsCallback = setPwmParamsCallBackCh0;
        private LCCallbackMethod pvGetCh1PwmParamsCallback = getPwmParamsCallBackCh1;
        private LCCallbackMethod pvSetCh1PwmParamsCallback = setPwmParamsCallBackCh1;
        private LCCallbackMethod pvGetCh2PwmParamsCallback = getPwmParamsCallBackCh2;
        private LCCallbackMethod pvSetCh2PwmParamsCallback = setPwmParamsCallBackCh2;

        // Parameter Control Callback Methods
        public static void SetGeneralParameterCallback(LC_CALLBACK_ARG_T arg)
        {
            if (arg.getGeneralParamCallbackArg.error != 0)
            {
                MessageBox.Show(pThis, "SetGeneralParameterCallback Error");
            }
            
        }
        public static void GetGeneralParameterCallback(LC_CALLBACK_ARG_T arg)
        {
            if (arg.getGeneralParamCallbackArg.error != 0)
            {
                MessageBox.Show(pThis, "SetGeneralParameterCallback Error");
            }
        }
        public Form1()
        {
            InitializeComponent();
            pThis = this;
            //SettingPanel.Enabled = false;   //Disabled Setting Pannel
            //this.m_comboBoxModeCh3.SelectedIndex = 0;

            this.m_comboBoxPort.Items.Add("COM3");      // Add ComboBox Item Value
            this.m_comboBoxPort.SelectedItem = "COM3";  

            // DIOLC_LibraryBaseInit
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

            // Software Mode
            //adding Software Mode values
            var Mode = new List<string>() // trigger mode, 0:Soft-switch, 1: hardware-switch, 2: Raising-Edge, 3: Soft - trigger
            {
                 "Soft Switch",
                 "Hardware Switch",
                 "External Trigger",
                 "Soft Trigger"
            };
            
            // Add Software Mode value inside ComboBox
            m_comboBoxModeCh3.Items.AddRange(Mode.ToArray());
            m_comboBoxModeCh0.Items.AddRange(Mode.ToArray());
            m_comboBoxModeCh1.Items.AddRange(Mode.ToArray());
            m_comboBoxModeCh2.Items.AddRange(Mode.ToArray());
            //Set Selected Index
            this.m_comboBoxModeCh3.SelectedIndex = 0;
            this.m_comboBoxModeCh0.SelectedIndex = 0;
            this.m_comboBoxModeCh1.SelectedIndex = 0;
            this.m_comboBoxModeCh2.SelectedIndex = 0;

            // Advanced Light Control Settings Set Values.
            var holdingTimeUnit = new List<string>()
            {
                "1000ms",
                "100ms",
                "10ms",
                "1ms"
            };
            // Add Value in ComboBox
            m_advHoldTimeCH0.Items.AddRange(holdingTimeUnit.ToArray());
            m_advHoldTimeCH1.Items.AddRange(holdingTimeUnit.ToArray());
            m_advHoldTimeCH2.Items.AddRange(holdingTimeUnit.ToArray());
            m_advHoldTimeCH3.Items.AddRange(holdingTimeUnit.ToArray());
            //Set Selected Index
            m_advHoldTimeCH0.SelectedIndex = 0;
            m_advHoldTimeCH1.SelectedIndex = 0;
            m_advHoldTimeCH2.SelectedIndex = 0;
            m_advHoldTimeCH3.SelectedIndex = 0;
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
                NativeAPI.DIOLC_OpenDevice(m_comPort, this.pvOpenComCallback);      //In Callback function not block of code
                m_comPortOpenFlag = 1;
            }
            else
            {
                NativeAPI.DIOLC_CloseDevice(m_comPort, this.pvCloseComCallback);    // Call Close Connection native method and pass port & callback method reference. 
                m_comPortOpenFlag = 0;
            }
            //// Check Com Port Open or Not and set values
            isOpen = NativeAPI.DIOLC_IsDeviceOpened(m_comPort, m_DevId);      //check is open or not 0 is success and 1 is error or not connected.
            if (isOpen == 0)
            {
                advLightControl.Enabled= true;      // Enabled Light Control Tab Control Pannel
                //// Channel 0 Enabled Values
                //m_comboBoxModeCh0.Enabled = true;
                //m_HoldingTimeCh0.Enabled = true;
                //m_numericUpDownCh0.Enabled = true;
                //m_trackBarCh0.Enabled = true;
                //m_checkBoxSwitchCh0.Enabled = true;
                //m_btnReadCh0.Enabled = true;
                //m_btnWriteCh0.Enabled = true;
                //// Channel 1 Enabled Values
                //m_comboBoxModeCh1.Enabled = true;
                //m_HoldingTimeCh1.Enabled = true;
                //m_numericUpDownCh1.Enabled = true;
                //m_trackBarCh1.Enabled = true;
                //m_checkBoxSwitchCh1.Enabled = true;
                //m_btnReadCh1.Enabled = true;
                //m_btnWriteCh1.Enabled = true;
                //// Channel 2 Enabled Values
                //m_comboBoxModeCh2.Enabled = true;
                //m_HoldingTimeCh2.Enabled = true;
                //m_numericUpDownCh2.Enabled = true;
                //m_trackBarCh2.Enabled = true;
                //m_checkBoxSwitchCh2.Enabled = true;
                //m_btnReadCh2.Enabled = true;
                //m_btnWriteCh2.Enabled = true;
                //// Channel 3 Enabled Values
                //m_comboBoxModeCh3.Enabled= true;
                //m_HoldingTimeCh3.Enabled= true;
                //m_numericUpDownCh3.Enabled= true;
                //m_trackBarCh3.Enabled= true;
                //m_checkBoxSwitchCh3.Enabled= true;
                //m_btnReadCh3.Enabled= true;
                //m_btnWriteCh3.Enabled= true;

                //// Enabled Advance Light Control Pannel.
                //SettingPanel.Enabled = true;   //Enabled Setting Pannel
                ////Set Holding Time Selected index
                // m_advHoldTimeCH0.SelectedIndex = 0;
                // m_advHoldTimeCH1.SelectedIndex = 0;
                // m_advHoldTimeCH2.SelectedIndex = 0;
                // m_advHoldTimeCH3.SelectedIndex = 0;
            }
            else
            {
                advLightControl.Enabled = false;      // Disabled Light Control Tab Control Pannel
                //// Channel 0
                //m_comboBoxModeCh0.Enabled = false;
                //m_HoldingTimeCh0.Enabled = false;
                //m_numericUpDownCh0.Enabled = false;
                //m_trackBarCh0.Enabled = false;
                //m_checkBoxSwitchCh0.Enabled = false;
                //m_btnReadCh0.Enabled = false;
                //m_btnWriteCh0.Enabled = false;
                //// Channel 1 
                //m_comboBoxModeCh1.Enabled = false;
                //m_HoldingTimeCh1.Enabled = false;
                //m_numericUpDownCh1.Enabled = false;
                //m_trackBarCh1.Enabled = false;
                //m_checkBoxSwitchCh1.Enabled = false;
                //m_btnReadCh1.Enabled = false;
                //m_btnWriteCh1.Enabled = false;
                //// Channel 2 
                //m_comboBoxModeCh2.Enabled = false;
                //m_HoldingTimeCh2.Enabled = false;
                //m_numericUpDownCh2.Enabled = false;
                //m_trackBarCh2.Enabled = false;
                //m_checkBoxSwitchCh2.Enabled = false;
                //m_btnReadCh2.Enabled = false;
                //m_btnWriteCh2.Enabled = false;
                //// Channel 3 
                //m_comboBoxModeCh3.Enabled = false;
                //m_HoldingTimeCh3.Enabled = false;
                //m_numericUpDownCh3.Enabled = false;
                //m_trackBarCh3.Enabled = false;
                //m_checkBoxSwitchCh3.Enabled = false;
                //m_btnReadCh3.Enabled = false;
                //m_btnWriteCh3.Enabled = false;

                //// Disabled Advance Light Control Pannel.
                //SettingPanel.Enabled = false;   //Disabled Setting Pannel
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
            //Get all Hardware version informations.
            pThis.m_lblHardwareVer.Text = string.Format("{0}.{1}.{2}",
                args.openComCallbackArg.hardwareMajorVer,
                args.openComCallbackArg.hardwareMinorVer,
                args.openComCallbackArg.hardwareRevVer);
            //Get all Firmware version informations.
            pThis.m_lblFirmwareVer.Text = string.Format("{0}.{1}.{2}",
                args.openComCallbackArg.firmwareMajorVer,
                args.openComCallbackArg.firmwareMinorVer,
                args.openComCallbackArg.firmwareRevVer);

            // Get all of the information set when opened
            //NativeAPI.LC_GetPwmParams(pThis.m_DevId, 0x08, pThis.pvGetCh3PwmParamsCallback);    // devid, light, callback,
            NativeAPI.LC_GetPwmParams(pThis.m_DevId, 0x08, pThis.pvGetCh3PwmParamsCallback);    // get existing set parameter information.
            NativeAPI.LC_GetPwmParams(pThis.m_DevId, 0x01, pThis.pvGetCh0PwmParamsCallback);    // Parameter Information Save automatically
            NativeAPI.LC_GetPwmParams(pThis.m_DevId, 0x02, pThis.pvGetCh1PwmParamsCallback);    // Using this API.
            NativeAPI.LC_GetPwmParams(pThis.m_DevId, 0x04, pThis.pvGetCh2PwmParamsCallback);
        }

        public static void closeComCallBack(LC_CALLBACK_ARG_T args)
        {
            pThis.m_btnConnect.Text = "Connect";
            pThis.m_btnConnect.BackColor = Color.Red;
            pThis.m_lblFirmwareVer.Text = "x.x.x";              //set version Text value
            pThis.m_lblHardwareVer.Text = "x.x.x";
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

            NativeAPI.LC_SetPwmParams(m_DevId,      // devId
                    0x08,                           // set params to CH3
                    //0x03,
                    (byte)this.m_comboBoxModeCh3.SelectedIndex, // soft-trigger mode
                    m_pwmValueCh3,                  // the brightness level is 80%
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
                    this.pvSetCh0PwmParamsCallback);

            }
        }

        private void m_checkBoxSwitchCh0_CheckedChanged(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                  0x01,
                  (byte)this.m_comboBoxModeCh0.SelectedIndex,
                  m_pwmValueCh0,
                  (byte)this.m_HoldingTimeCh0.Value,
                  m_checkBoxSwitchCh0.Checked ? (byte)0x01 : (byte)0,
                  this.pvSetCh0PwmParamsCallback);
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

        private void m_numericUpDownCh0_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh0= (Byte)this.m_numericUpDownCh0.Value;
            this.m_trackBarCh0.Value = m_pwmValueCh0;
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
                  this.pvSetCh0PwmParamsCallback);
        }
        public static void setPwmParamsCallBackCh0(LC_CALLBACK_ARG_T args)
        {
            if (args.setPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "Set params to CH0 Error");
            }
        }
        public static void getPwmParamsCallBackCh0(LC_CALLBACK_ARG_T args)
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



        //*************************************************CHANNEL 1 ************************************************//
        private void m_btnReadCh1_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_GetPwmParams(m_DevId, 0x02, this.pvGetCh3PwmParamsCallback);
        }

        private void m_btnWriteCh1_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                    0x02,
                    (byte)this.m_comboBoxModeCh1.SelectedIndex,
                    m_pwmValueCh1,
                    (byte)this.m_HoldingTimeCh1.Value,
                    m_checkBoxSwitchCh1.Checked ? (byte)0x01 : (byte)0,
                    this.pvSetCh1PwmParamsCallback);
        }
        private void m_checkBoxSwitchCh1_CheckedChanged(object sender, EventArgs e)
        {

            NativeAPI.LC_SetPwmParams(m_DevId,      // devId
                    0x02,                           // set params to CH3
                                                    //0x03,
                    (byte)this.m_comboBoxModeCh1.SelectedIndex, // soft-trigger mode
                    m_pwmValueCh1,                  // the brightness level is 80%
                    (byte)this.m_HoldingTimeCh1.Value,
                    m_checkBoxSwitchCh1.Checked ? (byte)0x01 : (byte)0,
                    this.pvSetCh1PwmParamsCallback);
            //Check ON OFF State and Change Text
            if (m_checkBoxSwitchCh1.Checked)
            {
                this.m_checkBoxSwitchCh1.Text = "ON";
                this.m_checkBoxSwitchCh1.BackColor = Color.Green;
            }
            else
            {
                this.m_checkBoxSwitchCh1.Text = "OFF";
                this.m_checkBoxSwitchCh1.BackColor = Color.Red;
            }

        }


        private void m_trackBarCh1_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh1 = (Byte)this.m_trackBarCh1.Value;
            this.m_numericUpDownCh1.Value = m_pwmValueCh1;

            if (m_checkBoxSwitchCh1.Checked)
            {
                NativeAPI.LC_SetPwmParams(m_DevId,
                    0x02,
                    (byte)this.m_comboBoxModeCh1.SelectedIndex,
                    m_pwmValueCh1,
                    (byte)this.m_HoldingTimeCh1.Value,
                    1,
                    this.pvSetCh1PwmParamsCallback);

            }

        }

        private void m_numericUpDownCh1_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh1 = (Byte)this.m_numericUpDownCh1.Value;
            this.m_trackBarCh1.Value = m_pwmValueCh1;
        }



        public static void setPwmParamsCallBackCh1(LC_CALLBACK_ARG_T args)
        {
            if (args.setPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "Set params to CH1 Error");
            }
        }
        public static void getPwmParamsCallBackCh1(LC_CALLBACK_ARG_T args)
        {
            if (args.getPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "getPwmParamsCh1 Error");
            }
            else
            {
                pThis.m_checkBoxSwitchCh1.Checked = args.getPwmParamsCallbackArg.pwmOnOff > 0 ? true : false;
                pThis.m_trackBarCh1.Value = args.getPwmParamsCallbackArg.pwmValue;
                pThis.m_comboBoxModeCh1.SelectedIndex = args.getPwmParamsCallbackArg.pwmMode;
                pThis.m_HoldingTimeCh1.Value = args.getPwmParamsCallbackArg.pwmHoldingTime;
            }
        }


        //*************************************************CHANNEL 2 ************************************************//

        private void m_checkBoxSwitchCh2_CheckedChanged(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                  0x04,
                  (byte)this.m_comboBoxModeCh2.SelectedIndex,
                  m_pwmValueCh2,
                  (byte)this.m_HoldingTimeCh2.Value,
                  m_checkBoxSwitchCh2.Checked ? (byte)0x01 : (byte)0,
                  this.pvSetCh2PwmParamsCallback);
            //Check ON OFF State and Change Text
            if (m_checkBoxSwitchCh2.Checked)
            {
                this.m_checkBoxSwitchCh2.Text = "ON";
                this.m_checkBoxSwitchCh2.BackColor = Color.Green;
            }
            else
            {
                this.m_checkBoxSwitchCh2.Text = "OFF";
                this.m_checkBoxSwitchCh2.BackColor = Color.Red;
            }
        }
        public static void setPwmParamsCallBackCh2(LC_CALLBACK_ARG_T args)
        {
            if (args.setPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "Set params to CH2 Error");
            }
        }
        public static void getPwmParamsCallBackCh2(LC_CALLBACK_ARG_T args)
        {
            if (args.getPwmParamsCallbackArg.error > 0)
            {
                MessageBox.Show(pThis, "getPwmParamsCh2 Error");
            }
            else
            {
                pThis.m_checkBoxSwitchCh2.Checked = args.getPwmParamsCallbackArg.pwmOnOff > 0 ? true : false;
                pThis.m_trackBarCh2.Value = args.getPwmParamsCallbackArg.pwmValue;
                pThis.m_comboBoxModeCh2.SelectedIndex = args.getPwmParamsCallbackArg.pwmMode;
                pThis.m_HoldingTimeCh2.Value = args.getPwmParamsCallbackArg.pwmHoldingTime;
            }
        }

        private void m_btnReadCh2_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_GetPwmParams(m_DevId, 0x04, this.pvGetCh2PwmParamsCallback);
        }

        private void m_btnWriteCh2_Click(object sender, EventArgs e)
        {
            NativeAPI.LC_SetPwmParams(m_DevId,
                  0x04,
                  (byte)this.m_comboBoxModeCh2.SelectedIndex,
                  m_pwmValueCh2,
                  (byte)this.m_HoldingTimeCh2.Value,
                  m_checkBoxSwitchCh2.Checked ? (byte)0x01 : (byte)0,
                  this.pvSetCh2PwmParamsCallback);
        }

        private void m_numericUpDownCh2_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh2 = (Byte)this.m_numericUpDownCh2.Value;
            this.m_trackBarCh2.Value = m_pwmValueCh2;
        }


        private void m_trackBarCh2_ValueChanged(object sender, EventArgs e)
        {
            m_pwmValueCh2 = (Byte)this.m_trackBarCh2.Value;
            this.m_numericUpDownCh2.Value = m_pwmValueCh2;

            if (m_checkBoxSwitchCh2.Checked)
            {
                NativeAPI.LC_SetPwmParams(m_DevId,
                    0x04,
                    (byte)this.m_comboBoxModeCh2.SelectedIndex,
                    m_pwmValueCh2,
                    (byte)this.m_HoldingTimeCh2.Value,
                    1,
                    this.pvSetCh2PwmParamsCallback);

            }
        }

        private void m_checkBoxStartDoTest_CheckedChanged(object sender, EventArgs e)
        {
            if (m_checkBoxStartDoTest.Checked)      //set values
            {
                m_checkBoxDO0.Checked = false;
                m_checkBoxDO1.Checked = false;
                m_checkBoxDO2.Checked = false;
                m_checkBoxDO3.Checked = false;
                m_checkBoxDO4.Checked = false;
                m_checkBoxDO5.Checked = false;
                m_checkBoxDO6.Checked = false;
                m_checkBoxDO7.Checked = false;
                m_checkBoxDO8.Checked = false;
                m_checkBoxDO9.Checked = false;
                m_checkBoxDO10.Checked = false;
                m_checkBoxDO11.Checked = false;
                m_checkBoxDO12.Checked = false;
                m_checkBoxDO13.Checked = false;
                m_checkBoxDO14.Checked = false;
                m_checkBoxDO15.Checked = false;


                m_dioTestStartFlag = 1;

            }
            else
            {
                m_dioTestStartFlag = 0;
            }

        }

        // Digital Output
        private void m_checkBoxDO_CheckedChanged(object sender, EventArgs e)
        {
            if (m_dioTestStartFlag == 1)
            {

            }
        }

        // Advanced Light Control Setting.
        private void m_advReadCH0_Click(object sender, EventArgs e)
        {
            // Get the holding time unit of the channel 0
            NativeAPI.DIOLC_GetGeneralParam(m_DevId, // DevId
             10, // Parameter ID
             1, // Parameter Length
            pvgetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH0.Text = m_advHoldTimeCH0.SelectedItem.ToString();
        }

        private void m_advWriteCH0_Click(object sender, EventArgs e)
        {
            // Set the holding time unit of the channel 0 to 100ms
            NativeAPI.DIOLC_SetGeneralParam(m_DevId, // DevId
             10, // Parameter ID
             1, // Parameter Length
             (Byte)this.m_advHoldTimeCH0.SelectedIndex, // Parameter Value
            pvSetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH0.Text = m_advHoldTimeCH0.SelectedItem.ToString();
        }

        private void m_advReadCH1_Click(object sender, EventArgs e)
        {
            // Get the holding time unit of the channel 0
            NativeAPI.DIOLC_GetGeneralParam(m_DevId, // DevId
             11, // Parameter ID
             1, // Parameter Length
            pvgetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH1.Text = m_advHoldTimeCH1.SelectedItem.ToString();
        }

        private void m_advWriteCH1_Click(object sender, EventArgs e)
        {
            // Set the holding time unit of the channel 0 to 100ms
            NativeAPI.DIOLC_SetGeneralParam(m_DevId, // DevId
             11, // Parameter ID
             1, // Parameter Length
             (Byte)this.m_advHoldTimeCH1.SelectedIndex, // Parameter Value
            pvSetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH1.Text = m_advHoldTimeCH1.SelectedItem.ToString();
        }

        private void m_advReadCH2_Click(object sender, EventArgs e)
        {
            // Get the holding time unit of the channel 0
            NativeAPI.DIOLC_GetGeneralParam(m_DevId, // DevId
             12, // Parameter ID
             1, // Parameter Length
            pvgetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH2.Text=m_advHoldTimeCH2.SelectedItem.ToString();
        }

        private void m_advWriteCH2_Click(object sender, EventArgs e)
        {
            // Set the holding time unit of the channel 0 to 100ms
            NativeAPI.DIOLC_SetGeneralParam(m_DevId, // DevId
             12, // Parameter ID
             1, // Parameter Length
             (Byte)this.m_advHoldTimeCH2.SelectedIndex, // Parameter Value
            pvSetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH2.Text = m_advHoldTimeCH2.SelectedItem.ToString();
        }

        private void m_advReadCH3_Click(object sender, EventArgs e)
        {
            // Get the holding time unit of the channel 0
            NativeAPI.DIOLC_GetGeneralParam(m_DevId, // DevId
             13, // Parameter ID
             1, // Parameter Length
            pvgetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH3.Text = m_advHoldTimeCH3.SelectedItem.ToString();
        }

        private void m_advWriteCH3_Click(object sender, EventArgs e)
        {
            // Set the holding time unit of the channel 0 to 100ms
            NativeAPI.DIOLC_SetGeneralParam(m_DevId, // DevId
             13, // Parameter ID
             1, // Parameter Length
             (Byte)this.m_advHoldTimeCH3.SelectedIndex, // Parameter Value
            pvSetGeneralParameterCallback // Operate call back
            );
            lblAdvHoldCH3.Text = m_advHoldTimeCH3.SelectedItem.ToString();
        }
    }
}
