using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISendGridBusiness
    {
        public Task<bool> WelcomeEmail(string email);
    }
}
