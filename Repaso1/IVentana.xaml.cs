using EjemploConexiónBDAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Repaso1
{
    /// <summary>
    /// Lógica de interacción para IVentana.xaml
    /// </summary>
    public partial class IVentana : Window
    {
        Empleado e;

        iventana listener;
        BDMySql db;
        DataTable tabla;
        public interface iventana
        {
            
        }

        public IVentana(Empleado e)
        {
            InitializeComponent();
            this.e = e;
        }
        public IVentana()
        {
            InitializeComponent();

            string sql = "SELECT * FROM departamentos";
            db=BDMySql.getInstance();
            tabla = db.LanzaSelect(sql, false);
            combo.SelectedValuePath = "NUM_DEPARTAMENTO";
            combo.DisplayMemberPath = "NOMBRE";
            combo.ItemsSource = tabla.DefaultView;


        }

        private void bt_aceptar_Click(object sender, RoutedEventArgs e)
        {
            int numero = 0;
            string nombre=tb_nombre.Text;
            string puesto=tb_puesto.Text;
            int nejefe=Int32.Parse(tb_jefe.Text);
            DateTime? f = fecha.SelectedDate;   //! ERROR
            decimal salario = Decimal.Parse(tb_salario.Text);
            decimal comision = Decimal.Parse(tb_comision.Text);
            bool? vip = Convert.ToBoolean(cb);
            int ndep = Int32.Parse(combo.SelectedValue.ToString());

            Empleado emp=new Empleado(numero,nombre,puesto,nejefe,f,salario,comision,vip,ndep);

            string sql_insert = "SELECT * FROM empleados";
            DataTable tabla_insert = db.LanzaSelect(sql_insert, true);
            DataRow fila=tabla_insert.NewRow();
            fila["NUM_EMPLEADO"] = numero;
            fila["NOMBRE_EMPLEADO"] = nombre;
            fila["PUESTO"] = puesto;
            fila["NUM_JEFE"] = nejefe;
            fila["FECHA_ALTA"] = f;
            fila["SALARIO"] = salario;
            fila["COMISION"] = comision;
            fila["VIP"] = vip;
            fila["NUM_DEPARTAMENTO"] = ndep;
            tabla_insert.Rows.Add(fila);
            MessageBox.Show("Empleado insertado con exito");
            Close();

        }

        private void bt_cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
