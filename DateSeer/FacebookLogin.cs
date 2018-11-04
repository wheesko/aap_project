using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Facebook;

namespace DateSeer
{

    public partial class FacebookLogin : Form
    {
        private const string secret = "b02826f54cd73c8b5cc6f1b044f76b58";
        private const string FbSuccess =
        "https://www.facebook.com/connect/login_success.html";
        private const string AppId = "469134376928786";
        private const string ExtendedPermissions =
        "publish_actions, user_managed_groups, user_groups, user_birthday, user_gender";


        public FacebookLogin()
        {
            InitializeComponent();
            try
            {
                var loginUrl = GetLoginUrl();
                webBrowser1.Navigate(loginUrl);
            }
            catch (Exception ex) { }
        }

        private void FacebookLogin_Load(object sender, EventArgs e)
        {
         
        }

        private void webControl1_Click(object sender, EventArgs e)
        {

        }
        public string GetAccessToken(FacebookOAuthResult oauthResult)
        {
            var client = new FacebookClient();
            dynamic result = client.Get("oauth/access_token",
            new
            {
                client_id = AppId,
                client_secret = secret,
                redirect_uri = FbSuccess,
                code = oauthResult.Code
            });
            return result.access_token;
        }

        protected Uri GetLoginUrl()
        {
            FacebookClient a = new FacebookClient();
            var fbLoginUri = a.GetLoginUrl(new
            {
                client_id = AppId,
                redirect_uri = "https://www.facebook.com/connect/login_success.html",
                response_type = "code",
                display = "popup",
                scope = "email,user_birthday,user_gender"
            });
            return fbLoginUri;
        }
        
   
        public void LoginSucceeded(FacebookOAuthResult oauthResult)
        {
        
             var fb = new FacebookClient(GetAccessToken(oauthResult));
             dynamic result = fb.Get("/me/?fields=birthday,email,name,gender");
             MessageBox.Show("Login succeeded");
             MessageBox.Show(result.ToString());
             this.Hide();
             int gender = result["gender"] == "male" ? gender = 1 : gender = 2;           
             User user = new User(result["email"], result["name"], result["id"], result["birthday"], gender);
             DataController dataController = new DataController(new DatabaseDataManager());
             dataController.WriteData("UpdateFacebookID",user);
             Main main = new Main(user);
             main.Show();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            var fb = new FacebookClient();
            FacebookOAuthResult oauthResult;
            if (!fb.TryParseOAuthCallbackUrl(e.Url, out oauthResult))
                return;
            if (oauthResult.IsSuccess)
            {
                LoginSucceeded(oauthResult);
            }
            else
                MessageBox.Show("Login failed"); //LoginFailed(oauthResult); 

        }

        private void FacebookLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.Show();
        }
    }
}
