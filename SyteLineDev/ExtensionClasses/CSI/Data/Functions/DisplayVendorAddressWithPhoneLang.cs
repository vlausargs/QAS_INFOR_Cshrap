//PROJECT NAME: Data
//CLASS NAME: DisplayVendorAddressWithPhoneLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class DisplayVendorAddressWithPhoneLang : IDisplayVendorAddressWithPhoneLang
    {
        readonly IApplicationDB appDB;

        public DisplayVendorAddressWithPhoneLang(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string DisplayVendorAddressWithPhoneLangSp(
            string VendNum,
            string MessageLanguage,
            string Contact = null)
        {
            VendNumType _VendNum = VendNum;
            MessageLanguageType _MessageLanguage = MessageLanguage;
            ContactType _Contact = Contact;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[DisplayVendorAddressWithPhoneLangSp](@VendNum, @MessageLanguage, @Contact)";

                appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Contact", _Contact, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
