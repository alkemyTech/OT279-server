using OngProject.Core.Models.DTOs.UserDTO;
using OngProject.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OngProject.Core.Interfaces
{
    public interface IUsersBusiness
    {
        /// <summary>
        ///     Obtiene todos los usuarios
        /// </summary>
        Task<List<ViewUserDTO>> GetAll();
     
        /// <summary>
        ///     Obtiene un usuario en especifico. 
        /// </summary>
        /// <param name="id">
        ///     Id del usuario en la base de datos
        /// </param>
        Task<User> GetById(int id);
        
        /// <summary>
        ///     Inserta un usuario en la base de datos
        /// </summary>
        /// <param name="user">
        ///     Entity a ingresar en la base de datos
        /// </param>
        Task<User> Insert(User user);
        
        /// <summary>
        ///     Elimina un usuario en la base de datos
        /// </summary>
        /// <param name="user">
        ///     Entity a eliminar en la base de datos
        /// </param>
        Task<bool> Delete(int id);
        
        /// <summary>
        ///     Actualiza un usuario en la base de datos.
        /// </summary>
        /// <param name="user">
        ///     Entity a actualizar en la base de datos
        /// </param>

        Task<User> Update(int id, User user);
    }
}
