using System;
namespace Myproject.Models
{
	public class Banks
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public string UrlAddress { get; set; }
        public Director GeneralDirector { get; set; }
        public List<ContactPerson> ContactPersons { get; set; }

    }
}

