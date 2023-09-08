using CSI.MG.IDM;
using CSI.MXLOC;
using Infor.DocumentManagement.ICP;
using Mongoose.Core.Common;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;

namespace CSI.MG.MXLOC
{
    [IDOExtensionClass("SLMXElectronicPaymentReceipts")]
    public class MXElectronicPaymentReceipts : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int? ProcessCFDIReceipt(ref string Infobar, string Username, string TenantID, string SiteRef, string BeginArCheckNum = null, string EndArCheckNum = null, DateTime? BeginPaymentDate = null, DateTime? EndPaymentDate = null)
        {
            var ap = GetConnectionParms("IDM", ref Infobar, SiteRef);
            var iDM = new IDMFactory().Create(this, ap.BaseURL, ap.Username, ap.Password);

            var iCFDIReport = new CFDIReceiptFactory().Create(this,
            iDM,
            true);

            var result = iCFDIReport.Process(Infobar, Username, TenantID, BeginArCheckNum, EndArCheckNum, BeginPaymentDate, EndPaymentDate);
            Infobar = result.Infobar;

            return result.Severity;
        }

        private AuthParms GetConnectionParms(string AppName, ref string Infobar, string SiteRef)
        {
            try
            {
                AuthParms ap = new AuthParms();
                // get IDM connection info
                LoadCollectionRequestData Request = new LoadCollectionRequestData("ExternalAppParameters", "AppName, BaseURL, UserName, UserPassword, AuthMethod, IsActive, AppInstance", "IsActive=1 AND AppName = " + SqlLiteral.Format(AppName.ToString(), SqlLiteralFormatFlags.UseQuotes), string.Empty, 1);
                LoadCollectionResponseData Response = new LoadCollectionResponseData();
                Response = this.Context.Commands.LoadCollection(Request);
                foreach (IDOItem ii in Response.Items)
                {
                    ap.BaseURL = ii.PropertyValues[1].GetValue(String.Empty);
                    ap.Username = ii.PropertyValues[2].GetValue(String.Empty);
                    ap.Password = Crypto.DecryptLogonString_AES(GetAccessToken(ii.PropertyValues[0].GetValue(String.Empty), ii.PropertyValues[6].GetValue(String.Empty), ref Infobar, SiteRef));
                    ap.AuthMethod = (AuthenticationMode)Enum.Parse(typeof(AuthenticationMode), ii.PropertyValues[4].GetValue(String.Empty));
                }
                return ap;
            }
            catch (Exception)
            {
                return null/* TODO Change to default(_) if this is not a reference type */;
            }
        }

        public string GetAccessToken(string ApplicationName, string ApplicationInstance, ref string InfoBar, string SiteRef)
        {
            InvokeRequestData irequestData = new InvokeRequestData();
            irequestData.IDOName = "ExternalAppParameters";
            irequestData.MethodName = "GetAccessToken";
            InvokeParameterList parameterList = new InvokeParameterList();
            parameterList.Add(ApplicationName);
            parameterList.Add(ApplicationInstance);
            parameterList.Add(SiteRef);
            parameterList.Add("");
            parameterList.Add("");
            irequestData.Parameters = parameterList;
            InvokeResponseData responseData = this.Context.Commands.Invoke(irequestData);
            InfoBar = responseData.Parameters[4].Value;
            return responseData.Parameters[3].Value;
        }

        public class AuthParms
        {
            private string pBaseURL;
            private string pUsername;
            private string pPsWord;
            private AuthenticationMode pAuthMethod;

            public string BaseURL
            {
                get
                {
                    return pBaseURL;
                }
                set
                {
                    pBaseURL = value;
                }
            }
            public string Username
            {
                get
                {
                    return pUsername;
                }
                set
                {
                    pUsername = value;
                }
            }
            public string Password
            {
                get
                {
                    return pPsWord;
                }
                set
                {
                    pPsWord = value;
                }
            }
            public AuthenticationMode AuthMethod
            {
                get
                {
                    return pAuthMethod;
                }
                set
                {
                    pAuthMethod = value;
                }
            }
        }
    }
}
