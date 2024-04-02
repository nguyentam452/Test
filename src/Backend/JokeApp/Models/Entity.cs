using System.ComponentModel.DataAnnotations;

namespace JokeApp.Models
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = Guid.NewGuid().ToString();
        }
        [Key]
        public string Id { get; set; }
    }
}
