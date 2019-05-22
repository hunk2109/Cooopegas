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
    public partial class Principal1 : Form
    {
        operaciones oper = new operaciones();

        public Principal1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnagreclient_Click(object sender, EventArgs e)
        {
            oper.consultasinreaultado("insert into cliente (nombres,apellidos,direccion,tel,cedula)values('"+txtnomb.Text+"','"+txtapelli.Text+"','"+txtdirecc.Text+"','"+txttel.Text+"','"+txtcedu.Text+"')");
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula from pago inner join cliente on idclient = cliente_idclient");

        }

        private void Principal1_Load(object sender, EventArgs e)
        {
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,monto_pag as Pago,cedula as Cedula from pago inner join cliente on idclient = cliente_idclient");
            dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario");



        }

        private void btnguardpres_Click(object sender, EventArgs e)
        {
            oper.consultasinreaultado("insert into desembolso(monto,fecha,interes,tiempo,cliente_idclient)values('"+txtmont.Text+"','"+dtpprest.Text+"','"+txtint.Text+"','"+cmbtiemp.Text+"','"+txtidcleintp.Text+"')");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula from pago inner join cliente on idclient = cliente_idclient");

        }

        private void dgvverclientprest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvverclientprest.Rows[e.RowIndex];
            txtidcleintp.Text = act.Cells["idclient"].Value.ToString();
        }

        private void btnguardpago_Click(object sender, EventArgs e)
        {
            oper.consultasinreaultado("insert into pago(monto_pag,fecha,cliente_idclient,desembolso_iddesemb)values('"+txtpago.Text+"','"+dtppagfec.Text+"','"+txtidclientpag.Text+"','"+txtidprestpag.Text+"')");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas  from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,monto_pag as Pago,cedula as Cedula from pago inner join cliente on idclient = cliente_idclient");


        }

        private void dgvprestpag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvprestpag.Rows[e.RowIndex];
            txtidclientpag.Text = act.Cells["Indentificacion"].Value.ToString();
            txtidprestpag.Text = act.Cells["ID"].Value.ToString();


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if(rbidclientp.Checked==true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where idclient ='"+txtbuscli.Text+"'");
            }

            else if(rbnombp.Checked==true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where nombres like'%" + txtbuscli.Text + "%'");


            }

            else if(rbapellip.Checked==true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where apellidos like'%" + txtbuscli.Text + "%'");

            }

            else if(rbcedup.Checked==true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where cedula like'%" + txtbuscli.Text + "%'");

            }
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            if (rbidpag.Checked == true)
            {
                dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula,fecha from pago inner join cliente on idclient = cliente_idclient where idpago = '"+txtbuscpag.Text+"'");

            }

            else if(rbfech.Checked==true)
            {
                dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula,fecha from pago inner join cliente on idclient = cliente_idclient where fecha like '%" + txtbuscpag.Text + "%'");

            }

            else if(rbpnombr.Checked == true)
            {
                dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula,fecha from pago inner join cliente on idclient = cliente_idclient where nombres like '%" + txtbuscpag.Text + "%'");

            }
        }

        private void txtbuscprest_TextChanged(object sender, EventArgs e)
        {
            if(rbbpid.Checked==true)
            {
                dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where ID = '"+txtbuscprest.Text+"'");

            }

            else if(rbpbnomb.Checked==true)
            {
                dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Nombres like '%" + txtbuscprest.Text + "%'");

            }

            else if(rbpbapell.Checked==true)
            {
                dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Apellidos like '%" + txtbuscprest.Text + "%'");

            }

            else if(rbpbcedu.Checked == true)
            {
                dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Cedula like '%" + txtbuscprest.Text + "%'");

            }
        }

        private void btnimpr_Click(object sender, EventArgs e)
        {
          
        }

        private void btnimpr_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtimpprest.Text))
            {
                DataSet ds = new DataSet();
                DataTable dt = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
                ds.Tables.Add(dt);
                ds.WriteXml(@"C:\factura\Prestamos.xml");
                Visor f = new Visor();
                f.Show();
            }

            else
            {
                DataSet ds = new DataSet();
                DataTable dt = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where ID = '"+txtimpprest.Text+"'");
                ds.Tables.Add(dt);
                ds.WriteXml(@"C:\factura\Prestamos.xml");
                Visor f = new Visor();
                f.Show();
            }
        }

        private void dgvvprest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvvprest.Rows[e.RowIndex];
            txtimpprest.Text = act.Cells["ID"].Value.ToString();
        }

        private void btnimprpago_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtimppago.Text))
            {
                DataSet ds = new DataSet();
                DataTable dt = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula from pago inner join cliente on idclient = cliente_idclient");
                ds.Tables.Add(dt);
                ds.WriteXml(@"C:\factura\Pagos.xml");
                visorpagos f = new visorpagos();
                f.Show();
            }

            else
            {
                DataSet ds = new DataSet();
                DataTable dt = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag ,cedula from pago inner join cliente on idclient = cliente_idclient where idpago ='"+txtimppago.Text+"'");
                ds.Tables.Add(dt);
                ds.WriteXml(@"C:\factura\Pagos.xml");
                visorpagos f = new visorpagos();
                f.Show();

            }

        }

        private void dgvpagos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvpagos.Rows[e.RowIndex];
            txtimppago.Text = act.Cells["ID"].Value.ToString();

        }

        private void dgvuser_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvuser.Rows[e.RowIndex];
            txtiduser.Text = act.Cells["iduser"].Value.ToString();
            txtuser.Text = act.Cells["user"].Value.ToString();
            txtpass.Text = act.Cells["pass"].Value.ToString();

        }

        private void btnmoduser_Click(object sender, EventArgs e)
        {
            if (rbadmin.Checked == true)
            {
                DialogResult result = MessageBox.Show("Seguro que desea Modificar?", "Modificar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oper.cosnsultaconresultado("update usuario set user = '" + txtuser.Text + "',pass = '" + txtpass.Text + "',tipo_user ='1' where iduser = '" + txtiduser.Text + "'");
                    txtiduser.Clear();
                    txtuser.Clear();
                    txtpass.Clear();
                    MessageBox.Show("Datos Actualizados");
                    dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario");

                }

            }

            else if (rbadmin.Checked == true)
            {
                DialogResult result = MessageBox.Show("Seguro que desea Modificar?", "Modificar", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    oper.cosnsultaconresultado("update usuario set user = '" + txtuser.Text + "',pass = '" + txtpass.Text + "',tipo_user = '2' where iduser = '" + txtiduser.Text + "'");
                    txtiduser.Clear();
                    txtuser.Clear();
                    txtpass.Clear();
                    MessageBox.Show("Datos Actualizados");
                    dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario");
                }

            }

            else
            {
                MessageBox.Show("Seleccione un nivel de Usuario!");
            }


            }

        private void btnborraruser_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea Borrar?", "Borrar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                oper.consultasinreaultado("delete from usuario where iduser = '" + txtiduser.Text + "'");
                txtiduser.Clear();
                txtuser.Clear();
                txtpass.Clear();
                MessageBox.Show("Datos Borrados!");
                dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario");

            }
        }

        private void btnnueuser_Click(object sender, EventArgs e)
        {
            if (rbadmin.Checked == true)
            {
                oper.consultasinreaultado("insert into usuario(user,pass,tipo_user)values('" + txtuser.Text + "','" + txtpass.Text + "','1')");
                dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario");
            }

            else if (rbuser.Checked == true)
            {
                oper.consultasinreaultado("insert into usuario(user,pass,tipo_user)values('" + txtuser.Text + "','" + txtpass.Text + "','2')");
                dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario");
            }

            else
            {
                MessageBox.Show("Seleccione un nivel de Usuario!");
            }
        }


        private bool isAdmin;

        public bool IsAdmin
        {
            get
            {
                return isAdmin;
            }

            set
            {
                isAdmin = value;
                tabControl5.Visible = isAdmin;
                
                
            }
        }
    }
    }


