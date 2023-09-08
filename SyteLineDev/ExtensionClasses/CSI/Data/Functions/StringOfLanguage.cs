//PROJECT NAME: Data
//CLASS NAME: StringOfLanguage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class StringOfLanguage : IStringOfLanguage
    {
        readonly IApplicationDB appDB;

        public StringOfLanguage(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string StringOfLanguageFn(
            string Parm,
            string MessageLanguage)
        {
            Infobar _Parm = Parm;
            MessageLanguageType _MessageLanguage = MessageLanguage;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[StringOfLanguage](@Parm, @MessageLanguage)";

                appDB.AddCommandParameter(cmd, "Parm", _Parm, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MessageLanguage", _MessageLanguage, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}