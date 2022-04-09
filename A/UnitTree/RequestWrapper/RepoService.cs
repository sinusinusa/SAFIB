using System.Net;
using System.Runtime.Serialization;
using System.Text.Json;

namespace A.UnitTree.RequestWrapper
{
    public class RepoService
    {
        public void PutObject(string postUrl, object payload)
        {
            var request = (HttpWebRequest)WebRequest.Create(postUrl);
            request.Method = "PUT";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string returnString = response.StatusCode.ToString();
        }
        public void Serialize(Stream output, object input)
        {
            var ser = new DataContractSerializer(input.GetType());
            ser.WriteObject(output, input);
        }
    }
}
