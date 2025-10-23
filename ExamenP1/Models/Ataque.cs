using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenP1.Models
{
    public class Ataque
    {
        public int Id { get; set; }
        public string NombreAtaque { get; set; }
        public string TipoAtaque { get; set; }
        public string PoderBase { get; set; }
        public string DigimonId { get; set; }
    }
}