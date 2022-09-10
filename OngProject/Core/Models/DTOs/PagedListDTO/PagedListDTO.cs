using OngProject.Core.Helper;
using OngProject.Entities;
using System.Collections.Generic;

namespace OngProject.Core.Models.DTOs.PagedListDTO
{
    public class PagedListDTO<T>
    {
        public PagedListHelper<T> Values { get; set; }
        public string PreviousPage { get; set; }
        public string NextPage { get; set; }

        public PagedListDTO(PagedListHelper<T> entity, string host, string path)
        {

            Values = entity;
            PreviousPage = entity.HasPrevious ? $"https://{host}{path}?numberPage={entity.CurrentPage + 1}&quantityPage={entity.PageSize}" : null;
            NextPage = entity.HasNext ? $"https://{host}{path}?numberPage={entity.CurrentPage + 1}&quantityPage={entity.PageSize}" : null;
        }
    }
}
