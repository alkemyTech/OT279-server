using OngProject.Core.Interfaces;
using OngProject.Core.Mapper;
using OngProject.Core.Models.DTOs;
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

        public async Task<List<ContactDTO>> GetAllContacts()
        {
            List<Contacts> contactsList;
            List<ContactDTO> contactsDTOList = new List<ContactDTO>();

            contactsList = (List<Contacts>) await _unitOfWork.ContactsRepository.GetAll();

            foreach (Contacts c in contactsList)
            {
                contactsDTOList.Add(ContactsMapper.ContactsToContactsDTO(c));
            }

            return contactsDTOList;
        }

        public async Task<ContactDTO> CreateContact(ContactCreateDTO contactDto)
        {
            var contact = ContactsMapper.FromContactCreateDtoToContact(contactDto);

            await _unitOfWork.ContactsRepository.Insert(contact);
            _unitOfWork.SaveChanges();

            var dto = ContactsMapper.ContactsToContactsDTO(contact);

            return dto;
        }

    }
}
