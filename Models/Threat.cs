using IronDome2.Services;

namespace IronDome2.Models
{
    public class Threat
    {
        public int Id { get; set; }
        public string Weapon { get; set; }
        public Status Status { get; set; } = Status.Ready;
        public Launch Launch { get; set; }
        public int LaunchId { get; set; }

        // עד כאן ארבע שורות בטבלה, מזהה - שם נשק - סטטוס - קישור למטח
    }
}
