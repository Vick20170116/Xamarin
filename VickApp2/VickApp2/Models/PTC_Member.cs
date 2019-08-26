using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using static VickApp2.Models.PTC_System;

namespace VickApp2.Models
{
    /// <summary>
    /// Protocol Member
    /// </summary>
    public class PTC_Member
    {
        #region "-- 列舉 --"

        /// <summary>
        /// 會員等級
        /// </summary>
        public enum enMembership
        {
            /// <summary>
            /// 全部
            /// </summary>
            All = 0,
            /// <summary>
            /// 訪客
            /// </summary>
            Guest = 1,
            /// <summary>
            /// 一般會員
            /// </summary>
            Normal = 2,
            /// <summary>
            /// 高級會員
            /// </summary>
            Advanced = 3,
            /// <summary>
            /// 鑽石會員
            /// </summary>
            Diamond = 4
        }

        /// <summary>
        /// PL Type 列舉
        /// </summary>
        public enum enPLType : int
        {
            /// <summary>
            /// MemberShip
            /// </summary>
            MemberShip = 0,
            /// <summary>
            /// 國碼類別
            /// </summary>
            Country = 1,
            /// <summary>
            /// 登入方式
            /// </summary>
            Login = 2,
            /// <summary>
            /// 帳號類別
            /// </summary>
            Account = 3,
            /// <summary>
            /// 帳號狀態
            /// </summary>
            AccountStatus = 4,
            /// <summary>
            /// 每日贈禮額度類別
            /// </summary>
            Experience = 5,
            /// <summary>
            /// 訊息狀態
            /// </summary>
            Notice = 6,
            /// <summary>
            /// ICON
            /// </summary>
            ICON = 7

        }

        /// <summary>
        /// VIP 等級
        /// </summary>
        public enum enVip
        {
            /// <summary>
            /// 無
            /// </summary>
            [Description("無")]
            None = 0,
            /// <summary>
            /// 普卡
            /// </summary>
            [Description("普卡")]
            VIP0 = 1,
            /// <summary>
            /// 銅卡
            /// </summary>
            [Description("銅卡")]
            VIP1 = 2,
            /// <summary>
            /// 銀卡
            /// </summary>
            [Description("銀卡")]
            VIP2 = 3,
            /// <summary>
            /// 金卡
            /// </summary>
            [Description("金卡")]
            VIP3 = 4,
            /// <summary>
            /// 白鑽卡
            /// </summary>
            [Description("白鑽卡")]
            VIP4 = 5,
            /// <summary>
            /// 彩鑽卡
            /// </summary>
            [Description("彩鑽卡")]
            VIP5 = 6
        }

        /// <summary>
        /// App版，註冊訊息
        /// </summary>
        public enum enAppRegister
        {
            /// <summary>
            /// 註冊通過
            /// </summary>
            [Description("註冊通過")]
            Ok = 0,
            /// <summary>
            /// 暱稱已被使用
            /// </summary>
            [Description("暱稱已被使用")]
            NickNameUsed = 1,
            /// <summary>
            /// 介紹人錯誤
            /// </summary>
            [Description("介紹人錯誤")]
            AgentError = 2,
            /// <summary>
            /// 介紹人非高級會員
            /// </summary>
            [Description("介紹人非高級會員")]
            AgentMemShipError = 3,
            /// <summary>
            /// 介紹人已達介紹上限
            /// </summary>
            [Description("介紹人已達介紹上限")]
            AgentCountOver = 4,
            /// <summary>
            /// 註冊失敗
            /// </summary>
            [Description("註冊失敗")]
            Fail = 5,
            /// <summary>
            /// 驗證碼錯誤
            /// </summary>
            [Description("驗證碼錯誤")]
            PhoneCodeError = 7
        }

