using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface ISendGridBusiness
    {
        public Task WelcomeEmail(string email);
    }
}
