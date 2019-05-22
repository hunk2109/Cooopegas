using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Text.RegularExpressions;

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
            oper.consultasinreaultado("insert into cliente (nombres,apellidos,direccion,tel,cedula)values('" + txtnomb.Text + "','" + txtapelli.Text + "','" + txtdirecc.Text + "','" + txttel.Text + "','" + txtcedu.Text + "')");
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");            
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula from pago inner join cliente on idclient = cliente_idclient");
            txtnomb.Clear();
            txtapelli.Clear();
            txtdirecc.Clear();
            txttel.Clear();
            txtcedu.Clear();

        }

        private void Principal1_Load(object sender, EventArgs e)
        {
            dgvverclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,monto_pag as Pago,cedula as Cedula from pago inner join cliente on idclient = cliente_idclient");
            dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario");
            dgvmodclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente");
            dgvmodprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,cliente_idclient as IDC,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto ,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvmodpago.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,cliente_idclient as IDC,desembolso_iddesemb as IDP,monto_pag as Pago,cedula as Cedula,fecha as Fecha from pago inner join cliente on idclient = cliente_idclient");



        }

        private void btnguardpres_Click(object sender, EventArgs e)
        {
            oper.consultasinreaultado("insert into desembolso(monto,fecha,interes,tiempo,cliente_idclient)values('" + txtmont.Text + "','" + dtpprest.Text + "','" + txtint.Text + "','" + cmbtiemp.Text + "','" + txtidcleintp.Text + "')");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula from pago inner join cliente on idclient = cliente_idclient");
            txtmont.Clear();
            txtint.Clear();
            txtidcleintp.Clear();


        }

        private void dgvverclientprest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvverclientprest.Rows[e.RowIndex];
            txtidcleintp.Text = act.Cells["idclient"].Value.ToString();
        }

        private void btnguardpago_Click(object sender, EventArgs e)
        {
            oper.consultasinreaultado("insert into pago(monto_pag,fecha,cliente_idclient,desembolso_iddesemb)values('" + txtpago.Text + "','" + dtppagfec.Text + "','" + txtidclientpag.Text + "','" + txtidprestpag.Text + "')");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas  from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,monto_pag as Pago,cedula as Cedula from pago inner join cliente on idclient = cliente_idclient");
            txtpago.Clear();
            txtidclientpag.Clear();
            txtidprestpag.Clear();


        }

        private void dgvprestpag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvprestpag.Rows[e.RowIndex];
            txtidclientpag.Text = act.Cells["Indentificacion"].Value.ToString();
            txtidprestpag.Text = act.Cells["ID"].Value.ToString();


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            if (rbidclientp.Checked == true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where idclient ='" + txtbuscli.Text + "'");
            }

            else if (rbnombp.Checked == true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where nombres like'%" + txtbuscli.Text + "%'");


            }

            else if (rbapellip.Checked == true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where apellidos like'%" + txtbuscli.Text + "%'");

            }

            else if (rbcedup.Checked == true)
            {
                dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente where cedula like'%" + txtbuscli.Text + "%'");

            }
        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {
            if (rbidpag.Checked == true)
            {
                dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula,fecha from pago inner join cliente on idclient = cliente_idclient where idpago = '" + txtbuscpag.Text + "'");

            }

            else if (rbfech.Checked == true)
            {
                dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula,fecha from pago inner join cliente on idclient = cliente_idclient where fecha like '%" + txtbuscpag.Text + "%'");

            }

            else if (rbpnombr.Checked == true)
            {
                dgvpagos.DataSource = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag,cedula,fecha from pago inner join cliente on idclient = cliente_idclient where nombres like '%" + txtbuscpag.Text + "%'");

            }
        }

        private void txtbuscprest_TextChanged(object sender, EventArgs e)
        {
            if (rbbpid.Checked == true)
            {
                dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where ID = '" + txtbuscprest.Text + "'");

            }

            else if (rbpbnomb.Checked == true)
            {
                dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Nombres like '%" + txtbuscprest.Text + "%'");

            }

            else if (rbpbapell.Checked == true)
            {
                dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Apellidos like '%" + txtbuscprest.Text + "%'");

            }

            else if (rbpbcedu.Checked == true)
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
                DataTable dt = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where ID = '" + txtimpprest.Text + "'");
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
                DataTable dt = oper.cosnsultaconresultado("select nombres,apellidos, idpago,monto_pag ,cedula from pago inner join cliente on idclient = cliente_idclient where idpago ='" + txtimppago.Text + "'");
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

        private void btnlimpclien_Click(object sender, EventArgs e)
        {
            txtnomb.Clear();
            txtapelli.Clear();
            txtdirecc.Clear();
            txttel.Clear();
            txtcedu.Clear();
        }

        private void btnlimp_Click(object sender, EventArgs e)
        {
            txtmont.Clear();
            txtint.Clear();
            txtidcleintp.Clear();
        }

        private void btnlimppago_Click(object sender, EventArgs e)
        {
            txtpago.Clear();
            txtidclientpag.Clear();
            txtidprestpag.Clear();

        }

        private void txtbusclie_TextChanged(object sender, EventArgs e)
        {
            if (rbidclient.Checked == true)
            {
                dgvverclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where ID = '" + txtbusclie.Text + "'");

            }

            else if (rbnombrcli.Checked == true)
            {
                dgvverclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where Nombres  like'%" + txtbusclie.Text + "%'");


            }

            else if (rbtelcli.Checked == true)
            {
                dgvverclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where Telefono like'%" + txtbusclie.Text + "%'");

            }

            else if (rbceducli.Checked == true)
            {
                dgvverclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where Cedula  like'%" + txtbusclie.Text + "%'");

            }
        }

        private void btnimprclient_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtidimpclient.Text))
            {
                DataSet ds = new DataSet();
                DataTable dt = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente");
                ds.Tables.Add(dt);
                ds.WriteXml(@"C:\factura\Clientes.xml");
                var f = new visorcliet();
                f.Show();
            }

            else
            {
                DataSet ds = new DataSet();
                DataTable dt = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where ID ='"+txtidimpclient.Text+"'");
                ds.Tables.Add(dt);
                ds.WriteXml(@"C:\factura\Clientes.xml");
                var f = new visorcliet();
                f.Show();

            }
        }

        private void dgvverclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvverclient.Rows[e.RowIndex];
            txtidimpclient.Text = act.Cells["ID"].Value.ToString();
        }

        private void dgvmodclient_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvmodclient.Rows[e.RowIndex];
            txtidmodcli.Text = act.Cells["ID"].Value.ToString();
            txtmodnomcli.Text = act.Cells["Nombres"].Value.ToString();
            txtmodape.Text = act.Cells["Apellidos"].Value.ToString();
            txtmoddriec.Text = act.Cells["Direccion"].Value.ToString();
            txtmodtel.Text = act.Cells["Telefono"].Value.ToString();
            txtmodcedu.Text = act.Cells["Cedula"].Value.ToString();
        }

        private void btnmodclient_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea Modificar?", "Modificar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                oper.consultasinreaultado("update cliente set nombres ='"+txtmodnomcli.Text+"',apellidos = '"+txtmodape.Text+"',direccion = '"+txtmoddriec.Text+"',tel ='"+txtmodtel.Text+"',cedula ='"+txtmodcedu.Text+"' where idclient = '"+txtidmodcli.Text+"'");
                dgvmodclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente");
                txtidmodcli.Clear();
                txtmodnomcli.Clear();
                txtmodape.Clear();
                txtmoddriec.Clear();
                txtmodtel.Clear();
                txtmodcedu.Clear();


            }

        }

        private void btnborrclien_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea Borrar?", "Borrar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                oper.consultasinreaultado("delete from cliente where idclient = '"+txtidmodcli.Text+"'");
                dgvmodclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente");
                txtidmodcli.Clear();
                txtmodnomcli.Clear();
                txtmodape.Clear();
                txtmoddriec.Clear();
                txtmodtel.Clear();
                txtmodcedu.Clear();

            }
        }

        private void txttel_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txttel_KeyDown(object sender, KeyEventArgs e)
        {

            string sVal = txttel.Text;

            if (!string.IsNullOrEmpty(sVal) && e.KeyCode != Keys.Back)
            {
                txttel.Text = _FormatPhone(sVal);
               
            }
        }

        public static string _FormatPhone(object phonevalue)
        {
            string returnPhone = "Format Err#";

            Int64 phoneDigits;
            string phoneNumber = phonevalue.ToString();

            if (Int64.TryParse(phoneNumber, out phoneDigits))
            {
                if (phoneNumber.Length == 10)
                {
                    return phoneDigits.ToString("(###) ###-####");
                }
                else if (phoneNumber.Length > 10)
                {
                    // determine the length of placeholders needed for the format
                    string format = "(###) ###-#### x"
                                        + new string('#', phoneNumber.Length - 10);
                    return phoneDigits.ToString(format);
                }
                else
                {
                    return phoneNumber;
                }
            }

            return returnPhone;
        }



        public static string _Formatid(object idvalue)
        {
            string returnPhone = "Format Err#";

            Int64 idDigits;
            string idNumber = idvalue.ToString();

            if (Int64.TryParse(idNumber, out idDigits))
            {
                if (idNumber.Length == 11)
                {
                    return idDigits.ToString("###-#######-#");
                }
                else if (idNumber.Length > 11)
                {
                    // determine the length of placeholders needed for the format
                    string format = "###-#######-# x"
                                        + new string('#', idNumber.Length - 11);
                    return idDigits.ToString(format);
                }
                else
                {
                    return idNumber;
                }
            }

            return returnPhone;
        }

        private void txtcedu_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void txtcedu_KeyDown(object sender, KeyEventArgs e)
        {
            string sVal = txtcedu.Text;

            if (!string.IsNullOrEmpty(sVal) && e.KeyCode != Keys.Back)
            {
                txtcedu.Text = _Formatid(sVal);

            }
        }

        private void dgvmodprest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvmodprest.Rows[e.RowIndex];
            txtidmodprest.Text = act.Cells["ID"].Value.ToString();
            txtmodmont.Text = act.Cells["monto"].Value.ToString();
            dtpmodfechprest.Text = act.Cells["Fecha"].Value.ToString();
            txtmodintprest.Text = act.Cells["Interes"].Value.ToString();
            cmbmodtiemp.Text = act.Cells["Meses"].Value.ToString();
            txtidmodprestcli.Text = act.Cells["IDC"].Value.ToString();
        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {
            if(rbidmodprest.Checked == true)
            {

                dgvmodprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,cliente_idclient as IDC,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto ,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where ID ='"+txtbuspresmod.Text+"'");
            }

            else if (rbnombmodprest.Checked==true)
            {

                dgvmodprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,cliente_idclient as IDC,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto ,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Nombres like '%" + txtbuspresmod.Text + "%'");
            }

            else if (rbmodfechaprest.Checked==true)
            {
                dgvmodprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,cliente_idclient as IDC,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto ,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Fecha like '%" + txtbuspresmod.Text + "%'");

            }

            else if(rbmodceduprest.Checked==true)
            {
                dgvmodprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,cliente_idclient as IDC,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto ,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient where Cedula like '%" + txtbuspresmod.Text + "%'");

            }
        }

        private void btnmodprest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea Modificar?", "Modificar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                oper.consultasinreaultado("update desembolso set monto = '"+txtmodmont.Text+"',fecha ='"+dtpmodfechprest.Text+"',interes ='"+txtmodintprest.Text+"', tiempo = '"+cmbmodtiemp.Text+ "',cliente_idclient ='"+txtidmodprestcli.Text+"' where iddesemb = '"+txtidmodprest.Text+"'");
                MessageBox.Show("Datos Actualizados");
                dgvmodprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,cliente_idclient as IDC,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto ,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
                txtidmodprest.Clear();
                txtidmodprestcli.Clear();
                txtmodmont.Clear();
                txtmodintprest.Clear();


            }

        }

        private void tabPage13_Click(object sender, EventArgs e)
        {

        }

        private void txtborrprest_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea Borrar?", "Borrar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                oper.consultasinreaultado("delete from desembolso where iddesemb = '"+txtidmodprest.Text+"'");
                MessageBox.Show("Datos Borrados");
                dgvmodprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,cliente_idclient as IDC,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto ,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
                txtidmodprest.Clear();
                txtidmodprestcli.Clear();
                txtmodmont.Clear();
                txtmodintprest.Clear();

            }

        }

        private void dgvmodpago_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvmodpago.Rows[e.RowIndex];
            txtmoidpago.Text  = act.Cells["ID"].Value.ToString();
            txtmodmontpag.Text = act.Cells["Pago"].Value.ToString();
            dtpmodpago.Text = act.Cells["Fecha"].Value.ToString();
            txtmodipprespag.Text = act.Cells["IDP"].Value.ToString();
            txtmodidcleinpag.Text = act.Cells["IDC"].Value.ToString();

        }

        private void btnmodpago_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea Modificar?", "Modificar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                oper.consultasinreaultado("update pago set idpago = '"+txtmoidpago.Text+"',monto_pag ='"+txtmodmontpag.Text+"',fecha ='"+dtpmodpago.Text+ "',cliente_idclient ='"+txtmodidcleinpag.Text+ "',desembolso_iddesemb = '"+txtmodipprespag.Text+ "' where idpago = '"+txtmoidpago.Text+"'");
                MessageBox.Show("Datos Actualizados");
                dgvmodpago.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,cliente_idclient as IDC,desembolso_iddesemb as IDP,monto_pag as Pago,cedula as Cedula,fecha as Fecha from pago inner join cliente on idclient = cliente_idclient");
                txtmoidpago.Clear();
                txtmodmontpag.Clear();
                txtmodidcleinpag.Clear();
                txtmodipprespag.Clear();

            }
        }

        private void btnborrarpag_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Seguro que desea Borrar?", "Borrar", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                oper.consultasinreaultado("delete from pago where idpago ='" + txtmoidpago.Text + "'");
                MessageBox.Show("Datos Borrados");
                dgvmodpago.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,cliente_idclient as IDC,desembolso_iddesemb as IDP,monto_pag as Pago,cedula as Cedula,fecha as Fecha from pago inner join cliente on idclient = cliente_idclient");
                txtmoidpago.Clear();
                txtmodmontpag.Clear();
                txtmodidcleinpag.Clear();
                txtmodipprespag.Clear();
            }

            }

        private void txtbususer_TextChanged(object sender, EventArgs e)
        {
            if (rbuserid.Checked == true)
            {
                dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario where iduser ='"+txtbususer.Text+"'");
            }


            else if (rbuseru.Checked == true)
            {
                dgvuser.DataSource = oper.cosnsultaconresultado("select * from usuario where user like '%" + txtbususer.Text + "%'");

            }
        }

        private void txtbuscl2_TextChanged(object sender, EventArgs e)
        {
            if (rbidclientmod.Checked == true)
            {
                dgvmodclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where ID = '"+txtbuscl2.Text+"'");

            }

            else if(rbmodnombcli.Checked == true)
            {
                dgvmodclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where Nombres like '%" + txtbuscl2.Text + "%'");

            }


            else if(rbmodceducli.Checked == true)
            {
                dgvmodclient.DataSource = oper.cosnsultaconresultado("select idclient as ID, nombres as Nombres, apellidos as Apellidos, direccion as Direccion,tel as Telefono,cedula as Cedula from cliente where Cedula like '%" + txtbuscl2.Text + "%'");

            }
        }

        private void txtbuspagmod_TextChanged(object sender, EventArgs e)
        {
            if (rbidmodpag.Checked == true)
            {
                dgvmodpago.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,cliente_idclient as IDC,desembolso_iddesemb as IDP,monto_pag as Pago,cedula as Cedula,fecha as Fecha from pago inner join cliente on idclient = cliente_idclient where ID ='"+txtbuspagmod.Text+"'");

            }


            else if (rbmodnombpag.Checked == true)
            {
                dgvmodpago.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,cliente_idclient as IDC,desembolso_iddesemb as IDP,monto_pag as Pago,cedula as Cedula,fecha as Fecha from pago inner join cliente on idclient = cliente_idclient where Nombres like '%" + txtbuspagmod.Text + "%'");

            }

            else if(rbmodcedupag.Checked == true)
            {
                dgvmodpago.DataSource = oper.cosnsultaconresultado("select nombres as Nombres,apellidos as Apellidos, idpago as ID,cliente_idclient as IDC,desembolso_iddesemb as IDP,monto_pag as Pago,cedula as Cedula,fecha as Fecha from pago inner join cliente on idclient = cliente_idclient where Cedula ='%" + txtbuspagmod.Text + "%'");

            }
        }
    }
}


