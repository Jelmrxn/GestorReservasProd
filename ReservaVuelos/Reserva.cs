using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelos
{
    public abstract class Reserva
    {
        public string NombreCliente { get; set; }
        public int NumeroHabitacion { get; set; }
        public DateTime FechaReserva { get; set; }
        public int DuracionEstadia { get; set; }

        // Constructor con validaciones para asegurar que los datos sean correctos
        public Reserva(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracion)
        {
            if (string.IsNullOrWhiteSpace(nombreCliente)) throw new ArgumentException("El nombre del cliente es obligatorio.");
            if (duracion < 1) throw new ArgumentException("La estadía debe ser mayor a 1 noche.");

            NombreCliente = nombreCliente;
            NumeroHabitacion = numeroHabitacion;
            FechaReserva = fechaReserva;
            DuracionEstadia = duracion;
        }

        // Método abstracto (uso de polimorfismo) que será sobrecargado en clases derivadas
        public abstract decimal CalcularCostoTotal();
    }
}
