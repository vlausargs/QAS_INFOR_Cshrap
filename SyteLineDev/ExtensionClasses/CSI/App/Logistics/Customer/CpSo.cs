//PROJECT NAME: Logistics
//CLASS NAME: CpSo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICpSo
    {
        (int? ReturnCode, string Infobar) CpSoSp(string CopyFromCoType,
                                                 string CopyToCoType,
                                                 string CopyFromCoNum,
                                                 string CopyToCoNum,
                                                 short? pCpOrdStart,
                                                 short? pCpOrdEnd,
                                                 string pCopyChoice,
                                                 byte? HasCfg,
                                                 string CurWhse,
                                                 byte? pRecalcDueDate,
                                                 string Infobar,
                                                 byte? CalledFromEcomm = (byte)0);
    }

    public class CpSo : ICpSo
    {
        readonly IApplicationDB appDB;

        public CpSo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public (int? ReturnCode, string Infobar) CpSoSp(string CopyFromCoType,
                                                        string CopyToCoType,
                                                        string CopyFromCoNum,
                                                        string CopyToCoNum,
                                                        short? pCpOrdStart,
                                                        short? pCpOrdEnd,
                                                        string pCopyChoice,
                                                        byte? HasCfg,
                                                        string CurWhse,
                                                        byte? pRecalcDueDate,
                                                        string Infobar,
                                                        byte? CalledFromEcomm = (byte)0)
        {
            CoTypeType _CopyFromCoType = CopyFromCoType;
            CoTypeType _CopyToCoType = CopyToCoType;
            CoNumType _CopyFromCoNum = CopyFromCoNum;
            CoNumType _CopyToCoNum = CopyToCoNum;
            CoLineType _pCpOrdStart = pCpOrdStart;
            CoLineType _pCpOrdEnd = pCpOrdEnd;
            StringType _pCopyChoice = pCopyChoice;
            ListYesNoType _HasCfg = HasCfg;
            WhseType _CurWhse = CurWhse;
            ListYesNoType _pRecalcDueDate = pRecalcDueDate;
            InfobarType _Infobar = Infobar;
            ListYesNoType _CalledFromEcomm = CalledFromEcomm;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CpSoSp";

                appDB.AddCommandParameter(cmd, "CopyFromCoType", _CopyFromCoType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CopyToCoType", _CopyToCoType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CopyFromCoNum", _CopyFromCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CopyToCoNum", _CopyToCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCpOrdStart", _pCpOrdStart, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCpOrdEnd", _pCpOrdEnd, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pCopyChoice", _pCopyChoice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "HasCfg", _HasCfg, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pRecalcDueDate", _pRecalcDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CalledFromEcomm", _CalledFromEcomm, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Infobar = _Infobar;

                return (Severity, Infobar);
            }
        }
    }
}
