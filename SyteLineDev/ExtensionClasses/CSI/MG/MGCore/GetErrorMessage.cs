//PROJECT NAME: MG.MGCore
//CLASS NAME: GetErrorMessage.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.MG.MGCore
{
    public class GetErrorMessage : IGetErrorMessage
    {
        IApplicationDB appDB;


        public GetErrorMessage(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) GetErrorMessageSp(string ObjectName,
        int? MessageType,
        string Infobar)
        {
            ObjectNameType _ObjectName = ObjectName;
            GenericTypeType _MessageType = MessageType;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetErrorMessageSp";

                appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "MessageType", _MessageType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
