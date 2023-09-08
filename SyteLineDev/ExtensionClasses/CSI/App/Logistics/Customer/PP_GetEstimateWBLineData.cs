//PROJECT NAME: CSICustomer
//CLASS NAME: PP_GetEstimateWBLineData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IPP_GetEstimateWBLineData
    {
        int PP_GetEstimateWBLineDataSp(CoNumType CoNum,
                                       CoLineType CoLine,
                                       ref JobType Job,
                                       ref SuffixType Suffix,
                                       ref ItemType Item,
                                       ref DescriptionType ItemDesc,
                                       ref CustNumType CustNum,
                                       ref ProspectIDType ProspectID,
                                       ref DateTimeType QuoteDate,
                                       ref RefTypeIJKPRTType XRefType,
                                       ref ListYesNoType XREFJobExists,
                                       ref ListYesNoType XREFJobIsPrintJob,
                                       ref ListYesNoType XREFQuoteExists,
                                       ref StringType QuoteMethod,
                                       ref QtyUnitNoNegType QtyOrderedConv,
                                       ref CoitemStatusType CoLineStatus,
                                       ref InfobarType Infobar);
    }

    public class PP_GetEstimateWBLineData : IPP_GetEstimateWBLineData
    {
        readonly IApplicationDB appDB;

        public PP_GetEstimateWBLineData(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PP_GetEstimateWBLineDataSp(CoNumType CoNum,
                                              CoLineType CoLine,
                                              ref JobType Job,
                                              ref SuffixType Suffix,
                                              ref ItemType Item,
                                              ref DescriptionType ItemDesc,
                                              ref CustNumType CustNum,
                                              ref ProspectIDType ProspectID,
                                              ref DateTimeType QuoteDate,
                                              ref RefTypeIJKPRTType XRefType,
                                              ref ListYesNoType XREFJobExists,
                                              ref ListYesNoType XREFJobIsPrintJob,
                                              ref ListYesNoType XREFQuoteExists,
                                              ref StringType QuoteMethod,
                                              ref QtyUnitNoNegType QtyOrderedConv,
                                              ref CoitemStatusType CoLineStatus,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PP_GetEstimateWBLineDataSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemDesc", ItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ProspectID", ProspectID, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QuoteDate", QuoteDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "XRefType", XRefType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "XREFJobExists", XREFJobExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "XREFJobIsPrintJob", XREFJobIsPrintJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "XREFQuoteExists", XREFQuoteExists, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QuoteMethod", QuoteMethod, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "QtyOrderedConv", QtyOrderedConv, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CoLineStatus", CoLineStatus, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
