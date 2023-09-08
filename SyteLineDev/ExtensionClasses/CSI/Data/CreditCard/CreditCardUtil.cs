using CSI.MG;
using CSI.Serializer;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;


namespace CSI.Data.CreditCard
{
    public class CreditCardUtil:ICreditCardUtil
    {

        readonly IApplicationDB appDB;

        private const string kKey = @"+~n2#@^)#JNaiy*-";
        private const string kIV = @"&Na\|fl2|]alT~nB";

        public CreditCardUtil(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public bool EncryptValue(string password, out string encryptedPassword, out string infobar)
        {
            encryptedPassword = null;
            infobar = null;
            if (!string.IsNullOrEmpty(password?.Trim()))
            {
                try
                {
                    using (var aes = new AesCryptoServiceProvider())
                    {
                        var enc = GetCryptoTransform(aes, true);
                        var inputbuffer = Encoding.UTF8.GetBytes(password);
                        var output = enc.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
                        encryptedPassword = Convert.ToBase64String(output);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    infobar = e.Message;
                    return false;
                }
            }
            else
            {
                infobar = appDB.GetMessage("E=MayNotBe", "@WBKPIParameter.Value", "@!blank");
                return false;
            }
        }
        public int CCIWebSession(string GatewayVendId, string GatewayEncryptionKey
                                          , ref string SessionData, ref string SessionDataPost
                                          , ref string sInfobar, ref byte iSuccess)
        {
            try
            {
                //Generate a random GUID
                string GuidStr = Guid.NewGuid().ToString();

                // Create random numbers for Begin and End
                int LocalBegin = 1;
                int Localend = GuidStr.Length;

                LocalBegin = GetRandomNum(1, GuidStr.Length);
                Localend = GetRandomNum(1, (GuidStr.Length - LocalBegin));

                // Decrypt AES Encryption Key

                string AESKey = "";

                if (!DecryptPassword(GatewayEncryptionKey,out AESKey,out sInfobar))
                {
                    iSuccess = 0;
                    return 0;
                }

                // Format the string to encrypt for SessionData
                string encryptMe = $"{LocalBegin},{Localend},{GuidStr},{GatewayVendId}";

                //Retrive the encrypted SessionData
                SessionData = decryptencrypt(encryptMe, AESKey, "encrypt");
                SessionDataPost = GatewayVendId + (GuidStr.Substring(LocalBegin, Localend));

                iSuccess = 1;
                return 0;
            }
            catch (Exception ex)
            {
                sInfobar = $"{ex.Message} {ex.StackTrace}";
                iSuccess = 0;
                return 0;
            }
        }

        private ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider csp, bool encrypting)
        {
            csp.IV = Encoding.ASCII.GetBytes(kIV);
            csp.Key = Encoding.ASCII.GetBytes(kKey);
            if (encrypting)
            {
                return csp.CreateEncryptor();
            }
            return csp.CreateDecryptor();
        }
        private string decryptencrypt(string InputStr, string AesKeyword, string Selection)
        {
            string Response = "";
            if (string.IsNullOrEmpty(AesKeyword))
            {
                throw new Exception("Operation Failed, Keyword Missed");
            }

            string Option = Selection;

            if (Option.Equals("encrypt"))
            {
                Response = Encrypt(InputStr, AesKeyword, AesKeyword + "Salt", AesKeyword + "Cenpos");
            }
            else if (Option.Equals("decrypt"))
            {
                Response = Decrypt(System.Net.WebUtility.UrlDecode(InputStr), AesKeyword, AesKeyword + "Salt", AesKeyword + "Cenpos");
            }

            if (string.IsNullOrEmpty(Response))
            {
                throw new Exception("Operation Failed, Response Invalid ");
            }
            return Response;
        }
        private string Decrypt(string toDecrypt, string Key, string Salt, string IV)
        {
            return DecodeAndDecryptJava(toDecrypt.Replace(' ', '+'), Key, Salt, IV);
        }
        private string Encrypt(string toEncrypt, string Key, string Salt, string IV)
        {
            return System.Net.WebUtility.UrlEncode(EncryptAndEncodeJava(toEncrypt, Key, Salt, IV));
        }
        private string EncryptAndEncodeJava(string raw, string password, string salt, string iv)
        {
            using (var csp = new AesCryptoServiceProvider())
            {
                ICryptoTransform e = GetCryptoTransform(csp, true, salt, password, iv);
                var inputBuffer = Encoding.UTF8.GetBytes(raw);
                var output = e.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                string encrypted = Convert.ToBase64String(output);
                return encrypted;
            }
        }
        private string DecodeAndDecryptJava(string encrypted, string password, string salt, string iv)
        {
            using (var csp = new AesCryptoServiceProvider())
            {
                var d = GetCryptoTransform(csp, false, salt, password, iv);
                var output = Convert.FromBase64String(encrypted);
                var decryptedOutput = d.TransformFinalBlock(output, 0, output.Length);
                var decypted = Encoding.UTF8.GetString(decryptedOutput);
                return decypted;
            }
        }
        private ICryptoTransform GetCryptoTransform(AesCryptoServiceProvider csp, bool encrypting, string salt, string password, string iv)
        {
            csp.Mode = CipherMode.CBC;
            csp.Padding = PaddingMode.PKCS7;
            var spec = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(salt), 65536);
            var key = spec.GetBytes(16);

            csp.IV = Encoding.UTF8.GetBytes(iv);
            csp.Key = key;
            if (encrypting)
            {
                return csp.CreateEncryptor();
            }
            return csp.CreateDecryptor();
        }
        //This method Is Not public - it should only be used internally In this project
        private bool  DecryptPassword(string encryptedPassword,out string password,out string infobar)
        {
            password = null;
            infobar = null;
            try
            {
                using (var aes = new AesCryptoServiceProvider())
                using (var ms = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
                {
                    var enc = GetCryptoTransform(aes, false);
                    using (var encStream = new CryptoStream(ms, enc, CryptoStreamMode.Read))
                    using (var sr = new StreamReader(encStream))
                    {
                        try
                        {
                            password = sr.ReadLine();
                        }
                        catch (CryptographicException e)
                        {
                            infobar = e.Message;
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception e)
            {
                infobar = e.Message;
                return false;
            }
        }
        private int GetRandomNum(int startNum, int endNum)
        {
            int gap;
            int ranNum;
            int milSecond = DateTime.Now.Millisecond * 123456;
            int i = 0;
            gap = endNum - startNum;
            while (milSecond > endNum)
            {
                milSecond = (int)(milSecond / gap);
                i = i + 1;
            }

            ranNum = (int)(startNum + milSecond + Math.Pow(-1 , i));
            return ranNum;
        }
        public bool ValidateEmail(string Email)
        {
            return Regex.IsMatch(Email, @"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$");            
        }
        public bool ValidateAuthType(string AuthType)
        {
            RegexOptions options = RegexOptions.IgnoreCase;
            return AuthType != null && AuthType.Length == 4 && Regex.IsMatch(AuthType, @"(sale)?|(auth)?", options);
        }
        public bool ValidateCustNum(string CustNum)
        {
            return CustNum.Length == 7;
        }
        public bool PreValidate(string Email,string AuthType,string CustNum, out string sInfobar)
        {
            sInfobar = null;
            if (Email != null && !ValidateEmail(Email))
            {
                sInfobar = appDB.GetMessage("E=Invalid", "@fs_cust_contact.email");
                return false;
            }
            if (!ValidateAuthType(AuthType))
            {
                sInfobar = appDB.GetMessage("E=OSInvalid", "@!Type",AuthType);
                return false;
            }
            if (CustNum != null && !ValidateCustNum(CustNum))
            {
                sInfobar = appDB.GetMessage("E=Invalid", "@custlog.cust_num");
                return false;
            }
            return true;
        }
        public int WebPaySiteVerify(string GatewayEncryptionKey,string GatewayAPIKey,string Email, decimal? TotalAmt, string AuthType, string CustNum, out string VerifyingPost, out string Infobar)
        {
            VerifyingPost = null;
            Infobar = null;

            byte[] response = null;
            string unEncryptedGatewayEncryptionKey = null;
            string unEncryptedGatewayAPIKey = null;
        
            if (!DecryptPassword(GatewayEncryptionKey, out unEncryptedGatewayEncryptionKey, out Infobar))
                return 16;
            if (!DecryptPassword(GatewayAPIKey, out unEncryptedGatewayAPIKey, out Infobar))
                return 16;
            if (!PreValidate(Email, AuthType, CustNum, out Infobar))
                return 16;

            using (WebClient client = new WebClient())
            {
                response =
client.UploadValues("https://www3.cenpos.net/webpay/v7/html5/?app=genericcontroller&action=siteVerify", new NameValueCollection() {
                    { "secretkey", unEncryptedGatewayEncryptionKey},
                    { "merchant", unEncryptedGatewayAPIKey},
                    { "email",  Email},
                    { "Amount",   TotalAmt.ToString() },
                    { "type",   AuthType },
                    { "customerCode",   CustNum }

            });
            }   
            Dictionary<string, string> captchaResponse = new SerializerFactory().Create(SerializerType.NewtonConvert).Deserialize<Dictionary<string, string>>(System.Text.Encoding.UTF8.GetString(response));

            if (captchaResponse["Result"] == "0" && captchaResponse.ContainsKey("Data"))
            {
                VerifyingPost = captchaResponse["Data"];
                return 0;
            }
            else
            {
                Infobar = captchaResponse["Message"];
                return 16;
            }
        }
    }
}
