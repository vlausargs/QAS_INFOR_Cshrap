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
    public interface ICLM_CpSo
    {
        (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CpSoSp(string CopyFromCoType,
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

    public class CLM_CpSo : ICLM_CpSo
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public CLM_CpSo(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CpSoSp(string CopyFromCoType,
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
            bunchedLoadCollection.StartBunching();

            try
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
                    DataTable dtReturn = new DataTable();

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

                    IntType returnVal = 0;
                    IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                    dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    Infobar = _Infobar;

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
                }
            }
            finally
            {
                bunchedLoadCollection.EndBunching();
            }
        }
    }
}
