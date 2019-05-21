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
        }

        private void Principal1_Load(object sender, EventArgs e)
        {
            dgvverclient.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvverclientprest.DataSource = oper.cosnsultaconresultado("select * from cliente");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.00)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvprestpag.DataSource = oper.cosnsultaconresultado("select idclient as Indentificacion,iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.0)+monto as Monto,fecha as Fecha, tiempo as Meses, (monto*(interes/100.0)+monto)/tiempo as Cuotas from desembolso  inner join cliente on   idclient = cliente_idclient");
            dgvpagos.DataSource = oper.cosnsultaconresultado("select * from pago");



        }

        private void btnguardpres_Click(object sender, EventArgs e)
        {
            oper.consultasinreaultado("insert into desembolso(monto,fecha,interes,tiempo,cliente_idclient)values('"+txtmont.Text+"','"+dtpprest.Text+"','"+txtint.Text+"','"+cmbtiemp.Text+"','"+txtidcleintp.Text+"')");
            dgvvprest.DataSource = oper.cosnsultaconresultado("select iddesemb as ID,nombres as Nombres,apellidos as Apellidos, cedula as Cedula,interes as Interes,monto*(interes/100.00) as Cargo ,monto*(interes/100.00)+monto as Monto,fecha as Fecha, tiempo as Meses from desembolso  inner join cliente on   idclient = cliente_idclient");
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
            dgvpagos.DataSource = oper.cosnsultaconresultado("select * from pago");

        }

        private void dgvprestpag_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow act = dgvprestpag.Rows[e.RowIndex];
            txtidclientpag.Text = act.Cells["Indentificacion"].Value.ToString();
            txtidprestpag.Text = act.Cells["ID"].Value.ToString();


        }
    }
}
