using DevControl.Models;
using DevControl.Models.Establecimientos;

namespace DevControl.Services
{

    public interface IData
    {
        IEnumerable<UsuariosViewModel> GetTbUsuarios();
        IEnumerable<vmEstablecimientos> GetVmEstablecimientos();

        void AddUsuarioCentro(int usuario, int centro);
        // void AddUsuarioCentro(int usuario, int centro);

    }

}