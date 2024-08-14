namespace IronDome2.Services
{
    public class Weapon
    {
        public string Name { get; set; }
        public int Range { get; set; }
        public int Speed { get; set; }
    }

    public enum Status
    {
        Ready,
        Launched,
        Intercepted,
        Hit
    }

    //public record Location(double latitude, double longitude);
    //public record Orbit(Location src, Location dst);
    //public record OrbitDispaly(string src, string dst);

    public class Location
    {
        public double latitude { get; set; }
        public double longitude { get; set; }
    }
    public class Trajectory
    {
        public Location src { get; set; } = new Location();
        public Location dst { get; set; } = new Location();
    }
    public record OrbitDispaly(string src, string dst);
}
