using System;
using System.ComponentModel.DataAnnotations;

namespace WebPasajero.Models
{
    public class Pasajero
    {
        public int PasajeroId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaNacimiento { get; set; }
        public string Ciudad { get; set; }
    }
}


