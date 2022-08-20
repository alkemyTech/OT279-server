using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    interface IActivitiesService
    {
        public List<Activities> GetAllActivities();
        public Activities GetActivitiesById(int id);
        public Activities CreateActivities(ActivitiesDTO activities);
        public bool RemoveActivities(int id);
        public Activities UpdateActivities(Activities activities);
 
    }
}
