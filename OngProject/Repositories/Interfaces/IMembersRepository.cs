using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Repositories.Interfaces
{
    public interface IMembersRepository
    {
        public IEnumerable<Members>GetAll();
        public Members GetById(int Id);
        public void Insert(Members member);
        public void Update(Members updatedMember);
        public bool Delete(int Id);

    }
}