        /// <summary>
        /// 「我的最愛」的結果訊息
        /// </summary>
        public enum enFavoriteResult
        {
            /// <summary>
            /// 成功
            /// </summary>
            Ok = 0,
            /// <summary>
            /// 無此玩家UID
            /// </summary>
            NoPlayer = 1,
            /// <summary>
            /// 錯誤的遊戲ID
            /// </summary>
            WrongGameId = 2,
            /// <summary>
            /// 收藏數量已大於等於6
            /// </summary>
            TooMuch = 3,
            /// <summary>
            /// 此遊戲ID已存在
            /// </summary>
            AlreadyExist = 4,
        }

        #endregion

        #region "-- 資料結構 --"

        #region "-- 後台資料結構 --"

        #region "-- 條件資料 --"

        /// <summary>
        /// 一般通用條件
        /// </summary>
        [Serializable]
        public class CommonCondition
        {
            /// <summary>
            /// 會員UID
            /// </summary>
            public Int64 iPlayerUid;
            /// <summary>
            /// 會員ID [WHERE_IN]
            /// </summary>
            public string sPlayerUid_IN;
            /// <summary>
            /// 會員ID
            /// </summary>
            public string sPlayerID;
            /// <summary>
            /// 會員ID [WHERE_IN]
            /// </summary>
            public string sPlayerID_IN;
            /// <summary>
            /// 會員NickName
            /// </summary>
            public string sNickName;
            /// <summary>
            /// 會員類別Membership
            /// </summary>
            public int iMemberShip;
            /// <summary>
            /// 會員類別Membership [WHERE_IN]
            /// </summary>
            public string sMemberShip_IN;
            /// <summary>
            /// 是否為TA帳號
            /// </summary>
            public int iTA;
            /// <summary>
            /// 日期時間 起 [datetime]
            /// </summary>
            public string sDS;
            /// <summary>
            /// 日期時間 迄 [datetime]
            /// </summary>
            public string sDE;
            /// <summary>
            /// 遊戲代號
            /// </summary>
            public string sGameID;
            /// <summary>
            /// 局號
            /// </summary>
            public string sGameNo;
            /// <summary>
            /// 機台號碼
            /// </summary>
            public string sManchineNo;
        }

        /// <summary>
        /// 下注明細  畫面條件、資料欄位對應Struct
        /// </summary>
        [Serializable]
        public struct stPageCondition
        {
            /// <summary>
            /// 會員ID
            /// <para>[ WHERE IN 格式 ex: '1','2','3'... ]</para></summary>
            public string sID;
            /// <summary>
            /// 日期 起 [yyyyMMdd]
            /// </summary>
            public string sDS_yMd;
            /// <summary>
            /// 日期 迄 [yyyyMMdd]
            /// </summary>
            public string sDE_yMd;
            /// <summary>
            /// 日期 起 [yyyyMMdd 00:00:00]
            /// </summary>
            public string sDS_yMdHms;
            /// <summary>
            /// 日期 迄 [yyyyMMdd 23:59:59]
            /// </summary>
            public string sDE_yMdHms;
            /// <summary>
            /// 局號
            /// </summary>
            public string sGameNo;
            /// <summary>
            /// 選擇類型 1
            /// </summary>
            public string sGType1;
            /// <summary>
            /// 選擇類型 2
            /// </summary>
            public string sGType2;
            /// <summary>
            /// 選擇類型 3
            /// </summary>
            public string sGType3;
            /// <summary>
            /// 排除無勝負
            /// </summary>
            public string sWin;
            /// <summary>
            /// 指定開牌
            /// </summary>
            public string sIsSet;
            /// <summary>
            /// 總下注
            /// </summary>
            public int iAllBet;
            /// <summary>
            /// 總得分
            /// </summary>
            public int iAllWin;
            /// <summary>
            /// 總勝點
            /// </summary>
            public int iTotalWin;
            /// <summary>
            /// 彩金次數
            /// </summary>
            public int iBonusCount;
            /// <summary>
            /// 彩金分數
            /// </summary>
            public int iBonusGamePoint;
            /// <summary>
            /// 彩金場次
            /// </summary>
            public int iBonusGameCount;
            /// <summary>
            /// 暗槓彩金分數
            /// </summary>
            public int iBonusGamePoint1;
        }

