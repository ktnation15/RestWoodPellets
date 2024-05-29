using WoodPelletsLib;

namespace RestWoodPellets
{
    public class WoodPelletManager
    {
        private static List<WoodPellet> woodPellets = new List<WoodPellet>();
        private static int nextId = 1;// Varia

        static WoodPelletManager()
        {
            // Tilføg mindst 5 forskellige WoodPellets til listen
            Add(new WoodPellet(nextId++, "BioWood", 4995, 4));
            Add(new WoodPellet(nextId++, "BilligPille", 4125, 1));
            Add(new WoodPellet(nextId++, "GoldenWoodPellet", 5995, 5));
            Add(new WoodPellet(nextId++, "GoldWoodPellet", 5795, 5));
            Add(new WoodPellet(nextId++, "EcoWood", 4595, 3));
        }
        public static IEnumerable<WoodPellet> GetAll()
        {
            return woodPellets;
        }
        public static WoodPellet GetById(int id)
        {
            return woodPellets.Find(wp => wp.Id == id);
        }
        public static void Add(WoodPellet woodPellet)
        {
            woodPellet.Id = nextId++;
            //WoodPellet woodPellet = new WoodPellet(nextId++, brand, price, quality);
            woodPellets.Add(woodPellet);
        }
        public static void Update(WoodPellet updatedWoodPellet)
        {
            WoodPellet existingWoodPellet = woodPellets.FirstOrDefault(wp => wp.Id == updatedWoodPellet.Id);
            if (existingWoodPellet != null)
            {
                existingWoodPellet.Brand = updatedWoodPellet.Brand;
                existingWoodPellet.Price = updatedWoodPellet.Price;
                existingWoodPellet.Quality = updatedWoodPellet.Quality;
            }
            else
            {
                throw new ArgumentException($"WoodPellet with id {updatedWoodPellet.Id} not found.");
            }
        }
    }
}
