using DevControl.Models;
using DevControl.Models.Establecimientos;
using DevControl.Models.VieModel;

namespace DevControl.Services
{

    public interface IData
    {
        IEnumerable<UsuariosViewModel> GetTbUsuarios();
        IEnumerable<vmEstablecimientos> GetVmEstablecimientos();

        void AddUsuarioCentro(int usuario, int centro);
        List<T> LoadDataVp<T, U>(string sql, U parameters, string connectionString);


        void AddEstablecimiento(TbEstablecimientos tbEstablecimientos);
        void AddEstablecimientoSat(TbEstablecimientos tbEstablecimientos);
        void UpdateEstablecimiento(TbEstablecimientos tbEstablecimientos);



    }

}