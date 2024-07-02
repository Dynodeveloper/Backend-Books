public class User
{
    public int Id { get; set; } // Primary key
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public string ResetPasswordToken { get; internal set; }

    // (Opcional) Agregar propiedades adicionales si las necesitas)
}
