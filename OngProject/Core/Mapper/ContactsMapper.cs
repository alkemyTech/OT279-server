using OngProject.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OngProject.Core.Mapper
{
    public class ContactsMapper
    {

        public static ContactsDTO ContactsToContactsDTO(Contacts contacts)
        {
            ContactsDTO contactsDTO = new ContactsDTO()
            {
                Name = contacts.Name,
                Phone = contacts.Phone,
                Email = contacts.Email,
                Message = contacts.Message
            };       
            return contactsDTO;           
        }
    }
}
