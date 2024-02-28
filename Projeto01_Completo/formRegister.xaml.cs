using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Projeto01_Completo.DAL;
using Projeto01_Completo.DTO;
using System;
using System.Collections.Generic;
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

namespace Projeto01_Completo
{
    /// <summary>
    /// Lógica interna para formRegister.xaml
    /// </summary>
    public partial class formRegister : Window
    {
        public formRegister()
        {
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Usuario = txbUsuario.Text;
            usuarios.Senha = txbSenha.Password;
            usuarios.ConfirmeSenha = txbConfirmeSenha.Password;
                    

            if (String.IsNullOrWhiteSpace(usuarios.Usuario))
            {
                txbUsuario.Focus();
                ExceptionBook.ExceptionConsultar(1);
                MessageBox.Show(ExceptionBook.ExceptionConsultar(1));                
            }
            else if (String.IsNullOrWhiteSpace(usuarios.Senha)) 
            { 
                txbSenha.Focus();              
            }
            else if (String.IsNullOrWhiteSpace(usuarios.ConfirmeSenha))
            {
                txbConfirmeSenha.Focus();               
            }

            else if (txbSenha.Password != txbConfirmeSenha.Password)
            {
                MessageBox.Show("As senhas não correspondem.", "Falha ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
                txbSenha.Clear();
                txbConfirmeSenha.Clear();
                txbSenha.Focus();
                txbSenha.BorderBrush = Brushes.Red;
            }
            else if (new Usuarios { Usuario = txbUsuario.Text }.ValidarUsuario())
            {
                MessageBox.Show("O nome de usuario escolhido já está em uso. Por favor escolha um novo nome de usuario.", "Falha ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);

                txbUsuario.Clear();
                txbUsuario.Focus();                
                txbUsuario.BorderBrush = Brushes.Red;
            }
            else
            {
                string query = "Insert Into Usuarios(Ide, Usuario, Senha, Acesso, Status) Values (@Ide, @Usuario, @Senha, @Acesso, @Status)";
                try
                {
                    using var conn = AcessoBD.Conectar();
                    using var command = new SqlCommand(query, conn);
                    string[] names = new string[] { "@Ide", "@Usuario", "@Senha", "@Acesso", "@Status" };
                    object[] values = new object[] { Guid.NewGuid(), txbUsuario.Text, txbSenha.Password, 1, 0 };
                    AcessoBD.FillParameters(command, names, values);
                    AcessoBD.ExecutarCommand(command);
                    AcessoBD.Desconectar();
                    MessageBox.Show("Parabéns! Seu cadastro foi concluído com sucesso. \nClique em 'Fazer Login' para acessar sua conta.", "Cadastrado Concluido", MessageBoxButton.OK);
                    txbUsuario.Clear();
                    txbSenha.Clear();
                    txbConfirmeSenha.Clear();
                    txbUsuario.Focus();
                }
                catch (SqlException ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }            
        }

        private void btnLimparDados_Click(object sender, RoutedEventArgs e)
        {
            txbUsuario.Clear();
            txbSenha.Clear();
            txbConfirmeSenha.Clear();
            txbUsuario.Focus();            
        }

        private void lblFazerLogin_Click(object sender, RoutedEventArgs e) 
        { 
            new MainWindow().Show();
            this.Close();
        }

        private void MostrarSenha_Checked(object sender, RoutedEventArgs e)
        {
            txbExibirSenha.Text = txbSenha.Password;
            txbExibirConfirmaSenha.Text = txbConfirmeSenha.Password;
            txbSenha.Visibility = Visibility.Collapsed;
            txbConfirmeSenha.Visibility = Visibility.Collapsed;
            txbExibirSenha.Visibility = Visibility.Visible;
            txbExibirConfirmaSenha.Visibility = Visibility.Visible;
        }
        private void MostrarSenha_Unchecked(object sender, RoutedEventArgs e)
        {
            txbExibirSenha.Visibility = Visibility.Collapsed;
            txbExibirConfirmaSenha.Visibility = Visibility.Collapsed;
            txbSenha.Visibility = Visibility.Visible;
            txbConfirmeSenha.Visibility = Visibility.Visible;
        }

        private void txbUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {
            txbUsuario.BorderBrush = Brushes.Red;
        }
    }
}
