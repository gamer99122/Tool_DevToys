using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tool_DevToys
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            btnAction.Enabled = false;
            string strInput = rTxtInput.Text;
            string strOutput = Action(strInput);
            rTxtOutput.Text = strOutput;
            Clipboard.SetText(strOutput);
            btnAction.Enabled = true;
        }

        public string Action(string SQL)
        {
            StringBuilder sb = new StringBuilder();
            string[] lines = SQL.Split(new[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < lines.Length; i++)
            {
                string trimmedLine = lines[i].TrimEnd(); // 去掉行尾多餘的空格
                string formattedLine = $"\\n {trimmedLine}  "; // 統一在行尾加上兩個空格

                if (i == 0)
                    sb.AppendLine($"SQL = $\"{formattedLine}\";");
                else
                    sb.AppendLine($"SQL += $\"{formattedLine}\";");
            }
            return sb.ToString();
        }
    }
}
