using Datos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EjercicioTarea
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void AceptarButton_Click(object sender, EventArgs e)
        {
            if (CorreoTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(CorreoTextBox, "Ingrese un correo");
                CorreoTextBox.Focus();
                return;
            }
            errorProvider1.Clear();
            if (ContrasenaTextBox.Text == String.Empty)
            {
                errorProvider1.SetError(ContrasenaTextBox, "Ingrese una contrasena");
                ContrasenaTextBox.Focus();
                return;
            }
            errorProvider1.Clear();

            UsuarioDatos userDatos = new UsuarioDatos();

            bool valido = await userDatos.LoginAsync(CorreoTextBox.Text, ContrasenaTextBox.Text);


            if (valido)
            {
                //Menu
                Inicio inicio = new Inicio();
                Hide();
                inicio.Show();


            }
            else
            {
                MessageBox.Show("Datos de Usuario Incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void CancelarButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}