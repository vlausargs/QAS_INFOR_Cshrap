//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROLaborCost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROLaborCost
    {
        int SSSFSSROLaborCostSp(string iTransType,
                                string iSroNum,
                                int? iSroLine,
                                int? iSroOper,
                                string iPartnerId,
                                string iWorkCode,
                                DateTime? iTransDate,
                                ref decimal? oUnitCost,
                                ref string Infobar);
    }

    public class SSSFSSROLaborCost : ISSSFSSROLaborCost
    {
        readonly IApplicationDB appDB;

        public SSSFSSROLaborCost(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROLaborCostSp(string iTransType,
                                       string iSroNum,
                                       int? iSroLine,
                                       int? iSroOper,
                                       string iPartnerId,
                                       string iWorkCode,
                                       DateTime? iTransDate,
                                       ref decimal? oUnitCost,
                                       ref string Infobar)
        {
            StringType _iTransType = iTransType;
            FSSRONumType _iSroNum = iSroNum;
            FSSROLineType _iSroLine = iSroLine;
            FSSROOperType _iSroOper = iSroOper;
            FSPartnerType _iPartnerId = iPartnerId;
            FSWorkCodeType _iWorkCode = iWorkCode;
            DateTimeType _iTransDate = iTransDate;
            CostPrcType _oUnitCost = oUnitCost;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROLaborCostSp";

                appDB.AddCommandParameter(cmd, "iTransType", _iTransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iPartnerId", _iPartnerId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iWorkCode", _iWorkCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "oUnitCost", _oUnitCost, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                oUnitCost = _oUnitCost;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
