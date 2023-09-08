//PROJECT NAME: Material
//CLASS NAME: MtCodes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
    public class MtCodes : IMtCodes
    {
        readonly IApplicationDB appDB;

        public MtCodes(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode,
            string Infobar) MtCodesSp(
            int? CalculateTotalCost = 1,
            int? HyperspeedMode = 0,
            string Infobar = null)
        {
            IntType _CalculateTotalCost = CalculateTotalCost;
            IntType _HyperspeedMode = HyperspeedMode;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MtCodesSp";

                appDB.AddCommandParameter(cmd, "CalculateTotalCost", _CalculateTotalCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HyperspeedMode", _HyperspeedMode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
