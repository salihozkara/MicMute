using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace MicMute
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            if (Config.Settings?.Keys !=null || Config.Settings?.Keys?.Count != 0)
            {
                Set(Config.Settings?.Keys);
            }
        }
        private void Set(HashSet<int> keys)
        {
            if (keys != null && keys.Count>0)
                KeyHook.Key(keys.ToHashSet(), (() =>
                {
                    MicControl.MuteOrUnMute();
                    Change();
                }));
        }
        private void StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var btn = (ToolStripMenuItem) sender;
            btn.Checked = !btn.Checked;
            if (btn.Checked)
            {
                StartWithComputer.Enable();
            }
            else
            {
                StartWithComputer.Disable();
            }

            
        }

        private void ChangeHotKeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new SetHotKey(Set);
            frm.ShowDialog();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Hide();
            Change();
            startToolStripMenuItem.Checked = StartWithComputer.Status();
        }

        private void MuteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MicControl.MuteOrUnMute();
            Change();
        }

        public void Change()
        {
            var resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            if (MicControl.MuteStatus())
            {
                notifyIcon.Text = "Mute";
                notifyIcon.Icon= ((Icon)(resources.GetObject("mute")));
            }
            else
            {
                notifyIcon.Text = "Unmute";
                notifyIcon.Icon = ((Icon)(resources.GetObject("unmute")));
            }
            muteToolStripMenuItem.Checked = MicControl.MuteStatus();
        }
    }
}
