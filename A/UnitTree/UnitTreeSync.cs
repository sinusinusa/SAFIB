using A.UnitTree.RequestWrapper;
using B.Dto;
using Newtonsoft.Json;
using System.Net;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using TestService.DataAccess.Entity;

namespace A.UnitTree
{
    public class UnitTreeSync
    {
        public List<FileUnit> Units = new List<FileUnit>();
        public static List<UnitStatus> Tree = new List<UnitStatus>();
        private String UrlConnection;
        public void SynchronizeDB()
        {
            GetServerUnits();
            AddMissedUnits();
        }
        private async void AddMissedUnits()
        {
            //WebRequest request = WebRequest.Create(UrlConnection+"/unit");
           // request.Method = "POST";
            foreach (FileUnit unit in Units)
            {
                UnitStatus toTree = new UnitStatus();
                toTree.Id = unit.Id;
                toTree.MainId = unit.MainId;
                toTree.Name = "Unnamed";
                Tree.Add(toTree);
                UnitDal toDb = new UnitDal();
                toDb.Id = unit.Id;
                toDb.MainId = unit.MainId;
                toDb.Name = "Unnamed";
                string json = JsonConvert.SerializeObject(toDb);
                await PostRequestAsync(UrlConnection+"/unit", json);
            }
        }
        private async Task PostRequestAsync(string url, string json)
        {
            var data = new StringContent(json, Encoding.UTF8, "application/json");
            using var client = new HttpClient();
            var response = await client.PostAsync(url, data);
            string result = response.Content.ReadAsStringAsync().Result;
        }
        private void GetServerUnits()
        {
            string rt;
            WebRequest request = WebRequest.Create(UrlConnection + "/unit");
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            rt = reader.ReadToEnd();
            reader.Close();
            response.Close();
            Tree = JsonConvert.DeserializeObject<List<UnitStatus>>(rt);
            foreach (UnitStatus i in Tree)
            {
                FileUnit? Same = Units.FirstOrDefault(x => x.Id == i.Id);
                if (Same != null)
                {
                    i.Status = Same.Status;
                    if (i.MainId != Same.MainId && Tree.FirstOrDefault(x => x.Id == Same.MainId) != null)
                    {
                        string Req = UrlConnection + $"/sync?id={i.Id}&mainid={Same.MainId}";
                        request = WebRequest.Create(Req);
                        response = request.GetResponse();
                        response.Close();
                    }
                }
                Units.Remove(Units.FirstOrDefault(x => x.Id == i.Id));
            }
        } 

        public void Serialize(Stream output, object input)
        {
            var ser = new DataContractSerializer(input.GetType());
            ser.WriteObject(output, input);
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
            UrlConnection = matched[0].Value + "://" + matched[1].Value + ":" + matched[2].Value;
        }
        public UnitTreeSync (List<FileUnit> units)
        {
            Units = units;
            getUrl();
            SynchronizeDB();
        }
    }
}
