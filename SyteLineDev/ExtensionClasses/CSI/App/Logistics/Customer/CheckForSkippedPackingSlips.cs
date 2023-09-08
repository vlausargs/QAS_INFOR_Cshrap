//PROJECT NAME: CSICustomer
//CLASS NAME: CheckForSkippedPackingSlips.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICheckForSkippedPackingSlips
    {
        int CheckForSkippedPackingSlipsSp(int? COTypeA,
                                          int? CoTypeB,
                                          string CoStatus,
                                          string StartingOrder,
                                          string EndingOrder,
                                          string StartingCustomer,
                                          string EndingCustomer,
                                          DateTime? StartingOrderDate,
                                          DateTime? EndingOrderDate,
                                          string ParmSite,
                                          string CoLineStatus,
                                          string Whse,
                                          short? StartingLine,
                                          short? EndingLine,
                                          short? StartingRelease,
                                          short? EndingRelease,
                                          ref string Infobar);
    }

    public class CheckForSkippedPackingSlips : ICheckForSkippedPackingSlips
    {
        readonly IApplicationDB appDB;

        public CheckForSkippedPackingSlips(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CheckForSkippedPackingSlipsSp(int? COTypeA,
                                                 int? CoTypeB,
                                                 string CoStatus,
                                                 string StartingOrder,
                                                 string EndingOrder,
                                                 string StartingCustomer,
                                                 string EndingCustomer,
                                                 DateTime? StartingOrderDate,
                                                 DateTime? EndingOrderDate,
                                                 string ParmSite,
                                                 string CoLineStatus,
                                                 string Whse,
                                                 short? StartingLine,
                                                 short? EndingLine,
                                                 short? StartingRelease,
                                                 short? EndingRelease,
                                                 ref string Infobar)
        {
            IntType _COTypeA = COTypeA;
            IntType _CoTypeB = CoTypeB;
            StringType _CoStatus = CoStatus;
            CoNumType _StartingOrder = StartingOrder;
            CoNumType _EndingOrder = EndingOrder;
            CustNumType _StartingCustomer = StartingCustomer;
            CustNumType _EndingCustomer = EndingCustomer;
            DateType _StartingOrderDate = StartingOrderDate;
            DateType _EndingOrderDate = EndingOrderDate;
            SiteType _ParmSite = ParmSite;
            StringType _CoLineStatus = CoLineStatus;
            WhseType _Whse = Whse;
            CoLineType _StartingLine = StartingLine;
            CoLineType _EndingLine = EndingLine;
            CoReleaseType _StartingRelease = StartingRelease;
            CoReleaseType _EndingRelease = EndingRelease;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CheckForSkippedPackingSlipsSp";

                appDB.AddCommandParameter(cmd, "COTypeA", _COTypeA, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoTypeB", _CoTypeB, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoStatus", _CoStatus, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingCustomer", _StartingCustomer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingCustomer", _EndingCustomer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingOrderDate", _StartingOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingOrderDate", _EndingOrderDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ParmSite", _ParmSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLineStatus", _CoLineStatus, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingLine", _StartingLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingLine", _EndingLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingRelease", _StartingRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingRelease", _EndingRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
