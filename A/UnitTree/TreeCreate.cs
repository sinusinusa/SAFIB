using Newtonsoft.Json;

namespace A.UnitTree
{
    public class TreeCreate
    {
        public UnitTree Create()
        {
            string JsonFromFile;
            using (var reader = new StreamReader("C:/Users/drora/source/repos/serviceB/A/Units.json"))
            {
                JsonFromFile = reader.ReadToEnd();
            }
            var unitTree = JsonConvert.DeserializeObject<UnitTree>(JsonFromFile);
            return unitTree;
        }
    }
}
