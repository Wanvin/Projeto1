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
            Usuarios usuarios = new Usuarios();
            usuarios.Usuario = txbUsuario.Text;
            usuarios.Senha = txbSenha.Password;

            try
            {
                string query = "Select Usuario from Usuarios Where Usuario = '" + usuarios.Usuario + "' and Senha = '" + usuarios.Senha + "' and Status = 0";
                using var conn = AcessoBD.Conectar();
                using var command = new SqlCommand(query, conn);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {

                    MessageBox.Show("Logado");
                }
                else 
                {
                    MessageBox.Show("Credenciais inválidas", "Falha ao logar" , MessageBoxButton.OK, MessageBoxImage.Error);
                    txbUsuario.Clear();
                    txbSenha.Clear();
                    txbUsuario.Focus();
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

        private void btnLimparDados_Click(object sender, RoutedEventArgs e)
        {
            txbUsuario.Clear();
            txbSenha.Clear();
        }

        private void MostrarSenha_Checked(object sender, RoutedEventArgs e)
        {
            txbMostrarSenha.Text = txbSenha.Password;
            txbSenha.Visibility = Visibility.Collapsed;
            txbMostrarSenha.Visibility = Visibility.Visible;
        }
        private void MostrarSenha_Unchecked(object sender, RoutedEventArgs e)
        {
            txbMostrarSenha.Visibility = Visibility.Collapsed;
            txbSenha.Visibility = Visibility.Visible;
        }
    }
}