using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Entities;
using OngProject.Repositories;
using OngProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Business
{
    public class ContactsBusiness : IContactsBusiness
    {
        private readonly IUnitOfWork _unitOfWork;
        public ContactsBusiness(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<ContactsDTO>> GetAllContacts()
        {
            List<Contacts> contactsList;
            List<ContactsDTO> contactsDTOList = new List<ContactsDTO>();

            contactsList = (List<Contacts>) await _unitOfWork.ContactsRepository.GetAll();

            foreach (Contacts c in contactsList)
            {
                contactsDTOList.Add(ContactsMapper.ContactsToContactsDTO(c));
            }

            return contactsDTOList;
        }
    }
}
