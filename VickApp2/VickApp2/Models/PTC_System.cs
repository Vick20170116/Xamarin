using System;
using System.ComponentModel;

namespace VickApp2.Models
{
    /// <summary>
    /// Protocol System
    /// </summary>
    public class PTC_System
    {
        #region "-- 列舉 --"

        /// <summary>
        /// SYS Type 列舉
        /// </summary>
        public enum enSysType : int
        {
            /// <summary>
            /// 操作紀錄類別
            /// </summary>
            AdminLog = 0,
            /// <summary>
            /// 使用者等級類別
            /// </summary>
            AdminLevel = 1,
            /// <summary>
            /// 公告類別
            /// </summary>
            News = 2
        }

        /// <summary>
        /// MQ Status 列舉
        /// </summary>
        public enum enMQStatus
        {
            /// <summary>
            /// 未處理
            /// </summary>
            None = 0,
            /// <summary>
            /// 已處理
            /// </summary>
            OK = 1,
            /// <summary>
            /// 沒有資料
            /// </summary>
            NoRec = 2,
            /// <summary>
            /// 處理失敗
            /// </summary>
            Fail = 3
        }

        /// <summary>
        /// 登入平台
        /// </summary>
        public enum enLoginType
        {
            /// <summary>
            /// 全部
            /// </summary>
            [Description("全部")]
            All = 0,
            /// <summary>
            /// 平台
            /// </summary>
            [Description("平台")]
            Web = 1,
            /// <summary>
            /// FB
            /// </summary>
            [Description("FB")]
            FB = 2,
            /// <summary>
            /// Line
            /// </summary>
            [Description("Line")]
            Line = 3,
            /// <summary>
            /// QQ
            /// </summary>
            [Description("QQ")]
            QQ = 4
        }

        /// <summary>
        /// 手機驗證類別
        /// </summary>
        public enum enPhoneCheck
        {
            /// <summary>
            /// 發送簡訊
            /// </summary>
            [Description("發送簡訊")]
            Message = 0,
            /// <summary>
            /// 玩家註冊
            /// </summary>
            [Description("玩家註冊")]
            Register = 1,
            /// <summary>
            /// 忘記密碼
            /// </summary>
            [Description("忘記密碼")]
            ForgotPassword = 2,
            /// <summary>
            /// 變更密碼
            /// </summary>
            [Description("變更密碼")]
            ChangePassword = 3,
            /// <summary>
            /// 變更手機號碼
            /// </summary>
            [Description("變更手機號碼")]
            PlayerData = 4,
            /// <summary>
            /// 兌換鑽石
            /// </summary>
            [Description("兌換鑽石")]
            ExchDiamonds = 5,
            /// <summary>
            /// 兌換鑽幣
            /// </summary>
            [Description("兌換鑽幣")]
            ExchPoints = 6
        }

        /// <summary>
        /// 手機驗證結果
        /// </summary>
        public enum enPhoneCheckResult
        {
            /// <summary>
            /// 驗證通過
            /// </summary>
            [Description("驗證通過")]
            Ok = 0,

            /// <summary>
            /// 驗證失敗
            /// </summary>
            [Description("驗證失敗")]
            Fail = 1,

            /// <summary>
            /// 手機號碼格式錯誤
            /// </summary>
            [Description("手機號碼格式錯誤")]
            FormatError = 2,

            /// <summary>
            /// 使用者與手機號碼不相符
            /// </summary>
            [Description("手機號碼不相符")]
            ConformFail = 3,

            /// <summary>
            /// 此號碼有問題
            /// </summary>
            [Description("此號碼有問題")]
            NumberError = 4,

            /// <summary>
            /// 此號碼已申請過
            /// </summary>
            [Description("此號碼已申請過")]
            Applied = 5,

            /// <summary>
            /// 驗證超過次數
            /// </summary>
            [Description("驗證超過次數")]
            OverTimes = 6,

            /// <summary>
            /// 驗證碼逾期
            /// </summary>
            [Description("驗證碼逾期")]
            Overdue = 7,

            /// <summary>
            /// 發送驗證碼失敗
            /// </summary>
            [Description("發送驗證碼失敗")]
            SmsFail = 8,

            /// <summary>
            /// 已發送驗證碼
            /// </summary>
            [Description("已發送驗證碼")]
            SmsSuccess = 9,
        }

        #endregion

        /// <summary>
        /// MQ遊戲資料
        /// </summary>
        public struct stMQ_GameInfo
        {
            /// <summary>
            /// 遊戲局號
            /// </summary>
            public string sGameNo;
            /// <summary>
            /// 遊戲ID
            /// </summary>
            public string sGameId;
            /// <summary>
            /// 機台編號
            /// </summary>
            public int iMachineNo;
            /// <summary>
            /// 玩家Uid
            /// </summary>
            public Int64 iPlayerUid;
            /// <summary>
            /// 是否為Bonus發起局 [0：否；1：是]
            /// </summary>
            public int iBonus;
            /// <summary>
            /// 是否為FreeGame發起局 [0：否；1：是]
            /// </summary>
            public int iFree;
            /// <summary>
            /// 用來判斷是不是第一筆SumTotal資料 [ 0:代表第一筆 ]
            /// </summary>
            public int iSumTotal;
        }

        /// <summary>
        /// 後台操作者資料
        /// </summary>
        [Serializable]
        public class PdaAdmin
        {
            /// <summary>
            /// Uid
            /// </summary>
            public Int64 iUid;
            /// <summary>
            /// 名字
            /// </summary>
            public string sName;
            /// <summary>
            /// 權限等級
            /// </summary>
            public int iLevel;
            /// <summary>
            /// 驗證ID
            /// </summary>
            public string sVerify;

        }
    }
}
