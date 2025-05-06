using System.ComponentModel.DataAnnotations;

namespace IN451_Unit9.Models.Config
{
    public class SqlConnectionInfo
    {
        [Required(ErrorMessage ="Server is required.")]
        public string Server { get; set; }

        [Required(ErrorMessage = "Database is required.")]
        public string Database { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string User { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
