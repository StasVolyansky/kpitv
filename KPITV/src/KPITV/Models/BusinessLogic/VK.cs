using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KPITV.Models.BusinessLogic
{
    public class VK
    {
        public async Task<object> GetMembers() =>
            JsonConvert.DeserializeAnonymousType(
                await Request("https://api.vk.com/method/groups.getMembers?group_id=kpitvhome&version=5.27"),
                new { Response = new { Count = 0, Users = new List<string>() } });

        public async Task<string> GetId(string VKLink) => JsonConvert.DeserializeAnonymousType(
                await Request($"https://api.vk.com/method/users.get?user_ids={VKLink}&version=5.8"),
                new { Response = new[] { new { UId = string.Empty, First_Name = string.Empty, Last_Name = string.Empty } } })
            .Response[0].UId;

        public async Task<string> GetVKLink(string id) => JsonConvert.DeserializeAnonymousType(
                await Request($"https://api.vk.com/method/users.get?user_ids={id}&fields=screen_name&version=5.8"),
                new { Response = new[] { new { UId = string.Empty, First_Name = string.Empty, Last_Name = string.Empty, Screen_Name = string.Empty } } })
            .Response[0].Screen_Name;

        async Task<string> Request(string url)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse;
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}
