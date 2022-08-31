using OngProject.Entities;

namespace OngProject.Core.Models.DTOs
{
    public class SlideDTO
    {
        public string ImageUrl { get; set; }
        public string Text { get; set; }
        public int Order { get; set; }
        public int OrganizationId { get; set; }

        public SlideDTO(Slides s)
        {
            ImageUrl = s.ImageUrl;
            Text = s.Text;
            Order = s.Order;
            OrganizationId = s.OrganizationId;
        }
    }
}
