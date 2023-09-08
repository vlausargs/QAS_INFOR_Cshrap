using CSI.MG;
using CSI.MG.MGCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.Data.SQL
{
    public class SQLUserPrincipal : IUserPrincipal
    {
        readonly ICommandProvider _commandProvider;
        public string UserName => GetUserName();

        public string WorkstationID => GetWorkStation();

        public string Site => GetCurrentSite();

        public SQLUserPrincipal(ICommandProvider commandProvider)
        {
            _commandProvider = commandProvider;
        }

        private string GetUserName()
        {
            Guid sessionID = GetSessionID();
            string userName = GetUserNameBySessionID(sessionID);
            if (string.IsNullOrEmpty(userName))
            {
                userName = GetCreatedByFromSessionContextNames(sessionID);
                if (string.IsNullOrEmpty(userName))
                {
                    userName = GetSuserSname();
                }
            }
            return userName;
        }

        private string GetCurrentSite()
        {
            using (IDbCommand cmd = _commandProvider.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT RTRIM(CAST(CONTEXT_INFO() AS NVARCHAR(8)))";

                object siteObj = cmd.ExecuteScalar();
                return Convert.ToString(siteObj);
            }
        }

        private string GetWorkStation()
        {
            using (IDbCommand cmd = _commandProvider.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select WorkstationLogin from USERNAMES where Username = @username";
                cmd.Parameters.Add(new SqlParameter("@username", SqlDbType.VarChar, 256) { Value = this.UserName });

                object workStationIDObj = cmd.ExecuteScalar();
                return Convert.ToString(workStationIDObj);
            }
        }

        private Guid GetSessionID()
        {
            using (IDbCommand sessionCmd = _commandProvider.CreateCommand())
            {
                sessionCmd.CommandType = CommandType.Text;
                sessionCmd.CommandText = "select SessionID from SessionContextNames where ProcessID = @@spid";

                object sessionIdObj = sessionCmd.ExecuteScalar();
                Guid sessionID;
                if (sessionIdObj == null || sessionIdObj.ToString() == "")
                {
                    sessionID = new Guid("00000000-0000-0000-0000-000000000000");
                }
                else
                {
                    sessionID = (Guid)sessionIdObj;
                }
                return sessionID;
            }
        }

        private string GetUserNameBySessionID(Guid sessionID)
        {
            using (IDbCommand userNameCmd = _commandProvider.CreateCommand())
            {
                userNameCmd.CommandType = CommandType.Text;
                userNameCmd.CommandText = "select Username, ImpersonatingUserName from ConnectionInformation where ConnectionID = @SessionID";

                object userNameObj = null;
                object impersonatingUserNameObj = null;
                userNameCmd.Parameters.Add(new SqlParameter("@SessionID", SqlDbType.VarChar, 36) { Value = sessionID.ToString() });
                using (IDataReader reader = userNameCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        userNameObj = reader[0];
                        impersonatingUserNameObj = reader[1];
                    }
                    if (impersonatingUserNameObj != null && impersonatingUserNameObj.ToString() != "")
                    {
                        userNameObj = impersonatingUserNameObj;
                    }
                    return Convert.ToString(userNameObj);
                }
            }
        }

        private string GetCreatedByFromSessionContextNames(Guid sessionID)
        {
            using (IDbCommand createUserNameCmd = _commandProvider.CreateCommand())
            {
                createUserNameCmd.CommandType = CommandType.Text;
                createUserNameCmd.CommandText = "select top 1 CreatedBy from SessionContextNames with (nolock)  where SessionID = @sessionID";

                createUserNameCmd.Parameters.Add(new SqlParameter("@sessionID", SqlDbType.VarChar, 36) { Value = sessionID.ToString() });
                object userName = createUserNameCmd.ExecuteScalar();
                return Convert.ToString(userName);
            }
        }

        private string GetSuserSname()
        {
            using (IDbCommand suserCmd = _commandProvider.CreateCommand())
            {
                suserCmd.CommandType = CommandType.Text;
                suserCmd.CommandText = "Select SUSER_SNAME()";

                object userName = suserCmd.ExecuteScalar();
                return Convert.ToString(userName);
            }
        }
    }
}
