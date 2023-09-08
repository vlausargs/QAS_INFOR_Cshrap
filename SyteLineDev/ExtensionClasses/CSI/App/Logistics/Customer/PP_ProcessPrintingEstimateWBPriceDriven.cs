//PROJECT NAME: CSICustomer
//CLASS NAME: PP_ProcessPrintingEstimateWBPriceDriven.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IPP_ProcessPrintingEstimateWBPriceDriven
    {
        int PP_ProcessPrintingEstimateWBPriceDrivenSp(StringType QuoteType,
                                                      CoNumType SourceNum,
                                                      CoLineType SourceLine,
                                                      CoNumType TargetCoNum,
                                                      CoLineType TargetCoLine,
                                                      ref InfobarType Infobar);
    }

    public class PP_ProcessPrintingEstimateWBPriceDriven : IPP_ProcessPrintingEstimateWBPriceDriven
    {
        readonly IApplicationDB appDB;

        public PP_ProcessPrintingEstimateWBPriceDriven(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PP_ProcessPrintingEstimateWBPriceDrivenSp(StringType QuoteType,
                                                             CoNumType SourceNum,
                                                             CoLineType SourceLine,
                                                             CoNumType TargetCoNum,
                                                             CoLineType TargetCoLine,
                                                             ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PP_ProcessPrintingEstimateWBPriceDrivenSp";

                appDB.AddCommandParameter(cmd, "QuoteType", QuoteType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceNum", SourceNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceLine", SourceLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TargetCoNum", TargetCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TargetCoLine", TargetCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
