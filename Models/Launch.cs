using IronDome2.Services;
using System.Text.Json;

namespace IronDome2.Models
{
    public class Launch
    {
        public int Id { get; set; }
        public double Src_lat { get; set; }
        public double Src_lng { get; set; }
        public double Dst_lat { get; set; }
        public double Dst_lng { get; set; }
        public DateTime LaunchTime {  get; set; }
        public List<Threat> Threats { get; set; } = [];

        // עד כאן יהיו בטבלה


        /// <summary>
        /// פונה לשרת חיצוני שמספק מידע על מקום בהינתן הנ"צ שלו
        /// </summary>
        /// <returns></returns>
        public async Task<OrbitDispaly> GetLocationNames()
        {
            if (Src_lat != 0 && Src_lng != 0 && Dst_lat != 0 && Dst_lng != 0)
            {
                string src_url = $"https://nominatim.openstreetmap.org/reverse?lat={Src_lat}&lon={Src_lng}&format=json&addressdetails=1";
                string dst_url = $"https://nominatim.openstreetmap.org/reverse?lat={Dst_lat}&lon={Dst_lng}&format=json&addressdetails=1";
                string src_dis, dst_dis;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Add("User-Agent", "C# App");
                    try
                    {
                        HttpResponseMessage src_response = await client.GetAsync(src_url);
                        HttpResponseMessage dst_response = await client.GetAsync(dst_url);
                        if (src_response.IsSuccessStatusCode && dst_response.IsSuccessStatusCode)
                        {
                            string src = await src_response.Content.ReadAsStringAsync();
                            string dst = await dst_response.Content.ReadAsStringAsync();
                            using(JsonDocument jd = JsonDocument.Parse(src))
                            {
                                JsonElement root = jd.RootElement;
                                if (root.TryGetProperty("display_name", out JsonElement displayNameElement))
                                {
                                    src_dis = displayNameElement.GetString() ?? "empty";
                                }
                                else
                                {
                                    src_dis = "Data is not exists";
                                }
                            }
                            using (JsonDocument jd = JsonDocument.Parse(dst))
                            {
                                JsonElement root = jd.RootElement;
                                if (root.TryGetProperty("display_name", out JsonElement displayNameElement))
                                {
                                    dst_dis = displayNameElement.GetString() ?? "empty";
                                }
                                else
                                {
                                    dst_dis = "Data is not exists";
                                }
                            }
                            return new OrbitDispaly(src_dis, dst_dis);
                        }
                    }
                    catch (HttpRequestException e)
                    {
                        Console.WriteLine($"Request error: {e.Message}");
                        return new OrbitDispaly("Not Found", "Not Found");
                    }
                }  
            }
            return new OrbitDispaly("Orbit is still empty", "Please fill it and try again");
        }
    }
}