        #endregion

        #region "-- 新會員報表 --"

        /// <summary>
        /// 新會員報表結構
        /// </summary>
        [Serializable]
        public class PdaNewMember
        {
            /// <summary>
            /// 總會員
            /// </summary>
            public Int64 iMemberTotal;
            /// <summary>
            /// 新會員明細
            /// </summary>
            public DataTable dtMemList;
        }

        #endregion

        /// <summary>
        /// 會員資料 異動資料 資料結構
        /// </summary>
        [Serializable]
        public class PdaMember
        {
            /// <summary>
            /// 玩家Uid
            /// </summary>
            public Int64 iPlayerUid;
            /// <summary>
            /// 帳號類別
            /// </summary>
            public int iAccountType = -1;
            /// <summary>
            /// 會員類別
            /// </summary>
            public int iMemberShip = 1;
            /// <summary>
            /// 暱稱
            /// </summary>
            public string sNickName;
            /// <summary>
            /// 帳號
            /// </summary>
            public string sId;
            /// <summary>
            /// 密碼
            /// </summary>
            public string sPwd;
            /// <summary>
            /// 帳號狀態
            /// </summary>
            public int iAccStatus;
            /// <summary>
            /// 等級
            /// </summary>
            public int iLV;
            /// <summary>
            /// VIP等級
            /// </summary>
            public int iVipId = -1;
            /// <summary>
            /// VIP經驗
            /// </summary>
            public int iVipExp;
            /// <summary>
            /// VIP標註狀態
            /// </summary>
            public int iVipMark = -1;
            /// <summary>
            /// 手機號碼
            /// </summary>
            public string sCellPhone;
            /// <summary>
            /// 俱樂部
            /// </summary>
            public int iClubId;
            /// <summary>
            /// 安全密碼
            /// </summary>
            public string sSavePwd;
            /// <summary>
            /// 真實姓名
            /// </summary>
            public string sName;
            /// <summary>
            /// 介紹人
            /// </summary>
            public int iAgentUid;
            /// <summary>
            /// 介紹人暱稱
            /// </summary>
            public string sAgentName;
            /// <summary>
            /// 鑽石數量
            /// </summary>
            public int iDiamondCount;
            /// <summary>
            /// 鑽幣數量
            /// </summary>
            public int iPointsCount;
            /// <summary>
            /// 經驗值
            /// </summary>
            public int iExperience;
            /// <summary>
            /// 累儲金額
            /// </summary>
            public int iTotalMoney;
            /// <summary>
            /// 創建時間
            /// </summary>
            public string sCreatTime;
            /// <summary>
            /// FB暱稱
            /// </summary>
            public string sFB;
            /// <summary>
            /// Line暱稱
            /// </summary>
            public string sLine;
            /// <summary>
            /// 贈禮累計
            /// </summary>
            public int iTotalGift;
            /// <summary>
            /// 最後上線
            /// </summary>
            public string sLastTime;
            /// <summary>
            /// E-MAIL
            /// </summary>
            public string sEMail;
            /// <summary>
            /// 國碼
            /// </summary>
            public int iContryUid;
            /// <summary>
            /// 註冊方式
            /// </summary>
            public int iRegisterType = 1;
        }

        #endregion

