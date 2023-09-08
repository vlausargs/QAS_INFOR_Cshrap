//PROJECT NAME: CSICustomer
//CLASS NAME: PP_ProcessPrintingEstimateWB.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IPP_ProcessPrintingEstimateWB
    {
        int PP_ProcessPrintingEstimateWBSp(StringType QuoteType,
                                           CoNumType SourceNum,
                                           CoLineType SourceLine,
                                           CoNumType TargetCoNum,
                                           CoLineType TargetCoLine,
                                           ref JobType TargetJob,
                                           ref SuffixType TargetSuffix,
                                           ref InfobarType Infobar);
    }

    public class PP_ProcessPrintingEstimateWB : IPP_ProcessPrintingEstimateWB
    {
        readonly IApplicationDB appDB;

        public PP_ProcessPrintingEstimateWB(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PP_ProcessPrintingEstimateWBSp(StringType QuoteType,
                                                  CoNumType SourceNum,
                                                  CoLineType SourceLine,
                                                  CoNumType TargetCoNum,
                                                  CoLineType TargetCoLine,
                                                  ref JobType TargetJob,
                                                  ref SuffixType TargetSuffix,
                                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PP_ProcessPrintingEstimateWBSp";

                appDB.AddCommandParameter(cmd, "QuoteType", QuoteType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceNum", SourceNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SourceLine", SourceLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TargetCoNum", TargetCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TargetCoLine", TargetCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TargetJob", TargetJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TargetSuffix", TargetSuffix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
