namespace DevControl.Models.Viepi
{
    public class vEstablecimientos
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public int institucion { get; set; }
        public int nivel1 { get; set; }
        public int nivel2 { get; set; }
        public int tipo { get; set; }
        public int idadm1 { get; set; }
        public int idadm2 { get; set; }
        public int pruebas { get; set; }
        public int lab { get; set; }
        public int estado { get; set; }
    }

    public class cntry_adm
    {
        public int idadm1 { get; set; }
        public int idadm2 { get; set; }
    }
}