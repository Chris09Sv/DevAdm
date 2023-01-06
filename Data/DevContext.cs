using Microsoft.EntityFrameworkCore;
using DevControl.Models;
using DevControl.Models.Establecimientos;

namespace DevControl.Data
{

    public class DevContext : DbContext

    {

        public DevContext(DbContextOptions<DevContext> options):base (options)
        {
            
        }

        public DbSet<DevControl.Models.UsuariosViewModel> UsuariosViewModel { get; set; } = default!;
        public DbSet<TbCategoria> tbCategorias { get; set; } = default!;
        public DbSet<TbInstitucion> tbInstitucion { get; set; } = default!;
        public DbSet<TbSubsector> tbSubsectors { get; set; } = default!;
        public DbSet<TbEstablecimientos> tbEstablecimientos { get; set; } = default!;
        public DbSet<TbProvincias> tbProvincias { get; set; } = default!;
        public DbSet<TbMunicipio> tbMunicipios { get; set; } = default!;
        public DbSet<TbDistrito> tbDistritos { get; set; } = default!;
        public DbSet<TbSector> tbSectores { get; set; } = default!;
        public DbSet<TbNivel> tbNivel { get; set; } = default!;
        public DbSet<DevControl.Models.Establecimientos.vmEstablecimientos> vmEstablecimientos { get; set; } = default!;



    }

}