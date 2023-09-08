//PROJECT NAME: CSIMaterial
//CLASS NAME: GetNextASNRefLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IGetNextASNRefLine
    {
        int GetNextASNRefLineSp(TrnNumType BolitemRefNum,
                                BolNumType BolitemBolNum,
                                ref TrnLineType BolitemRefLine,
                                ref InfobarType Infobar);
    }

    public class GetNextASNRefLine : IGetNextASNRefLine
    {
        readonly IApplicationDB appDB;

        public GetNextASNRefLine(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetNextASNRefLineSp(TrnNumType BolitemRefNum,
                                       BolNumType BolitemBolNum,
                                       ref TrnLineType BolitemRefLine,
                                       ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetNextASNRefLineSp";

                appDB.AddCommandParameter(cmd, "BolitemRefNum", BolitemRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BolitemBolNum", BolitemBolNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BolitemRefLine", BolitemRefLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
