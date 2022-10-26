using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Keyless]
    public class Login
    {
        [Column(TypeName = "nvarchar(50)")]
        public string? Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string? Password { get; set; }
    }

}
