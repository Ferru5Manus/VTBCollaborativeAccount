using System.ComponentModel.DataAnnotations;

namespace AuthDatabaseService.Models;

public class UserModel
{
    [Key]
    public Guid uuid { get; set; }
}