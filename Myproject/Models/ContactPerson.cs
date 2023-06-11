using System;
namespace Myproject.Models
{
	public class ContactPerson
	{
		public int ContactPersonId { get; set; }
		public string Firstname { get; set; }
		public string Lastname { get; set; }
		public DateTime BirthDate { get; set; }
		public string Position { get; set; }
		public Banks Bank { get; set; }
    }
}

