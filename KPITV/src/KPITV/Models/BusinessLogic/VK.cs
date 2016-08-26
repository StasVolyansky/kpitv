using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KPITV.Models.BusinessLogic
{
    public class VK
    {
        public async Task<object> GetMembers()
        {
            string url = "https://api.vk.com/method/groups.getMembers?group_id=kpitvhome&version=5.27";
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var definition = new { Response = new { Count = 0, Users = new List<string>() } };
                    string result = reader.ReadToEnd();
                    return JsonConvert.DeserializeAnonymousType(result, definition);
                }
            }
        }
    }
}
