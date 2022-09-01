using OngProject.Core.Models.DTOs;
using OngProject.Entities;

namespace OngProject.Core.Mapper
{
    public class ActivitiesMapper
    {
        public Activities FromActivitiesCreateDtoToActivities(ActivitiesCreateDTO activitiesDto)
        {
            var activities = new Activities
            {
                Name = activitiesDto.Name,
                Content = activitiesDto.Content,
            };
            return activities;
        }

        public ActivitiesDisplayDTO FromActivitiesToActivitiesDisplayDto(Activities activities)
        {
            var dto = new ActivitiesDisplayDTO
            {
                Name = activities.Name,
                Content = activities.Content,
                Image = activities.Image
            };
            return dto;
        }
    }
}
