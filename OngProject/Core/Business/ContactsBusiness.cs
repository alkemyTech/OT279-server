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
        public ContactsBusiness(IUnitOfWork unitOfWork) //, IRepository<Contacts> repository
        {
            _unitOfWork = unitOfWork;
            //_repository = repository;
        }

        public async Task<List<ContactsDTO>> GetAllContacts()
        {
            //List<Contacts> contactsList;
            //List<ContactsDTO> contactsDTOList = new List<ContactsDTO>();

            //contactsList = (List<Contacts>) await _repository.GetAll();

            //foreach (Contacts c in contactsList)
            //{
            //    contactsDTOList.Add(ContactsMapper.ContactsToContactsDTO(c));
            //}

            //return contactsDTOList;
            return new List<ContactsDTO>();
        }
    }
}
