namespace UcenjeCS.LjetniRad.FishingAppSummerHomework.Model
{
    internal class Fish : Entity
    {
        public string? Name { get; set; }
        public DateTime? HuntStart { get; set; }
        public DateTime? HuntEnd { get; set; }
        public string? Description { get; set; }
    }
}