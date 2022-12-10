using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VARLightControl
{
    public partial class LoginForm : Form
    {

        string configFilePath = "";
        string selectFilePath = "";
        public LoginForm()
        {
            InitializeComponent();
            configFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.ini");//Created in the current program path
            selectFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "select.ini");

            List<string> stringList = INIHelper.ReadSections(configFilePath);
            this.comboBox1.DataSource = stringList;

            string selectItem = INIHelper.Read("SELECTED", "Name", " ", selectFilePath);
            this.comboBox1.SelectedItem = selectItem;

        }

        private void m_btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void m_btnAccept_Click(object sender, EventArgs e)
        {
            INIHelper.Write("SELECTED", "Name", this.comboBox1.SelectedItem.ToString(), selectFilePath);
            string selectCfgPath = INIHelper.Read(this.comboBox1.SelectedItem.ToString(), "ConfigPath", "", configFilePath);
            INIHelper.Write("SELECTED", "ConfigPath", selectCfgPath, selectFilePath);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
