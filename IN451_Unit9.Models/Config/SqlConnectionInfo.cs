using System.ComponentModel.DataAnnotations;

namespace IN451_Unit9.Models.Config
{
    public class SqlConnectionInfo
    {
        [Required(ErrorMessage ="Server name is required.")]
        [StringLength(100,ErrorMessage ="Server name is too long")]
        public string Server { get; set; }

        [Required(ErrorMessage = "Database name is required")]
        [StringLength(100, ErrorMessage = "Database name is too long")]
        public string Database { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        [StringLength(50, ErrorMessage = "User ID is too long")]
        public string User { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, ErrorMessage = "Password is too long")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
