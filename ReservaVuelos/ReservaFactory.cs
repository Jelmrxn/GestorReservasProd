using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelos
{
    public static class ReservaFactory
    {
        // Método Factory que crea la reserva según el tipo de habitación
        public static Reserva CrearReserva(string tipo, string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracion)
        {
            switch (tipo)
            {
                case "Estándar":
                    return new HabitacionEstandar(nombreCliente, numeroHabitacion, fechaReserva, duracion);
                case "VIP":
                    return new HabitacionVIP(nombreCliente, numeroHabitacion, fechaReserva, duracion);
                default:
                    throw new ArgumentException("Tipo de habitación inválido.");
            }
        }
    }
}
