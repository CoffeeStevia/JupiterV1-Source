using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JupiterV1
{
    internal class Functions
    {
        // Credits to Axon at https://github.com/rakion99/Axon for this snippet which is inside Axon's Functions.cs
        public static OpenFileDialog openfiledialog = new OpenFileDialog
        {
            Filter = "Lua Script lua,txt (*.lua),(*.txt)|*.lua|All files (*.*), (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true,
            Title = "Jupiter"
        };
    }
}
