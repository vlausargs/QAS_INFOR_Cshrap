//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_GetTodaysKeySalespersonValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IHomepage_GetTodaysKeySalespersonValues
    {
        int Homepage_GetTodaysKeySalespersonValuesSp(ref decimal? CommissionDue,
                                                     ref decimal? CommissionPaid,
                                                     ref decimal? BookingAmount,
                                                     ref decimal? PipelineAmount,
                                                     ref decimal? EstimateAmount,
                                                     ref DateTime? PeriodStart,
                                                     ref DateTime? PeriodEnd,
                                                     ref string Slsman);
    }

    public class Homepage_GetTodaysKeySalespersonValues : IHomepage_GetTodaysKeySalespersonValues
    {
        readonly IApplicationDB appDB;

        public Homepage_GetTodaysKeySalespersonValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Homepage_GetTodaysKeySalespersonValuesSp(ref decimal? CommissionDue,
                                                            ref decimal? CommissionPaid,
                                                            ref decimal? BookingAmount,
                                                            ref decimal? PipelineAmount,
                                                            ref decimal? EstimateAmount,
                                                            ref DateTime? PeriodStart,
                                                            ref DateTime? PeriodEnd,
                                                            ref string Slsman)
        {
            AmountType _CommissionDue = CommissionDue;
            AmountType _CommissionPaid = CommissionPaid;
            AmountType _BookingAmount = BookingAmount;
            AmountType _PipelineAmount = PipelineAmount;
            AmountType _EstimateAmount = EstimateAmount;
            DateType _PeriodStart = PeriodStart;
            DateType _PeriodEnd = PeriodEnd;
            SlsmanType _Slsman = Slsman;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Homepage_GetTodaysKeySalespersonValuesSp";

                appDB.AddCommandParameter(cmd, "CommissionDue", _CommissionDue, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CommissionPaid", _CommissionPaid, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BookingAmount", _BookingAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PipelineAmount", _PipelineAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "EstimateAmount", _EstimateAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PeriodStart", _PeriodStart, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PeriodEnd", _PeriodEnd, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Slsman", _Slsman, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                CommissionDue = _CommissionDue;
                CommissionPaid = _CommissionPaid;
                BookingAmount = _BookingAmount;
                PipelineAmount = _PipelineAmount;
                EstimateAmount = _EstimateAmount;
                PeriodStart = _PeriodStart;
                PeriodEnd = _PeriodEnd;
                Slsman = _Slsman;

                return Severity;
            }
        }
    }
}
