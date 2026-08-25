using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace LibraryApi.Models;


[Index(nameof(Email), IsUnique = true)]
[Index(nameof(MembershipNumber), IsUnique = true)]
public class Member
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [StringLength(20)]
    public string MembershipNumber { get; set; } = string.Empty;

    public DateTime JoinedDate { get; set; }
}