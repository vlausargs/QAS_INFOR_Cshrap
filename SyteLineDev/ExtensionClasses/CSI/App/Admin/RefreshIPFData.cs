//PROJECT NAME: Admin
//CLASS NAME: RefreshIPFData.cs

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshIPFData : IRefreshIntegrationData
    {
        IApplicationDB appDB;

        public RefreshIPFData(IApplicationDB appDB)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
        }

        public (int, string) PreRefresh()
        {
            XElement xmlResult = new XElement("IPF");
             
            // Get portal_parms info
            XElement elePortalParms = new XElement("PORTAL_PARMS");
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT 
                                      [site_ref],
                                      [customer_portal_url],
                                      [vendor_portal_url],
                                      [reseller_portal_url],
                                      [customer_portal_consumer_key],
                                      [customer_portal_consumer_secret],
                                      [vendor_portal_consumer_key],
                                      [vendor_portal_consumer_secret],
                                      [reseller_portal_consumer_key],
                                      [reseller_portal_consumer_secret]
                                    FROM [portal_parms_mst] 
                                    WHERE [parm_key] = 0";

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        XElement row = new XElement("row");
                        row.Add(new XElement("site_ref", reader[0]));
                        row.Add(new XElement("customer_portal_url", reader[1]));
                        row.Add(new XElement("vendor_portal_url", reader[2]));
                        row.Add(new XElement("reseller_portal_url", reader[3]));
                        row.Add(new XElement("customer_portal_consumer_key", reader[4]));
                        row.Add(new XElement("customer_portal_consumer_secret", reader[5]));
                        row.Add(new XElement("vendor_portal_consumer_key", reader[6]));
                        row.Add(new XElement("vendor_portal_consumer_secret", reader[7]));
                        row.Add(new XElement("reseller_portal_consumer_key", reader[8]));
                        row.Add(new XElement("reseller_portal_consumer_secret", reader[9]));
                        elePortalParms.Add(row);
                    }
                }
            }
            xmlResult.Add(elePortalParms);

            // Get SL_Internal password
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"SELECT [UserPassword]
                                    FROM [UserNames] 
                                    WHERE [Username] = 'SL_Internal'";

                using (IDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read()) // at most one row
                    {
                        XElement eleUserName = new XElement("SLINTERNAL_CREDENTIALS", reader[0]);
                        xmlResult.Add(eleUserName);
                    }
                }
            }
 
            return (0, xmlResult.ToString());
        }

        public int PostRefresh(string PreRefreshData)
        {
            // Restore IPF info from pre-refresh
            if (!String.IsNullOrEmpty(PreRefreshData))
            {
                XElement xmlIpf = XElement.Parse(PreRefreshData);

                // Process PORTAL_PARMS data
                IEnumerable<XElement> rows = null;
                if (xmlIpf.Element("PORTAL_PARMS") != null)
                {
                    rows = xmlIpf.Element("PORTAL_PARMS").Elements("row");
                }
                else
                {
                    rows = xmlIpf.Elements("row"); // old format
                }
                foreach (XElement row in rows)
                {
                    SiteType site_ref = row.Element("site_ref").Value;
                    if (String.IsNullOrEmpty(site_ref)) continue; // skip rows with no site_ref
                    URLType customer_portal_url = row.Element("customer_portal_url").Value;
                    URLType vendor_portal_url = row.Element("vendor_portal_url").Value;
                    URLType reseller_portal_url = row.Element("reseller_portal_url").Value;
                    NetworkEncryptedPasswordType customer_portal_consumer_key = row.Element("customer_portal_consumer_key").Value;
                    NetworkEncryptedPasswordType customer_portal_consumer_secret = row.Element("customer_portal_consumer_secret").Value;
                    NetworkEncryptedPasswordType vendor_portal_consumer_key = row.Element("vendor_portal_consumer_key").Value;
                    NetworkEncryptedPasswordType vendor_portal_consumer_secret = row.Element("vendor_portal_consumer_secret").Value;
                    NetworkEncryptedPasswordType reseller_portal_consumer_key = row.Element("reseller_portal_consumer_key").Value;
                    NetworkEncryptedPasswordType reseller_portal_consumer_secret = row.Element("reseller_portal_consumer_secret").Value;

                    using (IDbCommand cmd = appDB.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE [portal_parms_mst] SET
                                              [customer_portal_url] = @P1,
                                              [vendor_portal_url] = @P2,
                                              [reseller_portal_url] = @P3,
                                              [customer_portal_consumer_key] = @P4,
                                              [customer_portal_consumer_secret] = @P5,
                                              [vendor_portal_consumer_key] = @P6,
                                              [vendor_portal_consumer_secret] = @P7,
                                              [reseller_portal_consumer_key] = @P8,
                                              [reseller_portal_consumer_secret] = @P9
                                            FROM [portal_parms_mst]
                                            WHERE [site_ref] = @P0 AND [parm_key] = 0";

                        appDB.AddCommandParameter(cmd, "P0", site_ref);
                        appDB.AddCommandParameter(cmd, "P1", customer_portal_url);
                        appDB.AddCommandParameter(cmd, "P2", vendor_portal_url);
                        appDB.AddCommandParameter(cmd, "P3", reseller_portal_url);
                        appDB.AddCommandParameter(cmd, "P4", customer_portal_consumer_key);
                        appDB.AddCommandParameter(cmd, "P5", customer_portal_consumer_secret);
                        appDB.AddCommandParameter(cmd, "P6", vendor_portal_consumer_key);
                        appDB.AddCommandParameter(cmd, "P7", vendor_portal_consumer_secret);
                        appDB.AddCommandParameter(cmd, "P8", reseller_portal_consumer_key);
                        appDB.AddCommandParameter(cmd, "P9", reseller_portal_consumer_secret);

                        appDB.ExecuteNonQuery(cmd);
                    }
                }

                // Process SLINTERNAL_CREDENTIALS data
                if (xmlIpf.Element("SLINTERNAL_CREDENTIALS") != null)
                {
                    EncryptedClientPasswordType UserPassword = xmlIpf.Element("SLINTERNAL_CREDENTIALS").Value;
                    using (IDbCommand cmd = appDB.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE [UserNames] SET [UserPassword] = @P1
                                            FROM [UserNames]
                                            WHERE [Username] = 'SL_Internal'";

                        appDB.AddCommandParameter(cmd, "P1", UserPassword);
 
                        appDB.ExecuteNonQuery(cmd);
                    }
                }
            }

            return 0;
        }
    }
}