        /// <summary>
        /// 註冊資料結構
        /// </summary>
        public class PdaPlayerRegister
        {
            /// <summary>
            /// 玩家Uid
            /// </summary>
            public Int64 iPlayerUid;
            /// <summary>
            /// 註冊ID
            /// </summary>
            public string sId;
            /// <summary>
            /// 註冊暱稱
            /// </summary>
            public string sNickName;
            /// <summary>
            /// 註冊密碼
            /// </summary>
            public string sPassword;
            /// <summary>
            /// 註冊序號
            /// </summary>
            public string sRegisterNo;
            /// <summary>
            /// 註冊Line Id
            /// </summary>
            public string sLineId;
            /// <summary>
            /// 電話國碼
            /// </summary>
            public string sCountryCode;
            /// <summary>
            /// 手機號碼
            /// </summary>
            public string sCellPhone;
            /// <summary>
            /// 註冊平台
            /// </summary>
            public enLoginType eLogin;
            /// <summary>
            /// 手機驗證序號
            /// </summary>
            public string sCode;
            /// <summary>
            /// 介紹人Uid
            /// </summary>
            public Int64 iAgentUid;
            /// <summary>
            /// 介紹人暱稱
            /// </summary>
            public string sAgentName;
        }

        /// <summary>
        /// 玩家資料
        /// </summary>
        [Serializable]
        public class PdaPlayerInfo
        {
            #region "-- 玩家基本資料 --"

            /// <summary>
            /// 玩家帳號Uid
            /// </summary>
            public Int64 iPlayerUid;
            /// <summary>
            /// 玩家帳號
            /// </summary>
            public string sPlayerId;
            /// <summary>
            /// 玩家暱稱
            /// </summary>
            public string sNickName;

            /// <summary>
            /// 玩家真實姓名
            /// </summary>
            public string sRealName;
            /// <summary>
            /// 手機號碼
            /// </summary>
            public string sCellPhone;

            #endregion

            #region "-- 玩家數據資料 --"

            /// <summary>
            /// 玩家圖像ID
            /// </summary>
            public int iIconId;
            /// <summary>
            /// 玩家留言
            /// </summary>
            public string sPlayerMemo;

            /// <summary>
            /// 會員身分(中文)
            /// </summary>
            public string sMemberShip;
            /// <summary>
            /// 會員身分
            /// </summary>
            public int iMemberShip;

            /// <summary>
            /// 玩家等級
            /// </summary>
            public int iLv;
            /// <summary>
            /// 玩家經驗值
            /// </summary>
            public int iExp;
            /// <summary>
            /// 玩家下一LV 經驗值
            /// </summary>
            public int iExpNext;
            /// <summary>
            /// VIP 等級
            /// </summary>
            public int iVip;
            /// <summary>
            /// VIP 經驗值
            /// </summary>
            public int iVipExp;
            /// <summary>
            /// VIP 符合金額
            /// </summary>
            public int iVipMoney;
            /// <summary>
            /// VIP 符合下一個金額
            /// </summary>
            public int iVipMoneyNext;
            /// <summary>
            /// 玩家身上鑽石數量
            /// </summary>
            public int iDiamond;
            /// <summary>
            /// 玩家身上鑽幣數量
            /// </summary>
            public int iPoints;
            /// <summary>
            /// 玩家身上其他物件資料
            /// </summary>
            public Dictionary<int, int> dcPlayerItem = new Dictionary<int, int>();

            #endregion

            /// <summary>
            /// 驗證ID
            /// </summary>
            public string sVerify;

            /// <summary>
            /// 用來判斷是不是第一筆SumTotal資料 [ 0:代表第一筆 ]
            /// </summary>
            public int iSumTotal;
        }

        /// <summary>
        /// 玩家身上資料異動 [ 傳入值為要累加的值 ]
        /// </summary>
        [Serializable]
        public class PdaUpdatePlayerItem
        {
            /// <summary>
            /// 玩家Uid
            /// </summary>
            public Int64 iPlayerUid;
            /// <summary>
            /// 鑽幣
            /// </summary>
            public int iPointsCount;
            /// <summary>
            /// 鑽石
            /// </summary>
            public int iDiamondCount;
            /// <summary>
            /// 經驗值
            /// </summary>
            public int iExpValue;
            /// <summary>
            /// 經驗值 [ 原本的 ]
            /// </summary>
            public int iExpValueOrg;
            /// <summary>
            /// 等級 LV
            /// </summary>
            public int iLv;
        }

        #endregion

    }
}

