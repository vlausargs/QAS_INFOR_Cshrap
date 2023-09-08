//PROJECT NAME: CSICodes
//CLASS NAME: EFTCreateEventHandler.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IEFTCreateEventHandler
    {
        int EFTCreateEventHandlerSp(EFTMappingIdType MapId,
                                    ref InfobarType Infobar);
    }

    public class EFTCreateEventHandler : IEFTCreateEventHandler
    {
        readonly IApplicationDB appDB;

        public EFTCreateEventHandler(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EFTCreateEventHandlerSp(EFTMappingIdType MapId,
                                           ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EFTCreateEventHandlerSp";

                appDB.AddCommandParameter(cmd, "MapId", MapId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
