using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using DocuSign.eSign.Api;
using DocuSign.eSign.Client;
using DocuSign.eSign.Client.Auth;
using DocuSign.eSign.Model;


namespace WebApplication1
{
    public partial class Register : System.Web.UI.Page
    {
        private string AccessToken = "";
        private string DS_CLIENT_ID = "ENTER YOUR DS CLIENT ID";
        private string DS_IMPERSONATED_USER_GUID = "ENTER YOUR IMPERSONATE USER ID";
        private string DS_AUTH_SERVER = "account-d.docusign.com";
        private string DS_PRIVATE_KEY = "";
		private string AccountIDVar = "";

		public string Message { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            { 

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string serverpath = Server.MapPath(".");
			string signerClientId = "1000";

			StreamReader sr = new StreamReader(serverpath+ @"\privatekey2.txt");
            DS_PRIVATE_KEY = sr.ReadToEnd();
            sr.Close();

            ApiClient APClient = new ApiClient();

            OAuth.OAuthToken authToken = APClient.RequestJWTUserToken(DS_CLIENT_ID,
                        DS_IMPERSONATED_USER_GUID,
                        DS_AUTH_SERVER,
                        Encoding.UTF8.GetBytes(DS_PRIVATE_KEY),
                        1);

            AccessToken = authToken.access_token;
			
			APClient.SetOAuthBasePath(DS_AUTH_SERVER);
			OAuth.UserInfo UserInfoGet = APClient.GetUserInfo(authToken.access_token);

			AccountIDVar = UserInfoGet.Accounts[0].AccountId;
			APClient = new ApiClient(UserInfoGet.Accounts[0].BaseUri + "/restapi");
			APClient.Configuration.AccessToken = AccessToken;

			TemplatesApi tempAPI = new TemplatesApi(APClient.Configuration);
			var template = tempAPI.ListTemplates(AccountIDVar).EnvelopeTemplates.First(x => x.Name == "Steady Property");

			Text LblTxtName = new Text
			{
				TabLabel = "TxtName",
				Value = TxtName.Text
			};

			Text LblTxtEmail = new Text
			{
				TabLabel = "TxtEmail",
				Value = TxtEmail.Text
			};

			Text LblTxtDOB = new Text
			{
				TabLabel = "TxtDOB",
				Value = TxtDOB.Text
			};

			string GenderValue = "";
			GenderValue = RbMale.Checked ? "Male" : "Female";

			Text LblTxtGender = new Text
			{
				TabLabel = "TxtGender",
				Value = GenderValue
			};

			Text LblTxtPhone = new Text
			{
				TabLabel = "TxtPhone",
				Value = TxtPhone.Text
			};

			Text LblTxtAddress = new Text
			{
				TabLabel = "TxtAddress",
				Value = TxtAddress.Text
			};

			Text LblTxtMember = new Text
			{
				TabLabel = "TxtMember",
				Value = DropMember.Text
			};

			Tabs tabs = new Tabs
			{
				TextTabs = new List<Text> { LblTxtName, LblTxtEmail, LblTxtDOB, LblTxtGender, LblTxtPhone, LblTxtAddress, LblTxtMember }
			};

			TemplateRole signer = new TemplateRole
			{
				Email = TxtEmail.Text,
				Name = TxtName.Text,
				RoleName = "Signer1",
				ClientUserId = signerClientId,
				EmailNotification = new RecipientEmailNotification
				{
					EmailSubject = "Please sign the membership form",
					EmailBody = "Dear " + TxtName.Text + @", <br><br>Please sign the membership form and we will process your application form." +
		@"<br>You will recieve email confirmation within 48 hours<br><br>Thank you <br>Steady Property"
				},
				Tabs = tabs //Set tab values
			};

			TemplateRole cc = new TemplateRole
			{
				Email = TxtEmail.Text,
				Name = TxtName.Text,
				EmailNotification = new RecipientEmailNotification
				{
					EmailSubject = "Membership registation completed",
					EmailBody = "Dear " + TxtName.Text + @", <br><br>We will process your application form." +
	@"<br>You will recieve email confirmation within 48 hours<br><br>Thank you <br>Steady Property"
				},
				RoleName = "cc"
			};

			TemplateRole radmin = new TemplateRole
			{
				Email = "harry@ciptowibowo.com",
				Name = "Harry Tim",
				EmailNotification = new RecipientEmailNotification
				{
					EmailSubject = "New member registraion notification",
					EmailBody = "Dear Admin, <br><br>New membership registration for : " + TxtName.Text +
	@"<br>Please process it within 48 hours<br><br>Thank you <br>Steady Property"
				},
				RoleName = "admin"
			};

			EnvelopeDefinition envelopeAttributes = new EnvelopeDefinition
			{
				TemplateId = "5aa70f7a-7a21-496b-9f24-ada8431cf93b",
				Status = "Sent",
				TemplateRoles = new List<TemplateRole> { signer, cc, radmin }
			};

			EnvelopesApi envelopesApi = new EnvelopesApi(APClient.Configuration);
			EnvelopeSummary results = envelopesApi.CreateEnvelope(AccountIDVar, envelopeAttributes);
			
			RecipientViewRequest viewRequest = new RecipientViewRequest();

			viewRequest.ReturnUrl = "https://localhost:44387/Confirm.aspx" + "?envelopeid=" + results.EnvelopeId;

			viewRequest.AuthenticationMethod = "none";

			viewRequest.Email = TxtEmail.Text;
			viewRequest.UserName = TxtName.Text;
			viewRequest.ClientUserId = signerClientId;

			viewRequest.PingFrequency = "600"; // seconds
											   // NOTE: The pings will only be sent if the pingUrl is an HTTPS address
			viewRequest.PingUrl = "https://localhost"; // Optional setting

			ViewUrl results1 = envelopesApi.CreateRecipientView(AccountIDVar, results.EnvelopeId, viewRequest);

			Response.Redirect(results1.Url);
		}

    }
}