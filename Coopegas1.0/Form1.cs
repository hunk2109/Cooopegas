using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Coopegas1._0
{
    public partial class Form1 : Form
    {
        SQLiteConnection cnx = new SQLiteConnection("Data Source=C:\\bdd\\coopegas.s3db; Version=3;");        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            SQLiteDataAdapter sda = new SQLiteDataAdapter("select count(*) user,pass from usuario where user = '"+txtuser.Text+"' and pass ='"+txtpass.Text+"'",cnx);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                Principal1 f = new Principal1();
                this.AddOwnedForm(f);
                this.Hide();
                f.ShowDialog(this);
                this.Show();
               txtuser.Clear();
                txtpass.Clear();
                    
            }

            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos!");
            }

        }
    }
}
