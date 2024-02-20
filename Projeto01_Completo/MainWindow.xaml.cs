using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using Projeto01_Completo.DAL;
using Microsoft.Data.SqlClient;
using System.Data;
using Projeto01_Completo.DTO;

namespace Projeto01_Completo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "Select Usuario from Usuarios Where Usuario = '" + txbUsuario.Text + "' and Senha = '" + txbSenha.Password + "' and Status = 0";
                using var conn = AcessoBD.Conectar();
                using var command = new SqlCommand(query, conn);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {

                    MessageBox.Show("Logado");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
        private void lblCadastreAqui_Click(object sender, RoutedEventArgs e)
        {
            new formRegister().Show();
            this.Close();
        }

    }
}