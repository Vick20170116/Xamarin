using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace VickApp2.Models
{
    public class PTC_DataType
    {
        public const string sMsgTitle = "";

        #region "-- 訊息 --"

        /// <summary>
        /// 訊息類別列舉
        /// </summary>
        public enum enMessage
        {
            /// <summary>
            /// 資訊
            /// </summary>
            [Description("通知訊息")]
            Inform = 0,
            /// <summary>
            /// 公告
            /// </summary>
            [Description("公告訊息")]
            Notice = 1,
            /// <summary>
            /// 警告
            /// </summary>
            [Description("警告訊息")]
            Warning = 2
        }

        public enum enDoEvent
        {
            /// <summary>
            /// 確定
            /// </summary>
            [Description("確定")]
            Yes = 0,
            /// <summary>
            /// 否定
            /// </summary>
            [Description("否定")]
            No = 1,
            /// <summary>
            /// 放棄
            /// </summary>
            [Description("放棄")]
            Cancel = 2,
        }




        public string MsgTitle(enMessage eMsg) => SetMsgTitle(eMsg);

        // 取得 Enum 列舉 Attribute Description 設定值
        public static string GetEnumDesc<T>(T source)
        {
            FieldInfo fi = source.GetType().GetField(source.ToString());
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);
            if (attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

        /// <summary>
        /// 訊息類別資訊
        /// </summary>
        /// <param name="eMsg">訊息類別</param>
        public string SetMsgTitle(enMessage eMsg)
        {
            switch (eMsg)
            {
                case enMessage.Inform:
                    return "通知訊息";
                case enMessage.Notice:
                    return "公告訊息";
                case enMessage.Warning:
                    return "警告訊息";
                default:
                    throw new ArgumentOutOfRangeException(nameof(eMsg), eMsg, null);
            }
        }

        #endregion

        #region "-- DataType --"

        /// <summary>
        /// 資料格式列舉：
        /// <para>[ Boolean: 布林值； String: 字串 ]</para>
        /// <para>[ Int: 整數32bit[等同Int32]； Int32: 整數32bit； Int16: 整數16bit； Int64: 整數64bit ]</para>
        /// <para>[ Double: 浮點數； Long: 浮點數； Decimal: 貨幣格式； Byte: Byte； Object: 物件 ]</para>
        /// <para>[ DateTime: 日期時間； TimeSpan: 時間間隔； Null: Null ]</para>
        /// </summary>
        public enum enDataType : short
        {
            /// <summary>
            /// 布林值
            /// </summary>
            Boolean,
            /// <summary>
            /// 字串
            /// </summary>
            String,
            /// <summary>
            /// 整數32bit [等同Int32]
            /// </summary>
            Int,
            /// <summary>
            /// 整數16bit
            /// </summary>
            Int32,
            /// <summary>
            /// 整數64bit
            /// </summary>
            Int64,
            /// <summary>
            /// 浮點數
            /// </summary>
            Double,
            /// <summary>
            /// 浮點數
            /// </summary>
            Float,
            /// <summary>
            /// 貨幣格式
            /// </summary>
            Decimal,
            /// <summary>
            /// Byte
            /// </summary>
            Byte,
            /// <summary>
            /// Object
            /// </summary>
            Object,
            /// <summary>
            /// Null
            /// </summary>
            Null,
        }

        #endregion
    }
}
