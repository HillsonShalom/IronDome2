using Newtonsoft.Json;

namespace IronDome2.Data.Weapon
{
    public class WeaponService
    {
        public List<WeaponModel> weapons;
        public WeaponService()
        {
            FillListFromFile();
        }


        private void FillListFromFile()
        {
            using (var sr = new StreamReader("Data\\Weapon\\Weapons.json"))
            {
                string json = sr.ReadToEnd();
                weapons = JsonConvert.DeserializeObject<List<WeaponModel>>(json)!;
            }
        }
    }
}
