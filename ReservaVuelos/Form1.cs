using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReservaVuelos
{
    public partial class Form1: Form
    {
        private void Form1_Load(object sender, EventArgs e)
        {
            // Código de inicialización si es necesario
            dgvReservas.Columns.Add("NombreCliente", "Nombre Cliente");
            dgvReservas.Columns.Add("NumeroHabitacion", "Número Habitación");
            dgvReservas.Columns.Add("FechaReserva", "Fecha Reserva");
            dgvReservas.Columns.Add("Duracion", "Duración");
            dgvReservas.Columns.Add("TipoHabitacion", "Tipo Habitación");
        }

        private GestorReservas gestor;

        public Form1()
        {
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
            gestor = GestorReservas.Instancia;
            cmbTipoHabitacion.Items.AddRange(new string[] { "Estándar", "VIP" });

            List<Reserva> listaReservas = new List<Reserva>();

        }



        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string nombre = txtNombreCliente.Text;
                int numeroHabitacion = int.Parse(txtNumeroHabitacion.Text);
                int duracion = int.Parse(txtDuracion.Text);
                DateTime fecha = dtpFechaReserva.Value;
                string tipo = cmbTipoHabitacion.SelectedItem.ToString();

                Reserva nuevaReserva = ReservaFactory.CrearReserva(tipo, nombre, numeroHabitacion, fecha, duracion);
                gestor.AgregarReserva(nuevaReserva);

                MessageBox.Show("Reserva agregada con éxito.");
                ListarReservas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarReservas();
        }

        private void ListarReservas()
        {
            dgvReservas.Rows.Clear();
            foreach (var reserva in gestor.ObtenerReservas())
            {
                dgvReservas.Rows.Add(
                    reserva.NombreCliente,
                    reserva.NumeroHabitacion,
                    reserva.FechaReserva.ToShortDateString(),
                    reserva.DuracionEstadia,
                    reserva.GetType().Name,
                    reserva.CalcularCostoTotal()
                );
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvReservas.SelectedRows.Count > 0)
                {
                    int index = dgvReservas.SelectedRows[0].Index;
                    gestor.EliminarReserva(index);
                    MessageBox.Show("Reserva eliminada.");
                    ListarReservas();
                }
                else
                {
                    MessageBox.Show("Seleccione una reserva para eliminar.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dgvReservas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar que no se haga clic en la fila de encabezado
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvReservas.Rows[e.RowIndex];

                txtNombreCliente.Text = fila.Cells["NombreCliente"].Value.ToString();
                txtNumeroHabitacion.Text = fila.Cells["NumeroHabitacion"].Value.ToString();
                dtpFechaReserva.Text = fila.Cells["FechaReserva"].Value.ToString();
                txtDuracion.Text = fila.Cells["Duracion"].Value.ToString();
                cmbTipoHabitacion.Text = fila.Cells["TipoHabitacion"].Value.ToString();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvReservas.SelectedRows.Count > 0)
            {
                DataGridViewRow fila = dgvReservas.SelectedRows[0];

                txtNombreCliente.Text = fila.Cells["NombreCliente"].Value.ToString();
                txtNumeroHabitacion.Text = fila.Cells["NumeroHabitacion"].Value.ToString();
                dtpFechaReserva.Value = Convert.ToDateTime(fila.Cells["FechaReserva"].Value);
                txtDuracion.Text = fila.Cells["Duracion"].Value.ToString();
                cmbTipoHabitacion.Text = fila.Cells["TipoHabitacion"].Value.ToString();

                // Eliminar la fila seleccionada para actualizar con los nuevos datos
                dgvReservas.Rows.Remove(fila);
            }
            else
            {
                MessageBox.Show("Seleccione una reserva para editar.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dgvReservas.DataSource = null; // Desvincula el origen de datos
            dgvReservas.Rows.Clear();
        }

    }
}
