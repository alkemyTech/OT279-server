using System.Collections.Generic;

namespace OngProject.Core.Interfaces
{
    public interface IMembersBusiness
    {
        public IEnumerable<Members> GetAll();
        public Members GetById(int Id);
        public void Insert(Members member);
        public void Update(Members updatedMember);
        public bool Delete(int Id);
    }
}
