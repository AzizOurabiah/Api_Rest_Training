using System.ComponentModel.DataAnnotations;

namespace Api.Bibiliotheque.Core.Net.Models
{
    public class BookModel
    {
        [Key]
        public int Id { get; set; }

        public string  Title { get; set; }

        public string Author { get; set; }

        public int MinimumOld { get; set; }
    }
}
