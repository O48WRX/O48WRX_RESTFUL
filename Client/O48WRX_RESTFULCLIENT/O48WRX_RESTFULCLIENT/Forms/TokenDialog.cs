using O48WRX_RESTFULCLIENT.Classes;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O48WRX_RESTFULCLIENT.Forms
{
    public partial class TokenDialog : Form
    {
        TokenTransfer transfertoken;
        public TokenDialog(TokenTransfer token)
        {
            InitializeComponent();
            transfertoken = token;
            //MessageBox.Show(MD5Crypt.Encrypt("AdminToken"));
            TD_TokenBox.PasswordChar = '*';
        }

        private void TD_TokenSend_Click(object sender, EventArgs e)
        {
            if (TD_TokenBox.Text == "")
            {
                MessageBox.Show("Az kódmező nem lehet üres!");
                return;
            }
            if (MD5Crypt.Encrypt(TD_TokenBox.Text) == "1HDG6HyZ/XNDmi64zFI7eg==")
            {
                string data = TD_TokenBox.Text;
                transfertoken.Invoke(data);
                this.Close();
            }
            else
            {
                MessageBox.Show("Helytelen biztonsági kód!");
                return;
            }
        }
    }
}
