using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelos
{
    public class HabitacionVIP : Reserva
    {
        private const decimal TarifaVIP = 100000; // Tarifa fija por noche
        private const decimal Descuento = 0.20m;  // 20% de descuento si la reserva supera 5 noches

        public HabitacionVIP(string nombreCliente, int numeroHabitacion, DateTime fechaReserva, int duracion)
            : base(nombreCliente, numeroHabitacion, fechaReserva, duracion) { }

        // Sobrecarga del método CalcularCostoTotal
        public override decimal CalcularCostoTotal()
        {
            decimal costo = TarifaVIP * DuracionEstadia;
            if (DuracionEstadia > 5)
                costo -= costo * Descuento; // Aplica descuento del 20%
            return costo;
        }
    }
}
