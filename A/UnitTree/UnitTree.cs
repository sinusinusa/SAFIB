using Newtonsoft.Json;
using System.Net;
using System.Text.Json;
using System.Text.RegularExpressions;
using TestService.DataAccess.Entity;

namespace A.UnitTree
{
    public class UnitTree
    {
        public List<FileUnit> Units = new List<FileUnit>();
        public List<UnitStatus> Tree = new List<UnitStatus>();
        private String UrlConnection;

        public void GetServerUnits()
        {
            string rt;
            WebRequest request = WebRequest.Create(UrlConnection);
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            rt = reader.ReadToEnd();
            reader.Close();
            response.Close();
            Tree = JsonConvert.DeserializeObject<List<UnitStatus>>(rt);
            foreach(UnitStatus i in Tree)
            {
                FileUnit? Same = Units.FirstOrDefault(x => x.Id == i.Id);
                if(Same != null)
                {
                    i.Status = Same.Status;
                }
            }
        }

        private void getUrl()
        {
            string JsonFromB;
            using (var reader = new StreamReader("C:/Users/drora/source/repos/serviceB/TestService/Properties/launchSettings.json"))
            {
                JsonFromB = reader.ReadToEnd();
            }
            JsonDocument jsonDocument = JsonDocument.Parse(JsonFromB);
            string Urls = jsonDocument.RootElement
                .GetProperty("profiles")
                .GetProperty("LoggingAndConfiguration")
                .GetProperty("applicationUrl")
                .ToString();
            string pattern = @"\w+(\.\w+)*";
            Regex reg = new Regex(pattern);
            MatchCollection matched = reg.Matches(Urls);
            UrlConnection = matched[0].Value + "://" + matched[1].Value + ":" + matched[2].Value + "/unit";
        }
        public UnitTree (List<FileUnit> units)
        {
            Units = units;
            getUrl();
            GetServerUnits();
        }
    }
}
