using OngProject.Core.Interfaces;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ActivitiesBusiness : IActivitiesService
    {
        public Task<Activities> CreateActivities(Activities activities)
        {
            throw new System.NotImplementedException();
        }

        public Task<Activities> GetActivitiesById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Activities>> GetAllActivities()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> RemoveActivities(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Activities> UpdateActivities(int id, Activities activities)
        {
            throw new System.NotImplementedException();
        }
    }
}
