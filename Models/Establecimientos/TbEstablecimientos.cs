using System.ComponentModel.DataAnnotations;

namespace DevControl.Models.Establecimientos
{
    public class TbEstablecimientos
    {
        public int Id { get; set; }
        public string Centro { get; set; }
        public int Institucion { get; set; }
        public int Categoria { get; set; }
        public int Subsector { get; set; }
        public int Nivel { get; set; }
        [Required]
        // public int? Capacidad { get; set; }
        public int Provincia { get; set; }
        public int Municipio { get; set; }
        public int Distrito { get; set; }
        public int Seccion { get; set; }

        public int? Sector { get; set; }
        public int? Area { get; set; }
        public int prueba { get; set; }
        public int Laboratorio { get; set; }
        public int? IdViepi { get; set; }
        public string? Sat { get; set; }
        public int Estado { get; set; }
        public DateTime? Creacion { get; set; }

        public DateTime? Activacion { get; set; }
        public DateTime? InActivacion { get; set; }
        public int Usuario { get; set; }




    }
}
