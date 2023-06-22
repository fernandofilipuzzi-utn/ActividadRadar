using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Radar
{
    public partial class FormPrincipal : Form
    {
        ControlRadar control = new ControlRadar();

        public FormPrincipal()
        {
            InitializeComponent();

            control.AgregarControl("OXD456", 30, false);
            control.AgregarControl("OXD457", 30, false);
            control.AgregarControl("OXD110", 30, false);
            control.AgregarControl("OXD477", 120, false);
            control.AgregarControl("OXD557", 100, false);
            btnListarInfractores.PerformClick();
        }

        private void btnAgregarVehiculo_Click(object sender, EventArgs e)
        {
            FormVehiculo fControl = new FormVehiculo();

            if (fControl.ShowDialog() == DialogResult.OK)
            {
                string patente=fControl.tbPatente.Text;
                double velocidad = Convert.ToDouble( fControl.tbPatente.Text);
                bool esOficial = fControl.rbEsOficial.Checked;
                control.AgregarControl(patente, velocidad, esOficial);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string patente = tbPatente.Text;

            control.Ordenar();
            Vehiculo controlado=control.BuscarPorPatente(patente);
            
            lbtInforme.Items.Clear();

            if(controlado!=null)
                lbtInforme.Items.Add($"{controlado.Patente}");
            else
                lbtInforme.Items.Add($"{patente} no encontrado.");
        }

        private void btnListarInfractores_Click(object sender, EventArgs e)
        {
            lbtInforme.Items.Clear();

            for(int n=0;n<control.CantidadVehiculo;n++)
                lbtInforme.Items.Add($"{control.VerVehiculosInfractores(n).Patente}");
        }
    }
}
