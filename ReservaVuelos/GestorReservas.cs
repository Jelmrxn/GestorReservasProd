using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReservaVuelos
{
    public class GestorReservas
    {
        private static GestorReservas instancia; // Instancia única del Singleton
        private List<Reserva> reservas;

        // Constructor privado para evitar instanciación externa
        private GestorReservas()
        {
            reservas = new List<Reserva>();
        }

        // Propiedad para obtener la única instancia
        public static GestorReservas Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new GestorReservas();
                return instancia;
            }
        }

        // Método para agregar una reserva con validación de duplicados
        public void AgregarReserva(Reserva reserva)
        {
            if (reservas.Any(r => r.NumeroHabitacion == reserva.NumeroHabitacion && r.FechaReserva == reserva.FechaReserva))
                throw new InvalidOperationException("Ya existe una reserva para esta habitación en la fecha seleccionada.");

            reservas.Add(reserva);
        }

        public void EditarReserva(int index, Reserva nuevaReserva)
        {
            if (index >= 0 && index < reservas.Count)
                reservas[index] = nuevaReserva;
        }

        public void EliminarReserva(int index)
        {
            if (index >= 0 && index < reservas.Count)
                reservas.RemoveAt(index);
        }

        public List<Reserva> ObtenerReservas()
        {
            return reservas;
        }
    }
}
