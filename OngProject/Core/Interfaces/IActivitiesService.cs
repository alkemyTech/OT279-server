using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    interface IActivitiesService
    {
        public Task<List<Activities>> GetAllActivities();
        public Task<Activities> GetActivitiesById(int id);
        public Task<Activities> CreateActivities(ActivitiesDTO activities);
        public Task<bool> RemoveActivities(int id);
        public Task<Activities> UpdateActivities(int id, ActivitiesDTO activities);
 
    }
}
