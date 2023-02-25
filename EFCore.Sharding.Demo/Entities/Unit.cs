using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore.Sharding.Demo.Entities;

[Table("units")]
public class Unit
{
    
    [Key]
    public string Id { get; set; }
    
    
    public DateTime Created { get; set; } = DateTime.Now;
}