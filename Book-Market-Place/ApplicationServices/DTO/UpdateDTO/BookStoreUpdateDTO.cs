using Entities.POCOEntities.BaseEntity;

namespace ApplicationServices.DTO
{
    public class BookStoreUpdateDTO : BaseEntity
    {
        public string StoreName { get; set; }

        public string Adress { get; set; }

        public string TelPhone { get; set; }

        public string SaleManName { get; set; }

        public ushort Rating { get; set; }
    }
}
