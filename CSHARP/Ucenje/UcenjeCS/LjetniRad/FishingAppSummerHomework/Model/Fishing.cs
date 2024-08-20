namespace UcenjeCS.LjetniRad.FishingAppSummerHomework.Model
{
    internal class Fishing : Entity
    {
        public DateTime? Date { get; set; }
        public User? User { get; set; }
        public Fish? Fish { get; set; }
        public River? River { get; set; }
        public int? Quantity { get; set; }
        public int? Weight { get; set; }
        
    }
}