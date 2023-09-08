//PROJECT NAME: Admin
//CLASS NAME: RefreshTaxData.cs

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshTaxData : IRefreshIntegrationData
    {
        IApplicationDB appDB;
        readonly bool isProduction;

        public RefreshTaxData(IApplicationDB appDB, bool isProduction = false)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
            this.isProduction = isProduction;
        }

        public (int, string) PreRefresh()
        {
            XElement xmlResult = new XElement("VRTX_PARM");

            // Save data only if target is a non-PROD farm
            if (!this.isProduction)
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT 
                                          [site_ref],
                                          [compcd],
                                          [db_version],
                                          [avatax_url],
                                          [avatax_account],
                                          [avatax_license],
                                          [twe_user],
                                          [twe_password],
                                          [vrtx_web_url]
                                        FROM [vrtx_parm_mst]
                                        WHERE [db_version] in ('A','O')";

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            XElement row = new XElement("row");
                            row.Add(new XElement("site_ref", reader[0]));
                            row.Add(new XElement("compcd", reader[1]));
                            row.Add(new XElement("db_version", reader[2]));
                            row.Add(new XElement("avatax_url", reader[3]));
                            row.Add(new XElement("avatax_account", reader[4]));
                            row.Add(new XElement("avatax_license", reader[5]));
                            row.Add(new XElement("twe_user", reader[6]));
                            row.Add(new XElement("twe_password", reader[7]));
                            row.Add(new XElement("vrtx_web_url", reader[8]));
                            xmlResult.Add(row);
                        }
                    }
                }
            }

            return (0, xmlResult.ToString());
        }

        public int PostRefresh(string PreRefreshData)
        {
            // Clear key tax info from post-refresh db
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [vrtx_parm_mst] SET
                                      [compcd] = null,
                                      [db_version] = null,
                                      [avatax_url] = null,
                                      [avatax_account] = null,
                                      [avatax_license] = null,
                                      [twe_user] = null,
                                      [twe_password] = null,
                                      [vrtx_web_url] = null
                                    FROM [vrtx_parm_mst]
                                    WHERE [db_version] in ('A','O')";

                appDB.ExecuteNonQuery(cmd);
            }

            // Restore key tax info from pre-refresh tax when refreshing a non-PROD database
            if (!this.isProduction && !String.IsNullOrEmpty(PreRefreshData))
            {
                // Parse pre-refresh data
                XElement taxXml = XElement.Parse(PreRefreshData);
                IEnumerable<XElement> taxRows = taxXml.Elements("row");

                // Process each row
                foreach (XElement row in taxRows)
                {
                    SiteType site_ref = row.Element("site_ref").Value;
                    if (String.IsNullOrEmpty(site_ref)) continue; // skip rows with no site_ref
                    VTXCompCdType compcd = row.Element("compcd").Value;
                    VTXDBVersionType db_version = row.Element("db_version").Value;
                    LongDescType avatax_url = row.Element("avatax_url").Value;
                    LongDescType avatax_account = row.Element("avatax_account").Value;
                    ShortDescType avatax_license = row.Element("avatax_license").Value;
                    UsernameType twe_user = row.Element("twe_user").Value;
                    EncryptedClientPasswordType twe_password = row.Element("twe_password").Value;
                    LongDescType vrtx_web_url = row.Element("vrtx_web_url").Value;

                    using (IDbCommand cmd = appDB.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE [vrtx_parm_mst] SET
                                              [compcd] = @P1,
                                              [db_version] = @P2,
                                              [avatax_url] = @P3,
                                              [avatax_account] = @P4,
                                              [avatax_license] = @P5,
                                              [twe_user] = @P6,
                                              [twe_password] = @P7,
                                              [vrtx_web_url] = @P8
                                            FROM [vrtx_parm_mst]
                                            WHERE [site_ref] = @P0";

                        appDB.AddCommandParameter(cmd, "P0", site_ref);
                        appDB.AddCommandParameter(cmd, "P1", compcd);
                        appDB.AddCommandParameter(cmd, "P2", db_version);
                        appDB.AddCommandParameter(cmd, "P3", avatax_url);
                        appDB.AddCommandParameter(cmd, "P4", avatax_account);
                        appDB.AddCommandParameter(cmd, "P5", avatax_license);
                        appDB.AddCommandParameter(cmd, "P6", twe_user);
                        appDB.AddCommandParameter(cmd, "P7", twe_password);
                        appDB.AddCommandParameter(cmd, "P8", vrtx_web_url);
 
                        appDB.ExecuteNonQuery(cmd);
                    }
                }
            }

            return 0;
        }
    }
}
