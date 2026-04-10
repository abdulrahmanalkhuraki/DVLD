using DVLD___Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD___Business.Utility
{
    public static class clsMessages
    {
        public static DialogResult Error(string message)
        {
            return MessageBox.Show(message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }

        public static DialogResult Confirm(string message)
        {
            return MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult Success(string message)
        {
            return MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
