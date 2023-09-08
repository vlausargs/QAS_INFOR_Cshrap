//PROJECT NAME: Admin
//CLASS NAME: RefreshCCIData.cs

using System;
using System.Collections.Generic;
using System.Data;
using System.Xml.Linq;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;
using CSI.MG;

namespace CSI.Admin
{
    public class RefreshCCIData : IRefreshIntegrationData
    {
        IApplicationDB appDB;
        readonly bool isProduction;

        public RefreshCCIData(IApplicationDB appDB, bool isProduction = false)
        {
            this.appDB = appDB ?? throw new ArgumentNullException(nameof(appDB));
            this.isProduction = isProduction;
        }

        public (int, string) PreRefresh()
        {
            XElement xmlResult = new XElement("CCI_SYSTEM");

            // Save data only if target is a non-PROD farm
            if (!this.isProduction)
            {
                using (IDbCommand cmd = appDB.CreateCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"SELECT 
                                          [site_ref],
                                          [card_system_id],
                                          [card_system],
                                          [payment_server],
                                          [gateway_user_id],
                                          [gateway_password],
                                          [gateway_vend_id],
                                          [bank_code],
                                          [curr_code],
                                          [gateway_encryption_key],
                                          [gateway_api_key],
                                          [active],
                                          [default_for_curr_code]
                                        FROM [cci_system_mst] 
                                        WHERE [card_system] in ('B','C')";

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            XElement row = new XElement("row");
                            row.Add(new XElement("site_ref", reader[0]));
                            row.Add(new XElement("card_system_id", reader[1]));
                            row.Add(new XElement("card_system", reader[2]));
                            row.Add(new XElement("payment_server", reader[3]));
                            row.Add(new XElement("gateway_user_id", reader[4]));
                            row.Add(new XElement("gateway_password", reader[5]));
                            row.Add(new XElement("gateway_vend_id", reader[6]));
                            row.Add(new XElement("bank_code", reader[7]));
                            row.Add(new XElement("curr_code", reader[8]));
                            row.Add(new XElement("gateway_encryption_key", reader[9]));
                            row.Add(new XElement("gateway_api_key", reader[10]));
                            row.Add(new XElement("active", reader[11]));
                            row.Add(new XElement("default_for_curr_code", reader[12]));
                            xmlResult.Add(row);
                        }
                    }
                }
            }

            return (0, xmlResult.ToString());
        }

        public int PostRefresh(string PreRefreshData)
        {
            // Clear key CC info from post-refresh db
            using (IDbCommand cmd = appDB.CreateCommand())
            {
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"UPDATE [cci_system_mst] SET
                                      [payment_server] = null,
                                      [gateway_user_id] = null,
                                      [gateway_password] = null,
                                      [gateway_vend_id] = null,
                                      [gateway_encryption_key] = null,
                                      [gateway_api_key] = null,
                                      [active] = 0
                                    FROM [cci_system_mst]
                                    WHERE [card_system] in ('B','C')";

                appDB.ExecuteNonQuery(cmd);
            }

            // Restore key CC info from pre-refresh data when refreshing a non-PROD database
            if (!this.isProduction && !String.IsNullOrEmpty(PreRefreshData))
            {
                // Parse pre-refresh data
                XElement ccXml = XElement.Parse(PreRefreshData);
                IEnumerable<XElement> ccRows = ccXml.Elements("row");

                // Process each row
                foreach (XElement row in ccRows)
                {
                    SiteType site_ref = row.Element("site_ref").Value;
                    if (String.IsNullOrEmpty(site_ref)) continue; // skip rows with no site_ref
                    CCICardSystemType card_system = row.Element("card_system").Value;
                    CCICardSystemIDType card_system_id = row.Element("card_system_id").Value;
                    CurrCodeType curr_code = row.Element("curr_code").Value;
                    BankCodeType bank_code = row.Element("bank_code").Value;
                    URLType payment_server = row.Element("payment_server").Value;
                    UsernameType gateway_user_id = row.Element("gateway_user_id").Value;
                    PasswordType gateway_password = row.Element("gateway_password").Value;
                    CCIGatewayVendIdType gateway_vend_id = row.Element("gateway_vend_id").Value;
                    PasswordType gateway_encryption_key = row.Element("gateway_encryption_key").Value;
                    EncryptedPasswordType gateway_api_key = row.Element("gateway_api_key").Value;
                    ListYesNoType active = Convert.ToInt16(row.Element("active").Value);
                    ListYesNoType default_for_curr_code = Convert.ToInt16(row.Element("default_for_curr_code").Value);

                    using (IDbCommand cmd = appDB.CreateCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = @"UPDATE [cci_system_mst] SET
                                              [payment_server] = @P1,
                                              [gateway_user_id] = @P2,
                                              [gateway_password] = @P3,
                                              [gateway_vend_id] = @P4,
                                              [gateway_encryption_key] = @P5,
                                              [gateway_api_key] = @P6,
                                              [bank_code] = @P7,
                                              [active] = @P8,
                                              [default_for_curr_code] = @P12
                                            FROM [cci_system_mst]
                                            WHERE [site_ref] = @P0
                                              and [card_system_id] = @P9
                                              and [card_system] = @P10
                                              and [curr_code] = @P11";

                        appDB.AddCommandParameter(cmd, "P0", site_ref);
                        appDB.AddCommandParameter(cmd, "P1", payment_server);
                        appDB.AddCommandParameter(cmd, "P2", gateway_user_id);
                        appDB.AddCommandParameter(cmd, "P3", gateway_password);
                        appDB.AddCommandParameter(cmd, "P4", gateway_vend_id);
                        appDB.AddCommandParameter(cmd, "P5", gateway_encryption_key);
                        appDB.AddCommandParameter(cmd, "P6", gateway_api_key);
                        appDB.AddCommandParameter(cmd, "P7", bank_code);
                        appDB.AddCommandParameter(cmd, "P8", active);
                        appDB.AddCommandParameter(cmd, "P9", card_system_id);
                        appDB.AddCommandParameter(cmd, "P10", card_system);
                        appDB.AddCommandParameter(cmd, "P11", curr_code);
                        appDB.AddCommandParameter(cmd, "P12", default_for_curr_code);

                        appDB.ExecuteNonQuery(cmd);
                    }
                }
            }

            return 0;
        }
    }
}
