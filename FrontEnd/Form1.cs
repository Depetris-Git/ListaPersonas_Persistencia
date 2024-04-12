using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BackEnd;

namespace FrontEnd
{
    public partial class Form1 : Form
    {
        int BDay = 0;
        int BMonth = 0;
        int BYear = 0;
        int TDay = 0;
        int TMonth = 0;
        int TYear = 0;
        int Age = 0;

        Persona person = new Persona();
        Personas Lista_de_Personas = new Personas();
        int Position = 0;


        public Form1()
        {
            InitializeComponent();

            dataGridView.DataSource = Lista_de_Personas.lista_persona;

            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            dateTimePicker.MaxDate = DateTime.Today;
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "d-MMM-yyyy";
            dateTimePicker.CalendarFont =
                new System.Drawing.Font("Microsoft Sans Serif", 19F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dateTimePicker.Font =
                new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textB_DNI.Visible = false;
            textB_Nombre.Visible = false;
            textB_Apellido.Visible = false;
            textB_CUIL.Visible = false;
            textB_Edad.Visible = false;
            dateTimePicker.Visible = false;
            button_Menu.Visible = false;
            button_Agregar.Visible = false;
            dataGridView.Visible = false;
        }

        private void button_Agregar_Click(object sender, EventArgs e)
        {
            Persona per = new Persona();
            per.Agregar(textB_DNI.Text, textB_Nombre.Text, textB_Apellido.Text, textB_CUIL.Text, Convert.ToInt32(textB_Edad.Text), dateTimePicker.Value);

            Lista_de_Personas.InsertPersona(per);
        }

        private void button_Salir_Click(object sender, EventArgs e)
        {
            button_Ingresar.Visible = true;
            button_Salir.Visible = true;
            lb_Title.Visible = true;
            label1.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            textB_DNI.Visible = false;
            textB_Nombre.Visible = false;
            textB_Apellido.Visible = false;
            textB_CUIL.Visible = false; ;
            textB_Edad.Visible = false;
            dateTimePicker.Visible = false;
            button_Menu.Visible = false;
            button_Agregar.Visible = false;
            dataGridView.Visible = false;
        }

        private void button_Ingresar_Click(object sender, EventArgs e)
        {
            button_Ingresar.Visible = false;
            button_Salir.Visible = false;
            lb_Title.Visible = false;
            label1.Visible = true;
            label2.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            textB_DNI.Visible = true;
            textB_Nombre.Visible = true;
            textB_Apellido.Visible = true;
            textB_CUIL.Visible = true;
            textB_Edad.Visible = true;
            dateTimePicker.Visible = true;
            button_Menu.Visible = true;
            button_Agregar.Visible = true;
            dataGridView.Visible = true;
        }

        private void button_Salir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime BirthDate = dateTimePicker.Value;
            string StrBirthDate = BirthDate.ToShortDateString();
            string TodayDate = DateTime.Today.ToShortDateString();

            //ex    10/02/2008
            //      mm/dd/yyyy
            BDay = Convert.ToInt32(StrBirthDate.Split('/')[1]);
            BMonth = Convert.ToInt32(StrBirthDate.Split('/')[0]);
            BYear = Convert.ToInt32(StrBirthDate.Split('/')[2]);

            //ex    04/09/2024
            //      mm/dd/yyyy
            TDay = Convert.ToInt32(TodayDate.Split('/')[1]);
            TMonth = Convert.ToInt32(TodayDate.Split('/')[0]);
            TYear = Convert.ToInt32(TodayDate.Split('/')[2]);

            if (((TYear != BYear) && (BMonth > TMonth)) | ((BMonth == TMonth) && (TDay < BDay)))
            {
                Age = TYear - BYear - 1;
            }
            else
            {
                Age = TYear - BYear;
            }

            textB_Edad.Text = Age.ToString();
        }

        private void textB_Nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 38) || (e.KeyChar >= 40 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 95) || (e.KeyChar >= 123 && e.KeyChar <= 126) || (e.KeyChar >= 166 && e.KeyChar <= 180) || (e.KeyChar >= 240))
            {
                MessageBox.Show("Caracter no valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
        private void textB_Apellido_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 33 && e.KeyChar <= 38) || (e.KeyChar >= 40 && e.KeyChar <= 64) || (e.KeyChar >= 91 && e.KeyChar <= 95) || (e.KeyChar >= 123 && e.KeyChar <= 126) || (e.KeyChar >= 166 && e.KeyChar <= 180) || (e.KeyChar >= 240))
            {
                MessageBox.Show("Caracter no valido", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void textB_DNI_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58))
            {
                MessageBox.Show("Caracter no es un numero", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }
    }
}
