using Infor.DocumentManagement.ICP;
using Mongoose.Core.Common;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.MG.IDM
{
    public class IDM : IIDM
    {
        Connection connection;
        private string baseURL;
        private string username;
        private string password;

        public IDM(string BaseURL, string Username, string Password)
        {
            this.connection = new Connection();
            this.baseURL = BaseURL;
            this.username = Username;
            this.password = Password;
        }
       

        public bool ConnectOAuth1(string tenantID, string iFSUID, bool connectValidate = false)
        {
            this.connection = new Connection(baseURL, username, password, AuthenticationMode.OAuth1)
            {
                Tenant = tenantID,
                Username = iFSUID
            };
            connection.Connect(connectValidate);

            return connection.IsConnected;
        }

        public string GetFileContent(string fileName, string documentType, string direction)
        {
            string fileContent = "";
            string SearchString = @"[@RESOURCENAME=""" + fileName + @"""  ";
            SearchString = SearchString + @"AND @Direction=""" + direction + @"""" + "]";
            SearchString = Convert.ToString("/") + documentType + SearchString;

            CMItem item = CMItem.Search(connection, SearchString);

            // Filename Not Found
            if (item is null)
                return null;

            CMResource res = item.Resources.Values.FirstOrDefault();

            Stream inStream = res.GetUrlStream();
            StreamReader reader = new StreamReader(inStream);
            fileContent = reader.ReadToEnd();

            return fileContent;
        }
    }
}
