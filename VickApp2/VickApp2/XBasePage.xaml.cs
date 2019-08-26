using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

using VickApp2.Models;
using VickApp2.Service;
using Xamarin.Essentials;
using static VickApp2.Models.PTC_DataType;

namespace VickApp2
{
    [ContentProperty("Children")]
    public partial class XBasePage : ContentPage, IDisposable
    {

        #region "-- Disposed --"

        private bool _blDisposed;
        
        /// <summary>
        /// 釋放資源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 釋放資源
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (!_blDisposed)
            {
                if (disposing)
                {
                    _tsSet?.Dispose();
                    _tsGet?.Dispose();
                }
                _blDisposed = true;
            }
        }

        #endregion

        #region "-- BasePage 寫法 --"

        public XBasePage()
        {
            InitializeComponent();
        }

        private View children;

        public View Children

        {

            get => this.children;

            set

            {

                this.children = value;
                this.cpBasePage.Children.Add(value);

            }

        }

        #endregion

        #region "-- 建立物件 --"

        public PTC_DataType ptcDataType;

        public void NewPtcDataType()
        {
            if (ptcDataType == null) { ptcDataType = new PTC_DataType(); }
        }


        // 串聯WebApi
        public WebApi _webApi;

        public void NewWebApi()
        {
            if (_webApi == null) { _webApi = new WebApi("http://192.168.1.202:6677"); }
        }

        #endregion

        #region "-- 畫面事件 --"

        /// <summary>
        /// Alert 訊息
        /// </summary>
        /// <param name="eMsg">訊息類別 [ PTC_DataType.enMessage ]</param>
        /// <param name="sDesc">訊息內容</param>
        /// <param name="eDe">訊息按鈕事件 [ PTC_DataType.enDoEvent ] </param>
        protected async Task XPageAlert(enMessage eMsg, string sDesc, enDoEvent eDe)
        {
            await DisplayAlert(GetEnumDesc(eMsg), sDesc, GetEnumDesc(eDe));
        }

        #region "-- Rg.Plugins --"


        #region "-- PopupPage 用法 --"

        //// Open a PopupPage
        //await Navigation.PushPopupAsync(page);

        //// Close the last PopupPage int the PopupStack
        //await Navigation.PopPopupAsync();

        //// Close all PopupPages in the PopupStack
        //await Navigation.PopAllPopupAsync();

        //// Close an one PopupPage in the PopupStack even if the page is not the last
        //await Navigation.RemovePopupPageAsync(page);

        #endregion

        /// <summary>
        /// 開啟 遮罩頁
        /// </summary>
        /// <param name="pg">遮罩頁</param>
        /// <param name="blAnimate"></param>
        protected async Task OpenPopup(PopupPage pg, bool blAnimate)
        {
            await Navigation.PushPopupAsync(pg, false);
        }

        /// <summary>
        /// 關閉 最後一個使用的 遮罩頁
        /// </summary>
        protected async Task ClosePopup()
        {
            await Navigation.PopPopupAsync();
        }

        #endregion

        #region "-- 判斷欄位資料 --"

        /// <summary>
        /// 輸入欄位 取消前後空白 [ 若沒有資料，跳出訊息 ]
        /// </summary>
        /// <param name="tx">輸入欄位</param>
        /// <param name="lbl">輸入欄位說明Lable</param>
        protected async Task<bool> CheckTextBox(Entry tx, Label lbl)
        {
            tx.Text = tx.Text.Trim();
            if (string.IsNullOrEmpty(tx.Text))
            {
                await XPageAlert(enMessage.Inform, $"請輸入{lbl.Text}", enDoEvent.Yes);
                return false;
            }

            return true;
        }


        /// <summary>
        /// 輸入欄位 取消前後空白 [ 若沒有資料，跳出訊息 ]
        /// </summary>
        /// <param name="tx">輸入欄位</param>
        /// <param name="sDesc">輸入欄位空白，訊息說明</param>
        protected async Task<bool> CheckTextBox(Entry tx, string sDesc)
        {
            tx.Text = tx.Text.Trim();
            if (string.IsNullOrEmpty(tx.Text))
            {
                await XPageAlert(enMessage.Inform, sDesc, enDoEvent.Yes);
                return false;
            }

            return true;
        }

        #endregion

        #endregion

