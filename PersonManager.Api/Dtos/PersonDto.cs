using System;

namespace PersonManager.Api.Dtos
{
    public class PersonDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GroupId { get; set; }
        public DateTime CreatedAt { get; set; }
        public GroupDto Group { get; set; }
    }
}
