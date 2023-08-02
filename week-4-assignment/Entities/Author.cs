using System.ComponentModel.DataAnnotations.Schema;

namespace week_3_assignment.Entities
{
	public class Author
	{
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }

    }
}
