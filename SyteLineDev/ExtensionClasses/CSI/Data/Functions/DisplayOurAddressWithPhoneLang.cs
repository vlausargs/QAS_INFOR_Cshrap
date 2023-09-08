//PROJECT NAME: Data
//CLASS NAME: DisplayOurAddressWithPhoneLang.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class DisplayOurAddressWithPhoneLang : IDisplayOurAddressWithPhoneLang
    {
        readonly IApplicationDB appDB;

        public DisplayOurAddressWithPhoneLang(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string DisplayOurAddressWithPhoneLangSp(
            string MessageLanguage)
        {
            MessageLanguageType _MessageLanguage = MessageLanguage;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[DisplayOurAddressWithPhoneLangSp](@MessageLanguage)";

                appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
