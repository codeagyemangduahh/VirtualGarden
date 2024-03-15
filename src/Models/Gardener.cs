using Microsoft.AspNetCore.Identity;

namespace VirtualGarden;

public class Gardener : IdentityUser<int>
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public byte[]? ProfilePicture { get; set; }
    public string AddressLine1 { get; set; } = string.Empty;
    public string AddressLine2 { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
    public string PostalCode { get; set; } = string.Empty;

    public override bool Equals(object? obj) => obj is Gardener gardener && gardener.Id == Id;

    public override int GetHashCode() => HashCode.Combine(Id);
}
