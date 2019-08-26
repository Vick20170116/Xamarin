using System;

namespace VickApp2.Models
{
    /// <summary>
    /// Protocol WebApi
    /// </summary>
    public class PTC_WebApi
    {
        #region "-- ApiResult --"

        /// <summary>
        /// API呼叫時，傳回的統一物件
        /// </summary>
        [Serializable]
        public class ApiResult<T>
        {
            /// <summary>
            /// 執行成功與否
            /// </summary>
            public bool Succ { get; set; }
            /// <summary>
            /// 結果代碼(0000=成功，其餘為錯誤代號)
            /// </summary>
            public enApiResultCode Code { get; set; }
            /// <summary>
            /// 錯誤訊息
            /// </summary>
            public string Message { get; set; }
            /// <summary>
            /// 資料時間
            /// </summary>
            public DateTime DataTime { get; set; }
            /// <summary>
            /// 資料本體
            /// </summary>
            public T Data { get; set; }

            /// <summary>
            /// 建立成功 只有狀態，沒有資料
            /// </summary>
            public ApiResult() { }

            /// <summary>
            /// 建立成功結果
            /// </summary>
            /// <param name="data"></param>
            public ApiResult(T data)
            {
                Succ = true;
                Code = enApiResultCode.Success;
                DataTime = DateTime.Now;
                Data = data;
            }
        }

        #endregion

        #region "-- ApiError --"

        /// <summary>
        /// 錯誤時回傳的訊息
        /// </summary>
        [Serializable]
        public class ApiError : ApiResult<object>
        {
            /// <summary>
            /// 建立失敗結果
            /// </summary>
            /// <param name="eArCode"></param>
            /// <param name="message"></param>
            public ApiError(enApiResultCode eArCode, string message)
            {
                Succ = false;
                Code = eArCode;
                DataTime = DateTime.Now;
                Message = message;
            }
        }

        #endregion

        #region "-- ApiResultCode --"

        /// <summary>
        /// WebApi Result Code
        /// </summary>
        public enum enApiResultCode
        {
            /// <summary>
            /// 成功
            /// </summary>
            Success = 800,
            /// <summary>
            /// Catch Error
            /// </summary>
            Error = 820,
            /// <summary>
            /// 失敗
            /// </summary>
            Fail = 840,
            /// <summary>
            /// Headers Verify Fail
            /// </summary>
            VerifyFail = 841,

            Test = 0
        }

        #endregion
    }
}
