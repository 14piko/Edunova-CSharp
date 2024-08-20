namespace UcenjeCS.LjetniRad.FishingAppSummerHomework.Model
{
    internal class User : Entity
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Role { get; set; }
        public string? Oib { get; set; }
        public string? LicenseNumber { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}