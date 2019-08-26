using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VickApp2
{
    public partial class App : Application
    {
        /// <summary>
        /// 使用者資料
        /// </summary>
        public class PdaUser
        {
            /// <summary>
            /// 使用者帳號
            /// </summary>
            public string sId;
            /// <summary>
            /// 使用者密碼
            /// </summary>
            public string sPwd;
        }

        public static PdaUser pdaUser;

        public App()
        {
            InitializeComponent();

            pdaUser = new PdaUser();

            MainPage = new Login();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
