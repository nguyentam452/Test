using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JokeApp.Models
{
    [Table("Joke")]

    public class Joke: Entity
    {

        [Column(TypeName = "nvarchar(max)")]
        public string Content { get; set; }
        public virtual ICollection<Vote>? Votes { get; set; }
    }
}
