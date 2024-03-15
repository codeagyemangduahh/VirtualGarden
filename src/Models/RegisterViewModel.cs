
namespace VirtualGarden;

public class RegisterViewModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string ConfirmPassword { get; set; } = string.Empty;
    public string AddressLine1 { get; set; } = string.Empty;
    public string AddressLine2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;
    public IFormFile? ProfilePicture { get; set; }

    public Gardener ToGardener()
    {
        return new Gardener
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            UserName = Email,
            AddressLine1 = AddressLine1,
            AddressLine2 = AddressLine2,
            City = City,
            Province = Province,
            PostalCode = PostalCode,
            ProfilePicture = GetProfilePicture()
        };
    }

    private byte[]? GetProfilePicture()
    {
        if(ProfilePicture == null)
            return null;
        using var memoryStream = new MemoryStream();
        ProfilePicture.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}
