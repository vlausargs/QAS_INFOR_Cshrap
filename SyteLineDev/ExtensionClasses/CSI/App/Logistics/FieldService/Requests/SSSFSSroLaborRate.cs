//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroLaborRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSroLaborRate
    {
        int SSSFSSroLaborRateSp(string iTransType,
                                string iSroNum,
                                int? iSroLine,
                                int? iSroOper,
                                string iBillCode,
                                DateTime? iTransDate,
                                string iPartnerId,
                                string iWorkCode,
                                decimal? iUnitCost,
                                decimal? iHrsWorked,
                                decimal? iHrsBilled,
                                ref decimal? oUnitPrice,
                                ref string Infobar);
    }

    public class SSSFSSroLaborRate : ISSSFSSroLaborRate
    {
        readonly IApplicationDB appDB;

        public SSSFSSroLaborRate(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSroLaborRateSp(string iTransType,
                                       string iSroNum,
                                       int? iSroLine,
                                       int? iSroOper,
                                       string iBillCode,
                                       DateTime? iTransDate,
                                       string iPartnerId,
                                       string iWorkCode,
                                       decimal? iUnitCost,
                                       decimal? iHrsWorked,
                                       decimal? iHrsBilled,
                                       ref decimal? oUnitPrice,
                                       ref string Infobar)
        {
            StringType _iTransType = iTransType;
            FSSRONumType _iSroNum = iSroNum;
            FSSROLineType _iSroLine = iSroLine;
            FSSROOperType _iSroOper = iSroOper;
            FSSROBillCodeType _iBillCode = iBillCode;
            DateTimeType _iTransDate = iTransDate;
            FSPartnerType _iPartnerId = iPartnerId;
            FSWorkCodeType _iWorkCode = iWorkCode;
            CostPrcType _iUnitCost = iUnitCost;
            AmountType _iHrsWorked = iHrsWorked;
            AmountType _iHrsBilled = iHrsBilled;
            CostPrcType _oUnitPrice = oUnitPrice;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSroLaborRateSp";

                appDB.AddCommandParameter(cmd, "iTransType", _iTransType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSroOper", _iSroOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iBillCode", _iBillCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iTransDate", _iTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iPartnerId", _iPartnerId, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iWorkCode", _iWorkCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iUnitCost", _iUnitCost, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iHrsWorked", _iHrsWorked, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iHrsBilled", _iHrsBilled, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "oUnitPrice", _oUnitPrice, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                oUnitPrice = _oUnitPrice;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