        #region "-- 資料處理 --"

        #region "-- Data Transfer --"

        /// <summary>
        /// Object To String
        /// </summary>
        /// <param name="objVal">字串物件</param>
        public string ObjToStr(object objVal)
        {
            string s = "";
            if (!string.IsNullOrEmpty(objVal.ToString()))
            {
                s = objVal.ToString().Trim();
            }

            return s;
        }

        /// <summary>
        /// Object To Int
        /// </summary>
        /// <param name="objVal">數字物件</param>
        public int ObjToInt(object objVal)
        {
            int i = 0;
            if (string.IsNullOrEmpty(objVal.ToString())) return i;

            string s = objVal.ToString().Trim();
            if (s == "") return i;

            if (!int.TryParse(s, out i))
            {
                i = 0;
            }

            return i;
        }

        /// <summary>
        /// Object To Int64
        /// </summary>
        /// <param name="objVal">數字物件</param>
        public Int64 ObjToInt64(object objVal)
        {
            Int64 i = 0;
            if (string.IsNullOrEmpty(objVal.ToString())) return i;

            string s = objVal.ToString().Trim();
            if (s == "") return i;

            if (!Int64.TryParse(s, out i))
            {
                i = 0;
            }

            return i;
        }

        /// <summary>
        /// Object To Double
        /// </summary>
        /// <param name="objVal">數字物件</param>
        public double ObjToDb(object objVal)
        {
            double db = 0;
            if (string.IsNullOrEmpty(objVal.ToString())) return db;

            string s = objVal.ToString().Trim();
            if (s == "") return db;

            if (!double.TryParse(s, out db))
            {
                db = 0;
            }

            return db;
        }

        /// <summary>
        /// Object To Float
        /// </summary>
        /// <param name="objVal">數字物件</param>
        public float ObjToFloat(object objVal)
        {
            float f = 0;
            if (string.IsNullOrEmpty(objVal.ToString())) return f;

            string s = objVal.ToString().Trim();
            if (s == "") return f;

            if (!float.TryParse(s, out f))
            {
                f = 0;
            }

            return f;
        }

        /// <summary>
        /// Object To Decimal
        /// </summary>
        /// <param name="objVal">數字物件</param>
        public decimal ObjToDc(object objVal)
        {
            decimal dc = 0;
            if (string.IsNullOrEmpty(objVal.ToString())) return dc;

            string s = objVal.ToString().Trim();
            if (s == "") return dc;

            if (!decimal.TryParse(s, out dc))
            {
                dc = 0;
            }

            return dc;
        }

        /// <summary>
        /// Object To Byte
        /// </summary>
        /// <param name="objVal">數字物件</param>
        public Int64 ObjToByte(object objVal)
        {
            byte b = 0;
            if (string.IsNullOrEmpty(objVal.ToString())) return b;

            string s = objVal.ToString().Trim();
            if (s == "") return b;

            if (!byte.TryParse(s, out b))
            {
                b = 0;
            }

            return b;
        }

        #endregion

        #region "-- 泛型 --"

        /// <summary>
        /// 資料型別互換
        /// </summary>
        /// <typeparam name="TSource">來源型別</typeparam>
        /// <typeparam name="TDestination">轉型型別</typeparam>
        /// <param name="value">轉換的值</param>
        public TDestination Convert<TSource, TDestination>(TSource value)
        {
            var converter = TypeDescriptor.GetConverter(typeof(TSource));

            TDestination result = default(TDestination);

            // 判斷能不能轉型
            if (converter.CanConvertTo(typeof(TDestination)))
            {
                result = (TDestination)(converter.ConvertTo(value, typeof(TDestination)));
            }

            return result;
        }

        /// <summary>
        /// Switch Case Type
        /// </summary>
        public class TypeSwitch : IDisposable
        {

            /// <summary>
            /// 釋放資源
            /// </summary>
            public void Dispose()
            {
                GC.SuppressFinalize(this);
            }

            #region "-- Set (Action) --"

            Dictionary<Type, Action<object>> matches = new Dictionary<Type, Action<object>>();

            /// <summary>
            /// 建立Switch Case [ Set ]
            /// </summary>
            /// <typeparam name="T">Case 比對的值型別</typeparam>
            /// <param name="action">比對成功後，要做的行為</param>
            public TypeSwitch CaseSet<T>(Action<T> action) { matches.Add(typeof(T), (x) => action((T)x)); return this; }

