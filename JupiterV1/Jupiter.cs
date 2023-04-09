using Microsoft.Win32;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ValyseAPI;
using KrnlAPI;
using Oxygen;
using WeAreDevs_API;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Diagnostics;

namespace JupiterV1
{
    public partial class Jupiter : Form
    {
        ExploitAPI api = new ExploitAPI();
        MainAPI main = new MainAPI();
        Module dll = new Module();
        public Jupiter()
        {
            InitializeComponent();
            MainAPI.Load();
        }
        Point lastPoint;
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Executor_Frame.Visible = true;
            Settings_Frame.Visible = false;
            Home_Frame.Visible = false;
            Hub_Frame.Visible = false;
            Console_Frame.Visible = false;
        }

        private void siticoneOSToggleSwith1_CheckedChanged(object sender, EventArgs e)
        {
          if (siticoneOSToggleSwith1.Checked == true)
          { 
             button6.Visible = true; 
          }
          else
          {
            button6.Visible = false;
          }
        }

        private void siticoneOSToggleSwith2_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith2.Checked == true) Opacity = .75;
            else
            {
                Opacity = 1;
            }
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            Executor_Frame.Visible = false;
            Settings_Frame.Visible = true;
            Home_Frame.Visible = false;
            Hub_Frame.Visible = false;
            Console_Frame.Visible = false;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Hub_Frame.Visible = false;
            Executor_Frame.Visible = false;
            Settings_Frame.Visible = false;
            Home_Frame.Visible = true;
            Console_Frame.Visible = false;
        }

        private void siticoneOSToggleSwith3_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith3.Checked == true) TopMost = true;
            else
            {
                TopMost = false;
            }
        }

        private void siticoneOSToggleSwith6_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith6.Checked == true) textBox1.AppendText("[Console] " + "Krnl Selected\r\n");
        }

        private void siticoneOSToggleSwith5_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith5.Checked == true) textBox1.AppendText("[Console] " + "WRD Selected\r\n");
        }

        private async void Jupiter_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            wc.Proxy = null;
            try
            {
                RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Internet Explorer\\Main\\FeatureControl\\FEATURE_BROWSER_EMULATION", true);
                string friendlyName = AppDomain.CurrentDomain.FriendlyName;
                bool flag2 = registryKey.GetValue(friendlyName) == null;
                if (flag2)
                {
                    registryKey.SetValue(friendlyName, 11001, RegistryValueKind.DWord);
                }
                registryKey = null;
                friendlyName = null;
            }
            catch (Exception)
            {
            }
            webBrowser1.Url = new Uri(string.Format("file:///{0}/Monaco/Monaco.html", Directory.GetCurrentDirectory()));
            await Task.Delay(500);
            webBrowser1.Document.InvokeScript("SetTheme", new string[]
            {
                   "Jupiter" 
                   /*
                    There are 2 Themes Dark and Light
                   */
            });
            webBrowser1.Document.InvokeScript("SetText", new object[]
            {
                 "--[[Jupiter is the Largest Planet in the Solar System]]--"
            });
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UI_Frame.Visible = true;
            Execution_Frame.Visible = false;
            Extra_Frame.Visible = false;
            Credits_Frame.Visible = false;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UI_Frame.Visible = false;
            Execution_Frame.Visible = true;
            Extra_Frame.Visible = false;
            Credits_Frame.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UI_Frame.Visible = false;
            Execution_Frame.Visible = false;
            Extra_Frame.Visible = true;
            Credits_Frame.Visible = false;
        }

        private void siticoneOSToggleSwith4_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith4.Checked == true) button3.Visible = true;
            else
            {
                button3.Visible = false;
            }
        }

        private void siticoneOSToggleSwith5_CheckedChanged_1(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith5.Checked == true) button4.Visible = true;
            else
            {
                button4.Visible = false;
            }
        }

        private void siticoneOSToggleSwith6_CheckedChanged_1(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith6.Checked == true) button5.Visible = true;
            else
            {
                button5.Visible = false;
            }
        }

        private void siticoneMaterialTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string script = obj.ToString();

            if (Valyse_Check.Checked == true) Module.Inject();
            if (Krnl_Check.Checked == true) MainAPI.Inject();
            if (Oxy_Check.Checked == true) API.Inject();
            if (WRD_Check.Checked == true) api.LaunchExploit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string script = obj.ToString();

            if (Valyse_Check.Checked == true) Module.Execute(script);
            if (Krnl_Check.Checked == true) MainAPI.Execute(script);
            if (Oxy_Check.Checked == true) Execution.Execute(script);
            if (WRD_Check.Checked == true) api.SendLuaScript(script);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (Functions.openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string MainText = File.ReadAllText(Functions.openfiledialog.FileName);
                    if (Valyse_Check.Checked == true) Module.Execute(MainText);
                    if (Krnl_Check.Checked == true) MainAPI.Execute(MainText);
                    if (Oxy_Check.Checked == true) Execution.Execute(MainText);
                    if (WRD_Check.Checked == true) api.SendLuaScript(MainText);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (Functions.openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string MainText = File.ReadAllText(Functions.openfiledialog.FileName);
                    webBrowser1.Document.InvokeScript("SetText", new object[]
                    {
                          MainText
                    });

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string Document = obj.ToString();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(Document);
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Executor_Frame.Visible = false;
            Settings_Frame.Visible = false;
            Home_Frame.Visible = false;
            Hub_Frame.Visible = true;
            Console_Frame.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("SetText", new object[]
         {
                ""
         });
        }

        private void siticoneOSToggleSwith7_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith7.Checked == true)
            {
                ExecuteFile_Icon.Visible = true; 
                Execute_Icon.Visible = true;
                Open_Icon.Visible = true;
                Save_Icon.Visible = true;
                Inject_Icon.Visible = true;
                Clear_Icon.Visible = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button6.Visible = false;
            }
            else
            {
                ExecuteFile_Icon.Visible = false;
                Execute_Icon.Visible = false;
                Open_Icon.Visible = false;
                Save_Icon.Visible = false;
                Inject_Icon.Visible = false;
                Clear_Icon.Visible = false;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button5.Visible = true;
                button6.Visible = true;
                webBrowser1.Width = 587;
            }
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Execute_Icon_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string script = obj.ToString();

            if (Valyse_Check.Checked == true) Module.Execute(script);
            if (Krnl_Check.Checked == true) MainAPI.Execute(script);
            if (Oxy_Check.Checked == true) Execution.Execute(script);
            if (WRD_Check.Checked == true) api.SendLuaScript(script);
        }

        private void Clear_Icon_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.InvokeScript("SetText", new object[]
         {
                ""
         });
        }

        private void Open_Icon_Click(object sender, EventArgs e)
        {
            if (Functions.openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string MainText = File.ReadAllText(Functions.openfiledialog.FileName);
                    webBrowser1.Document.InvokeScript("SetText", new object[]
                    {
                          MainText
                    });

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void ExecuteFile_Icon_Click(object sender, EventArgs e)
        {
            if (Functions.openfiledialog.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    string MainText = File.ReadAllText(Functions.openfiledialog.FileName);
                    if (Valyse_Check.Checked == true) Module.Execute(MainText);
                    if (Krnl_Check.Checked == true) MainAPI.Execute(MainText);
                    if (Oxy_Check.Checked == true) Execution.Execute(MainText);
                    if (WRD_Check.Checked == true) api.SendLuaScript(MainText);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
        }

        private void Save_Icon_Click(object sender, EventArgs e)
        {
            HtmlDocument document = webBrowser1.Document;
            string scriptName = "GetText";
            object[] args = new string[0];
            object obj = document.InvokeScript(scriptName, args);
            string Document = obj.ToString();

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter sw = new StreamWriter(s))
                {
                    sw.Write(Document);
                }
            }
        }

        private void Inject_Icon_Click(object sender, EventArgs e)
        {
            if (Valyse_Check.Checked == true) Module.Inject();
            if (Krnl_Check.Checked == true) MainAPI.Inject();
            if (Oxy_Check.Checked == true) API.Inject();
            if (WRD_Check.Checked == true) api.LaunchExploit();
        }

        private void pictureBox21_Click(object sender, EventArgs e)
        {   
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (Stream s = File.Open(saveFileDialog1.FileName, FileMode.CreateNew))
                using (StreamWriter stream = new StreamWriter(s))
                {
                    stream.Write(textBox1.Text);
                    textBox1.AppendText("[Console]" + "Exported.\r\n");
                }
            }
        }

        private void pictureBox20_Click(object sender, EventArgs e)
        {
            Executor_Frame.Visible = false;
            Settings_Frame.Visible = false;
            Home_Frame.Visible = false;
            Hub_Frame.Visible = false;
            Console_Frame.Visible = true;
        }

        private void Valyse_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Valyse_Check.Checked == true) textBox1.AppendText("[Console] " + "Valyse Selected\r\n");
        }

        private void Oxy_Check_CheckedChanged(object sender, EventArgs e)
        {
            if (Oxy_Check.Checked == true) textBox1.AppendText("[Console] " + "Oxygen Selected\r\n");
        }

        private void siticoneOSToggleSwith8_CheckedChanged(object sender, EventArgs e)
        {
            if (siticoneOSToggleSwith8.Checked == true) ;
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            UI_Frame.Visible = false;
            Execution_Frame.Visible = false;
            Extra_Frame.Visible = false;
            Credits_Frame.Visible = true;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            Process.Start("https://discord.gg/cwmFG4j85p");
        }

        private void button20_Click(object sender, EventArgs e)
        {
            Process.Start("https://scriptblox.com");
        }

        private void pictureBox22_Click(object sender, EventArgs e)
        {
            Process[] roblox = Process.GetProcesses();

            foreach (Process openedroblox in roblox)

            {

                bool flag = openedroblox.ProcessName == "RobloxPlayerBeta";

                if (flag)

                {
                    openedroblox.Kill();
                    textBox1.AppendText("[Console]" + " Killed ROBLOX");
                }
            }
        }
    }
}
