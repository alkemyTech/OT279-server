using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
using OngProject.Entities;
using OngProject.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ActivitiesBusiness : IActivitiesBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAmazonS3Client _amazonClient;

        public ActivitiesBusiness(IUnitOfWork unitOfWork, IAmazonS3Client amazonClient)
        {
            _unitOfWork = unitOfWork;
            _amazonClient = amazonClient;
        }

        public async Task<ActivitiesDisplayDTO> CreateActivities(ActivitiesCreateDTO activitiesDto)
        {
            if (activitiesDto != null)
            {
                var mapper = new ActivitiesMapper();
                var activity = mapper.FromActivitiesCreateDtoToActivities(activitiesDto);

                if(activitiesDto != null)
                {
                    activity.Image = await _amazonClient.UploadObject(activitiesDto.Image);
                }

                await _unitOfWork.ActivitiesRepository.Insert(activity);
                _unitOfWork.SaveChanges();

                var dto = mapper.FromActivitiesToActivitiesDisplayDto(activity);

                return dto;
            }
            return null;
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
