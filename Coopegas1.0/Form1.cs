using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace Coopegas1._0
{
    public partial class Form1 : Form
    {
        SQLiteConnection cnx = new SQLiteConnection("Data Source=C:\\Program Files\\hunk2109\\COOPEGASI1.0\\bdd\\coopegas.s3db; Version=3;");        
        public Form1()
        {
            InitializeComponent();
        }

        private void btnentrar_Click(object sender, EventArgs e)
        {
            if (cmbadmin.Text == "Administrador")
            {
                SQLiteDataAdapter sda = new SQLiteDataAdapter("select count(*) user,pass,tipo_user from usuario where user = '" + txtuser.Text + "' and pass ='" + txtpass.Text + "' and tipo_user = '1'", cnx);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows[0][0].ToString() == "1")
                {
                    Principal1 f = new Principal1 { IsAdmin = true };
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

           
               else if (cmbadmin.Text == "Usuario")
                {
                    SQLiteDataAdapter sda = new SQLiteDataAdapter("select count(*) user,pass,tipo_user from usuario where user = '" + txtuser.Text + "' and pass ='" + txtpass.Text + "' and tipo_user = '2'", cnx);
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

            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos!");
            }

        }

        private void btnlimpiar_Click(object sender, EventArgs e)
        {
            txtuser.Clear();
            txtpass.Clear();


        }
    }
}

