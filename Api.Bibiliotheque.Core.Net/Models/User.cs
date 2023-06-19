using System.ComponentModel.DataAnnotations;

namespace Api.Bibiliotheque.Core.Net.Models
{
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Old { get; set; }
    }
}
