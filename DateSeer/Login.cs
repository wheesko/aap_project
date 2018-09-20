using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DateSeer
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            Čia turėtų būt su duombaze kodas kad tikrintų ar yra duombazėj toks username ir pass
            Jei yra padaro this.Close(); manau reikia daryti dėl to kad resursų mažiau naudotų resursu




            Reikia sutvarkyti problema su kad kai switchini win formas tada neveikia viršui dešnėj
            esantis exit mygtukas nes jis uždaro tik viena win forma o kitu neuzdaro 


            */

            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide() ;
            Register reg = new Register();
            reg.Region = this.Region;
            reg.Show();
        
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }

        
}
