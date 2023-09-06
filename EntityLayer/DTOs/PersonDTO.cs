using CoreLayer.Entities;


namespace EntityLayer.DTOs
{
    public class PersonDTO : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
    }
}
