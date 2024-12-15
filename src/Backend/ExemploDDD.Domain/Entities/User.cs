namespace ExemploDDD.Domain.Entities;
public class User
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public bool Active { get; set; } = true;
    public DateTime RegistryDate { get; set; } = DateTime.Now;
}

