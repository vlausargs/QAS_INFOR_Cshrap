//PROJECT NAME: Admin
//CLASS NAME: RefreshMingleIFSData.cs

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshMingleIFSData : IRefreshIntegrationData
    {
        IApplicationDB appDB;
        readonly bool isMingleUserSyncActive;

        public RefreshMingleIFSData(IApplicationDB appDB, bool isMingleUserSyncActive = false)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
            this.isMingleUserSyncActive = isMingleUserSyncActive;
        }

        public (int, string) PreRefresh()
        {
            XElement xmlResult = new XElement("UserNames");

            // No data needs saved if Mingle is syncing users
            if (!this.isMingleUserSyncActive)
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT Username, WorkstationLogin
                                    FROM UserNames 
                                    WHERE TRY_CONVERT(UNIQUEIDENTIFIER, WorkstationLogin) IS NOT NULL";

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            XElement row = new XElement("row");
                            row.Add(new XElement("Username", reader[0]));
                            row.Add(new XElement("WorkstationLogin", reader[1]));
                            xmlResult.Add(row);
                        }
                    }
                }
            }

            return (0, xmlResult.ToString());
        }

        public int PostRefresh(string PreRefreshData)
        {
            // No data needs restored if Mingle is syncing users
            if (!this.isMingleUserSyncActive)
            {
                // Clear any existing Mingle GUIDs
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"UPDATE UserNames SET WorkstationLogin = null
                                    FROM UserNames
                                    WHERE TRY_CONVERT(UNIQUEIDENTIFIER, WorkstationLogin) IS NOT NULL";

                    appDB.ExecuteNonQuery(cmd);
                }

                // Restore Mingle GUIDs for UserNames saved from pre-refresh
                if (!String.IsNullOrEmpty(PreRefreshData))
                {
                    // Parse pre-refresh data
                    XElement userXml = XElement.Parse(PreRefreshData);
                    IEnumerable<XElement> userRows = userXml.Elements("row");

                    // Process each row
                    foreach (XElement row in userRows)
                    {
                        // Username, WorkstationLogin
                        UsernameType Username = row.Element("Username").Value;
                        MediumDescType WorkstationLogin = row.Element("WorkstationLogin").Value;

                        using (IDbCommand cmd = appDB.CreateCommand())
                        {
                            cmd.CommandType = CommandType.Text;
                            cmd.CommandText = @"UPDATE UserNames SET WorkstationLogin = @P1
                                            FROM UserNames
                                            WHERE Username = @P2";

                            appDB.AddCommandParameter(cmd, "P1", WorkstationLogin);
                            appDB.AddCommandParameter(cmd, "P2", Username);

                            appDB.ExecuteNonQuery(cmd);
                        }
                    }
                }
            }

            return 0;
        }
    }
}
