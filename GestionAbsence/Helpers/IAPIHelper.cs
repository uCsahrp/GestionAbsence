using GestionAbsence.Models;
using System.Threading.Tasks;

namespace GestionAbsence.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}