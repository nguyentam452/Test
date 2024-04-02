using System.ComponentModel.DataAnnotations.Schema;

namespace JokeApp.Models
{
    [Table("Vote")]

    public class Vote: Entity
    {
        public string JokeId { get; set; }
        public bool Liked { get; set; }

        [ForeignKey("JokeId")]
        public virtual Joke? Joke { get; set; }


    }
}
