using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static VickApp2.Models.PTC_WebApi;
using static VickApp2.Models.PTC_Member;

namespace VickApp2.Service
{
    public class WebApi
    {
        private string sBaseUri;

        public WebApi(string sBaseAddress)
        {
            sBaseUri = sBaseAddress;
        }

        /// <summary>
        /// 連線 WebAPI 並取得回傳資料（By Post）
        /// </summary>
        /// <param name="Controller">Controller</param>
        /// <param name="Action">Action</param>
        /// <param name="Parameters">參數（物件封裝）</param>
        /// <param name="Parameter">參數（單一字串）</param>
        /// <returns>回傳 T 型態資料</returns>
        protected async Task<T> ConnectWebAPIAsync<T>(string Controller, string Action, object Parameters = null, string Parameter = "")
        {
            // 將參數序列化並轉換為傳遞格式
            StringContent stringContent = null;
            string sMediaType = "application/json";

            // 處理多個參數和單一參數的資料格式
            if (Parameters != null)
            {
                string sJsonContent = JsonConvert.SerializeObject(Parameters);

                stringContent = new StringContent(sJsonContent, Encoding.UTF8, sMediaType);
            }
            else if (!string.IsNullOrEmpty(Parameter))
            {
                sMediaType = "application/x-www-form-urlencoded";
                stringContent = new StringContent($"={Parameter}", Encoding.UTF8, sMediaType);
            }

            // 進行資料傳遞
            HttpResponseMessage httpResponseMessage;

            using (HttpClient httpClient = new HttpClient())
            {
                // 來源位址設定
                httpClient.BaseAddress = new Uri(sBaseUri);

                // Accept 用於宣告客戶端要求服務端回應的文件型態
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Content-Type 用於宣告傳遞給服務端的文件型態
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", sMediaType);

                // 傳送參數並取得結果
                HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, $"{Controller}/{Action}");
                httpResponseMessage = await httpClient.PostAsync(httpRequestMessage.RequestUri, stringContent);
            }

            // 回傳資料
            if (httpResponseMessage != null && httpResponseMessage.IsSuccessStatusCode == true)
                return JsonConvert.DeserializeObject<T>(httpResponseMessage.Content.ReadAsStringAsync().Result);
            else
                return default;
        }

        /// <summary>
        /// 登入
        /// </summary>
        /// <param name="sPlayerId">ID</param>
        /// <param name="sPlayerPwd">Password</param>
        /// <returns>回傳 PdaPlayerInfo</returns>
        public async Task<ApiResult<PdaPlayerInfo>> LoginAsync(string sPlayerId, string sPlayerPwd)
        {
            string sMachineId = string.Empty;
            string sIP = string.Empty;
            int eLogin = 0;

            // 參數設定
            var vParameters = new { sPlayerId, sPlayerPwd, sMachineId, eLogin, sIP };

            // 取得 WebAPI 回傳資料
            var vResult = await ConnectWebAPIAsync<ApiResult<PdaPlayerInfo>>("Member", "PlayerLogin", vParameters);

            return vResult;
        }
    }
}
