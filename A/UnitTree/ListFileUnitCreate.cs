//using System.Text.Json;
using Newtonsoft.Json;


namespace A.UnitTree
{
    public class ListFileUnitCreate
    {
        public static UnitTreeSync Create()
        {
            string JsonFromFile;
            using (var reader = new StreamReader("C:/Users/drora/source/repos/serviceB/A/Units.json"))
            {
                JsonFromFile = reader.ReadToEnd();
            }
           // UnitTree unitTree = JsonSerializer.Deserialize<UnitTree>(JsonFromFile);
            var unitTree = JsonConvert.DeserializeObject<UnitTreeSync>(JsonFromFile);
            return unitTree;
        }
    }
}
