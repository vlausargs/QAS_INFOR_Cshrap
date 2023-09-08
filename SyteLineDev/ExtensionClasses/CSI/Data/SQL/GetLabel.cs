using System;
using System.Collections.Generic;
using System.Text;
using CSI.Data.SQL.UDDT;
using System.Data;
using CSI.MG.MGCore;
using CSI.MG;

namespace CSI.Data.SQL
{
    public class GetLabel : IGetLabel
    {
        IApplicationDB appDB;


        public GetLabel(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string GetLabelFn(string PObjectName)
        {
            Infobar _PObjectName = PObjectName;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetLabel](@PObjectName)";

                appDB.AddCommandParameter(cmd, "PObjectName", _PObjectName, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
