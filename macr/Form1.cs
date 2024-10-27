using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Windows.Media.Animation;

namespace macr
{
    public partial class Form1 : Form
    {
        bool vklMacros = false;
        Thread t = new Thread(() =>
        {
            while (true)
            {
                if (Keyboard.IsKeyDown(Key.P))
                {
                    SendKeys.SendWait("HelloNIGGA");
                }
            }
        });
        public Form1()
        {
            InitializeComponent();
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Suspend();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (vklMacros) {
                t.Suspend();
                vklMacros = false;
            }
            else
            {
                t.Resume();
                vklMacros = true;

            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            t.Abort();
        }

    }
}