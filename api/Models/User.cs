using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Name { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Password { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Role { get; set; }
    }
}
