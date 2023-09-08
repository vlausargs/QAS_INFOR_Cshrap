//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXShipDelete.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ISSSRMXShipDelete
    {
        int SSSRMXShipDeleteSp(string VendNum,
                               string RefType,
                               string RefNum,
                               int? RefLine,
                               int? RefRelease,
                               decimal? Seq,
                               ref string Infobar);
    }

    public class SSSRMXShipDelete : ISSSRMXShipDelete
    {
        readonly IApplicationDB appDB;

        public SSSRMXShipDelete(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSRMXShipDeleteSp(string VendNum,
                                      string RefType,
                                      string RefNum,
                                      int? RefLine,
                                      int? RefRelease,
                                      decimal? Seq,
                                      ref string Infobar)
        {
            VendNumType _VendNum = VendNum;
            RMXRefTypeType _RefType = RefType;
            RMXRefNumType _RefNum = RefNum;
            RMXRefLineSufType _RefLine = RefLine;
            RMXRefReleaseType _RefRelease = RefRelease;
            RMXSeqType _Seq = Seq;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRMXShipDeleteSp";

                appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefLine", _RefLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RefRelease", _RefRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
