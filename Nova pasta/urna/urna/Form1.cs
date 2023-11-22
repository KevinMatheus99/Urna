using System.Media;
using System.Windows.Forms;

namespace urna
{
    public partial class Form1 : Form
    {

        private Dictionary<string, Candidato> _dicCandidato;
        
        private System.Windows.Forms.Timer relogio;

        public Form1()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.CenterScreen;
            relogio = new System.Windows.Forms.Timer();
            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;

            _dicCandidato = new Dictionary<string, Candidato>();
            _dicCandidato.Add("07", new Candidato() { Id = 7, Nome = "Cristiano Ronaldo", Partido = "Milior", Foto = Properties.Resources.cr7 });
            _dicCandidato.Add("10", new Candidato() { Id = 10, Nome = "Messi", Partido = "GOAT", Foto = Properties.Resources.messi });
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            RegistrarDigito("1");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void picFoto_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            RegistrarDigito("2");
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            RegistrarDigito("3");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            RegistrarDigito("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            RegistrarDigito("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            RegistrarDigito("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            RegistrarDigito("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            RegistrarDigito("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            RegistrarDigito("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            RegistrarDigito("0");
        }

        private void RegistrarDigito(string digito)
        {
            if (string.IsNullOrEmpty(txtPresidente1.Text))
            {
                txtPresidente1.Text = digito;
            }
            else if (string.IsNullOrEmpty(txtPresidente2.Text))
            {
                txtPresidente2.Text = digito;
                PreencherCandidato(txtPresidente1.Text, txtPresidente2.Text);
            }

            SoundPlayer s = new SoundPlayer(Properties.Resources.clique);
            s.Play();
        }

        private void PreencherCandidato(string d1, string d2)
        {
            if (_dicCandidato.ContainsKey(d1 + d2))
            {
                lblNome.Text = _dicCandidato[d1 + d2].Nome;
                lblPartido.Text = _dicCandidato[d1 + d2].Partido;
                picFoto.Image = _dicCandidato[d1 + d2].Foto;
            }
            else
            {
                MessageBox.Show("Candidato não encontrado!");
            }
        }

        private void btnbranco_Click(object sender, EventArgs e)
        {
            pnFim.Visible = true;
            Limpar();

            SoundPlayer s = new SoundPlayer(Properties.Resources.urna);
            s.Play();

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;
            relogio.Enabled = true;
            relogio.Start();
        }

        private void AcaoFinal(Object myObject, EventArgs myEventArgs)
        {
            relogio.Stop();
            relogio.Enabled = false;
            pnFim.Visible = false;
        }

        private void btncorrige_Click(object sender, EventArgs e)
        {
            Limpar();
            relogio.Stop();
            relogio.Enabled = false;
        }

        private void Limpar()
        {
            txtPresidente1.Text = "";
            txtPresidente2.Text = "";
            lblNome.Text = String.Empty;
            lblPartido.Text = String.Empty;
            picFoto.Image = null;
        }

        private void btnconfirma_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPresidente1.Text)) 
            {
                MessageBox.Show("Favor informar o candidato.");
                    return;
            }

            pnFim.Visible = true;
            Limpar();
            SoundPlayer s = new SoundPlayer(Properties.Resources.urna);
            s.Play();

            relogio.Tick += new EventHandler(AcaoFinal);
            relogio.Interval = 3000;
            relogio.Enabled = true;
            relogio.Start();
        }
    }

    public class Candidato
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Partido { get; set; }
        public Image Foto { get; set; }
    }

}
