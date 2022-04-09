//using System.Text.Json;
using Newtonsoft.Json;


namespace A.UnitTree
{
    public class ListFileUnitCreate
    {
        public UnitTree Create()
        {
            string JsonFromFile;
            using (var reader = new StreamReader("C:/Users/drora/source/repos/serviceB/A/Units.json"))
            {
                JsonFromFile = reader.ReadToEnd();
            }
           // UnitTree unitTree = JsonSerializer.Deserialize<UnitTree>(JsonFromFile);
            var unitTree = JsonConvert.DeserializeObject<UnitTree>(JsonFromFile);
            return unitTree;
        }
    }
}
