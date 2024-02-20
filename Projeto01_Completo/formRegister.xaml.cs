using Microsoft.Data.SqlClient;
using Projeto01_Completo.DAL;
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
            if (txbUsuario.Text == "" && txbSenha.ToString() == "" && txbConfirmeSenha.ToString() == "")
            {
                MessageBox.Show("Usuário e senha não foram preenchidos corretamente.", "Falha ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else if (txbSenha.Password != txbConfirmeSenha.Password)
            {
                MessageBox.Show("As senhas não correspondem.", "Falha ao Cadastrar", MessageBoxButton.OK, MessageBoxImage.Error);
                txbSenha.Clear();
                txbConfirmeSenha.Clear();
                txbSenha.Focus();
            }
            else
            {
                string query = "Insert Into Usuarios(Ide, Usuario, Senha, Acesso, Status) Values (@Ide, @Usuario, @Senha, @Acesso, @Status)";
                try
                {
                    using var conn = AcessoBD.Conectar();
                    using var command = new SqlCommand(query, conn);
                    string[] names = new string[] { "@Ide", "@Usuario", "@Senha", "@Acesso", "@Status" };
                    object[] values = new object[] { Guid.NewGuid(), txbUsuario.Text, txbSenha.Password, 1, 0};
                    AcessoBD.FillParameters(command, names, values);
                    AcessoBD.ExecutarCommand(command);
                    AcessoBD.Desconectar();
                    MessageBox.Show("Parabéns! Seu cadastro foi concluído com sucesso. \nClique em 'Fazer Login' para acessar sua conta.", "Cadastrado Concluido", MessageBoxButton.OK);
                    txbUsuario.Text = "";
                    txbSenha.Clear() ;
                    txbConfirmeSenha.Clear();

                }
                catch (SqlException ex)
                {

                    MessageBox.Show(ex.ToString());
                }
                
            }            
        }

        private void ckbExibirSenha_Checked(object sender, RoutedEventArgs e)
        {
                    
        }

        private void btnLimparDados_Click(object sender, RoutedEventArgs e)
        {
            txbUsuario.Text = "";
            txbSenha.Clear();
            txbConfirmeSenha.Clear();
            txbUsuario.Focus();
        }

        private void lblFazerLogin_Click(object sender, RoutedEventArgs e) 
        { 
            new MainWindow().Show();
            this.Close();
        }
    }
}
