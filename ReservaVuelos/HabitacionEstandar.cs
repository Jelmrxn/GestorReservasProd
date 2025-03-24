using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelos
{
    public class HabitacionEstandar : Reserva
    {
        private const decimal TarifaFija = 50000; // Tarifa fija por noche

        public HabitacionEstandar(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracion)
            : base(nombreCliente, numeroHabitacion, fechaReserva, duracion) { }

        // Sobrecarga del método CalcularCostoTotal
        public override decimal CalcularCostoTotal()
        {
            return TarifaFija * DuracionEstadia;
        }
    }
}
