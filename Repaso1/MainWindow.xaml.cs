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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Repaso1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IVentana.iventana
    {

        BDMySql db;
        DataTable tabla;
        String sql = "SELECT * FROM empleados";
        
        
        public MainWindow()
        {
            InitializeComponent();

            db = BDMySql.getInstance();
            tabla = db.LanzaSelect(sql, false);
            dg.ItemsSource = tabla.DefaultView;
            dg.AutoGenerateColumns = true;
            dg.CanUserAddRows = false;

       
        }

      

        private void btn_agregar_Click(object sender, RoutedEventArgs e)
        {
            IVentana iventana=new IVentana();
            iventana.ShowDialog();
        }

        private void btn_editar_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Elemento eliminado");
        }

 
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {

            Empleado emp = dg_Selected(sender,e);  //NO SE OBTENER EMP DESDE DATAGRID

            int nemp = emp.num;
            
            string sql_del = "SELECT * FROM empleados WHERE NUM_EMPLEADO = " + nemp;

            DataTable eliminar = db.LanzaSelect(sql_del, true);
            DataRow fila = eliminar.Rows[0];
            tabla.Rows.Remove(fila);
            MessageBox.Show("Elemento eliminado");
        }


        private Empleado dg_Selected(object sender, RoutedEventArgs e)
        {
            Empleado emp = (Empleado)dg.SelectedItem;
            MessageBox.Show(emp.nombre.ToString());

            return emp;
        }

        private void menu_salir_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("HOLA Q TAL");
            Close();
        }
    }
}
