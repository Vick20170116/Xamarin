using System;
using Xamarin.Forms.Xaml;

using VickApp2.Models;
using Xamarin.Essentials;
using static VickApp2.Models.PTC_DataType;

namespace VickApp2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : XBasePage
    {
        public Login():base()
        {
            InitializeComponent();

            BindingContext = this;

            txId.Text = GetPreferences("sId", string.Empty);
        }

        protected async void BtnLogin_OnClicked(object sender, EventArgs e)
        {
            try
            {
                // 輸入欄位 取消前後空白 [ 若沒有資料，跳出訊息 ] 多型
                if (!await CheckTextBox(txId, lblId)) { return; }
                if (!await CheckTextBox(txPwd, "密碼欄位不可以空白！")) { return; }

                btnLogin.IsEnabled = false;

                // 跳出遮罩，轉圈圈 (PopupPage)
                await OpenPopup(new Loading(), false);

                // 串聯WebApi
                NewWebApi();
                var vResult = await _webApi.LoginAsync(txId.Text, txPwd.Text);

                // 關閉最後一個開啟的PopupPage
                await ClosePopup();

                if (vResult.Data.iPlayerUid > 0)
                {
                    PTC_Member.PdaPlayerInfo pdaPlayer = vResult.Data;

                    App.pdaUser.sId = txId.Text;
                    SetPreferences("sId", txId.Text);

                    App.pdaUser.sPwd = txPwd.Text;

                    // Alert 訊息
                    await XPageAlert(enMessage.Inform, $"歡迎 [ {pdaPlayer.sNickName} ] 進入系統", enDoEvent.Yes);
                }
                else
                {
                    // Alert 訊息
                    await XPageAlert(enMessage.Warning, "帳密錯誤，請重新輸入", enDoEvent.Yes);
                }

                btnLogin.IsEnabled = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}