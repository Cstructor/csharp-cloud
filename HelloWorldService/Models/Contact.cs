using System;

namespace HelloWorldService.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateAdded { get; set; }
        public Phone[]? Phones { get; set; }
    }
}
