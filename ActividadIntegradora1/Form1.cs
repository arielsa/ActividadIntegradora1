using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace ActividadIntegradora1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            empresa = new Empresa();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void Mostrar ( DataGridView pDGV, Object pO )
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pO;
        }
        Regex re;
        Empresa empresa;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                re = new Regex(@"\d\d.\d{3}.\d{3}");
                string dni = Interaction.InputBox("DNI:  ");
                if (!(re.IsMatch(dni) && dni.Length == 10)) throw new Exception("error de formato");
                Persona p = new Persona(dni,"","");
                if (empresa.ValidaDni(p)) throw new Exception("la persona ya existe");
                p.Nombre = Interaction.InputBox("Nombre: ");
                p.Apellido = Interaction.InputBox("Apellido: ");
                empresa.AgregarPersona(p);
                Mostrar(dataGridView1, empresa.RetornaListaPersona());
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.MultiSelect = false;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count == 0) throw new Exception("lista vacia");
                DataGridViewRow f = dataGridView1.SelectedRows [0];
                Persona p = new Persona(f.Cells[0].Value.ToString(), "", "");
                empresa.BorrarPersona(p);
                Mostrar(dataGridView1, empresa.RetornaListaPersona());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                re = new Regex(@"^[A-Z]{3}\s\d{3}$");
                string patente = Interaction.InputBox("Patente:  ");
                if (!(re.IsMatch(patente) && patente.Length == 7)) throw new Exception("error de formato");
                Auto a = new Auto(patente, "", "","", 0);
                if (empresa.ValidarPatente(a)) throw new Exception("la patente ya existe");

                a.Marca = Interaction.InputBox("Marca: ");
                a.Modelo = Interaction.InputBox("Modelo: ");

                re = new Regex(@"^\d{4}$");              
                string año = Interaction.InputBox("Año: ");
                if (!(re.IsMatch(año))) throw new Exception("error de formato para año");
                a.Año = año;

                decimal precioN = 0;
                try { precioN = decimal.Parse(Interaction.InputBox("Precio: "));}
                catch (Exception) { MessageBox.Show("formato incorrecto para precio");}                
                a.Precio =  precioN;
                if (a.Precio > 0) {empresa.AgregarAuto(a);}
                
                Mostrar(dataGridView2, empresa.RetornaListaAutos());
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count == 0) throw new Exception("lista vacia");
                DataGridViewRow f = dataGridView2.SelectedRows[0];
                Auto a = new Auto (f.Cells[0].Value.ToString(), "", "","",0);
                empresa.BorrarAuto(a);
                Mostrar(dataGridView2, empresa.RetornaListaAutos() );
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
