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
        public static OpenFileDialog openfiledialog = new OpenFileDialog
        {
            Filter = "Lua Script lua,txt (*.lua),(*.txt)|*.lua|All files (*.*), (*.*)|*.*",
            FilterIndex = 1,
            RestoreDirectory = true,
            Title = "Jupiter"
        };
    }
}
