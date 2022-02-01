using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Res.Exceptions;
namespace Res.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _reservations;

        public ReservationBook()
        {
            _reservations = new List<Reservation>();
        }

        /// <summary>
        /// Get all reservation.
        /// </summary>
        /// <returns>All reservation in the reservation book.</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservations;
        }

        public void AddReservation(Reservation reservation)
        {
            foreach(Reservation existingReversation in _reservations)
            {
                if(existingReversation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(existingReversation, reservation);

                }
            }

            _reservations.Add(reservation);
        }
    }
}
