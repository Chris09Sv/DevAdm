﻿//using Microsoft.AspNetCore
using DevControl.Models;
using DevControl.Models.Establecimientos;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevControl.Data
{

    public class DevContext : IdentityDbContext 

    {

        public DevContext(DbContextOptions<DevContext> options):base (options)
        {
            
        }

        public DbSet<DevControl.Models.UsuariosViewModel> UsuariosViewModel { get; set; } = default!;
        public DbSet<TbCategoria> tbCategorias { get; set; } 
        public DbSet<TbInstitucion> tbInstitucion { get; set; } = default!;
        public DbSet<TbSubsector> tbSubsectors { get; set; } = default!;
        public DbSet<TbEstablecimientos> tbEstablecimientos { get; set; } = default!;
        public DbSet<TbProvincias> tbProvincias { get; set; } 
        public DbSet<TbMunicipio> tbMunicipios { get; set; } 
        public DbSet<TbDistrito> tbDistritos { get; set; } = default!;
        public DbSet<TbSector> tbSectores { get; set; } = default!;
        public DbSet<TbNivel> tbNivel { get; set; } = default!;

        public DbSet<TbCapacidad> tbCapacidad { get;set;} = default!;
        public DbSet<TbSecciones> tbSecciones { get;set;} = default!;
        public DbSet<TbArea> tbArea { get;set;} = default!;





    }

}