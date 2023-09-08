//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROMatlDCValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROMatlDCValid
    {
        int SSSFSSROMatlDCValidSp(string Level,
                                  string PartnerID,
                                  DateTime? TransDate,
                                  string SRONum,
                                  ref int? SROLine,
                                  ref int? SROOper,
                                  ref string SroDesc,
                                  ref string LineItem,
                                  ref string OperDesc,
                                  ref string TransType,
                                  ref string BillCode,
                                  ref string Whse,
                                  ref string Infobar,
                                  ref string CustNum);
    }

    public class SSSFSSROMatlDCValid : ISSSFSSROMatlDCValid
    {
        readonly IApplicationDB appDB;

        public SSSFSSROMatlDCValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROMatlDCValidSp(string Level,
                                         string PartnerID,
                                         DateTime? TransDate,
                                         string SRONum,
                                         ref int? SROLine,
                                         ref int? SROOper,
                                         ref string SroDesc,
                                         ref string LineItem,
                                         ref string OperDesc,
                                         ref string TransType,
                                         ref string BillCode,
                                         ref string Whse,
                                         ref string Infobar,
                                         ref string CustNum)
        {
            StringType _Level = Level;
            FSPartnerType _PartnerID = PartnerID;
            DateType _TransDate = TransDate;
            FSSRONumType _SRONum = SRONum;
            FSSROLineType _SROLine = SROLine;
            FSSROOperType _SROOper = SROOper;
            DescriptionType _SroDesc = SroDesc;
            ItemType _LineItem = LineItem;
            DescriptionType _OperDesc = OperDesc;
            FSSROMatlTransTypeType _TransType = TransType;
            FSSROBillCodeType _BillCode = BillCode;
            WhseType _Whse = Whse;
            InfobarType _Infobar = Infobar;
            CustNumType _CustNum = CustNum;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROMatlDCValidSp";

                appDB.AddCommandParameter(cmd, "Level", _Level, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PartnerID", _PartnerID, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SRONum", _SRONum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "SROLine", _SROLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SROOper", _SROOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "SroDesc", _SroDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "LineItem", _LineItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OperDesc", _OperDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "BillCode", _BillCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                SROLine = _SROLine;
                SROOper = _SROOper;
                SroDesc = _SroDesc;
                LineItem = _LineItem;
                OperDesc = _OperDesc;
                TransType = _TransType;
                BillCode = _BillCode;
                Whse = _Whse;
                Infobar = _Infobar;
                CustNum = _CustNum;

                return Severity;
            }
        }
    }
}
