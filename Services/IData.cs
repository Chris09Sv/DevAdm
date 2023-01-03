using DevControl.Models;

namespace DevControl.Services
{

    public interface IData
    {
        IEnumerable<UsuariosViewModel> GetTbUsuarios();
        void AddUsuarioCentro(int usuario, int centro);
        // void AddUsuarioCentro(int usuario, int centro);

    }

}