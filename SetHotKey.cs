using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Shapes;
using KeyEventArgs = System.Windows.Forms.KeyEventArgs;
using KeyEventHandler = System.Windows.Input.KeyEventHandler;

namespace MicMute
{
    public partial class SetHotKey : Form
    {
        private readonly Action<HashSet<int>> _action;
        public SetHotKey(Action<HashSet<int>> action)
        {
            _action = action;
            InitializeComponent();
            _keys = Config.Settings?.Keys ?? new HashSet<int>();
            TextChange();
        }

        private void TextChange()
        {
            textBoxHotKey.Text = string.Join("+", _keys.Cast<Keys>());
        }

        private readonly HashSet<int> _keys;
        private void SetHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            

            _keys.Add(KeyInterop.VirtualKeyFromKey(KeyInterop.KeyFromVirtualKey(e.KeyValue)));
            TextChange();
        }



        private void OkBtn_Click(object sender, EventArgs e)
        {

            _action(_keys);
            if (Config.Settings != null) Config.Settings.Keys = _keys;
            Config.Save();
        }

        private void TextBoxHotKey_Click(object sender, EventArgs e)
        {
            _keys.Clear();
            TextChange();
        }
    }
}
