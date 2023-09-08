//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROLaborDCValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROLaborDCValid
    {
        int SSSFSSROLaborDCValidSp(StringType Level,
                                   FSPartnerType PartnerID,
                                   FSWorkCodeType WorkCode,
                                   DateType TransDate,
                                   FSSRONumType SRONum,
                                   ref FSSROLineType SROLine,
                                   ref FSSROOperType SROOper,
                                   ref DescriptionType SroDesc,
                                   ref ItemType LineItem,
                                   ref DescriptionType OperDesc,
                                   ref FSSROBillCodeType BillCode,
                                   ref CostPrcType UnitCost,
                                   ref CostPrcType UnitRate,
                                   ref InfobarType Infobar);
    }

    public class SSSFSSROLaborDCValid : ISSSFSSROLaborDCValid
    {
        readonly IApplicationDB appDB;

        public SSSFSSROLaborDCValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROLaborDCValidSp(StringType Level,
                                          FSPartnerType PartnerID,
                                          FSWorkCodeType WorkCode,
                                          DateType TransDate,
                                          FSSRONumType SRONum,
                                          ref FSSROLineType SROLine,
                                          ref FSSROOperType SROOper,
                                          ref DescriptionType SroDesc,
                                          ref ItemType LineItem,
                                          ref DescriptionType OperDesc,
                                          ref FSSROBillCodeType BillCode,
                                          ref CostPrcType UnitCost,
                                          ref CostPrcType UnitRate,
                                          ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROLaborDCValidSp";

                appDB.AddCommandParameter(cmd, "Level", Level, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PartnerID", PartnerID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "WorkCode", WorkCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDate", TransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SRONum", SRONum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SROLine", SROLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SROOper", SROOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SroDesc", SroDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LineItem", LineItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OperDesc", OperDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BillCode", BillCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitCost", UnitCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UnitRate", UnitRate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