            /// <summary>
            /// 使用方法
            /// </summary>
            /// <param name="x"></param>
            public void Switch(object x) { matches[x.GetType()](x); }

            #endregion

            #region "-- Get (Func) --"

            Dictionary<Type, Func<object, object>> fmatches = new Dictionary<Type, Func<object, object>>();

            /// <summary>
            /// 建立Switch Case [ Get ]
            /// </summary>
            /// <typeparam name="T">Case 比對的值型別</typeparam>
            /// <param name="func">比對成功後，要做的行為</param>
            public  TypeSwitch CaseGet<T>(Func<T, object> func) { fmatches.Add(typeof(T),(x)=> func((T)x)); return this; }

            /// <summary>
            /// 使用方法
            /// </summary>
            /// <param name="x"></param>
            public T Switch<T>(object x){object y = fmatches[x.GetType()](x); return (T)y ; }

            #endregion
        }

        #endregion

        /// <summary>
        /// Set Preferences 資料
        /// <para>[ 找不到型別的，直接轉型成字串 ]</para></summary>
        /// <param name="sKeyName">資料名稱</param>
        /// <param name="objValue">資料值</param>
        /// <param name="eDt">資料型別</param>
        public void SetPreferences(string sKeyName, object objValue, enDataType eDt = enDataType.String)
        {
            switch (eDt)
            {
                case enDataType.String:
                    Preferences.Set(sKeyName, ObjToStr(objValue));
                    break;
                case enDataType.Int:
                case enDataType.Int32:
                    Preferences.Set(sKeyName, ObjToInt(objValue));
                    break;
                case enDataType.Int64:
                    Preferences.Set(sKeyName, ObjToInt64(objValue));
                    break;
                case enDataType.Double:
                    Preferences.Set(sKeyName, ObjToDb(objValue));
                    break;
                case enDataType.Float:
                    Preferences.Set(sKeyName, ObjToFloat(objValue));
                    break;
                case enDataType.Byte:
                    Preferences.Set(sKeyName, ObjToByte(objValue));
                    break;
                default:
                    Preferences.Set(sKeyName, ObjToStr(objValue));
                    break;
            }
        }

        #region "-- SetPreferences --"

        private TypeSwitch _tsSet;

        private void NewTypeSwitchSet(string sKeyName)
        {
            if (_tsSet == null)
            {
                // 建立 Switch
                _tsSet = new TypeSwitch()
                    .CaseSet((string x) => Preferences.Set(sKeyName, x))
                    .CaseSet((int x) => Preferences.Set(sKeyName, x))
                    .CaseSet((long x) => Preferences.Set(sKeyName, x))
                    .CaseSet((bool x) => Preferences.Set(sKeyName, x))
                    .CaseSet((double x) => Preferences.Set(sKeyName, x))
                    .CaseSet((float x) => Preferences.Set(sKeyName, x))
                    .CaseSet((byte x) => Preferences.Set(sKeyName, x));
            }
        }

        public void SetPreferences<T>(string sKeyName, T objValue)
        {
            // 建立 Switch
            NewTypeSwitchSet(sKeyName);

            // 使用 Switch
            _tsSet.Switch(objValue);
        }

        #endregion

        #region "-- GetPreferences --"

        private TypeSwitch _tsGet;

        private void NewTypeSwitchGet(string sKeyName)
        {
            if (_tsGet == null)
            {
                _tsGet = new TypeSwitch()
                    .CaseGet((string x) => Preferences.Get(sKeyName, x))
                    .CaseGet((int x) => Preferences.Get(sKeyName, x))
                    .CaseGet((long x) => Preferences.Get(sKeyName, x))
                    .CaseGet((bool x) => Preferences.Get(sKeyName, x))
                    .CaseGet((double x) => Preferences.Get(sKeyName, x))
                    .CaseGet((float x) => Preferences.Get(sKeyName, x))
                    .CaseGet((byte x) => Preferences.Get(sKeyName, x));
            }
        }

        public T GetPreferences<T>(string sKeyName, T objDefault)
        {
            NewTypeSwitchGet(sKeyName);

            var result = _tsGet.Switch<T>(objDefault);
            return result;
        }

        #endregion

        #endregion
    }
}