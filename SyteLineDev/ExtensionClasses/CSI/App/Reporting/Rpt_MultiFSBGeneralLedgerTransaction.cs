//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBGeneralLedgerTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
    public class Rpt_MultiFSBGeneralLedgerTransaction : IRpt_MultiFSBGeneralLedgerTransaction
    {
        IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public Rpt_MultiFSBGeneralLedgerTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBGeneralLedgerTransactionSp(decimal? ExOptStartingTrans = null,
        decimal? ExOptEndingTrans = null,
        string ExOptStartingRef = null,
        string ExOptEndingRef = null,
        int? TAnalyticalLedger = null,
        DateTime? ExOptStartingTransDate = null,
        DateTime? ExOptEndingTransDate = null,
        string ExOptStartingAcc = null,
        string ExOptEndingAcc = null,
        string ExOptacChartType = null,
        string ExOptBegAcctUnit1 = null,
        string ExOptEndAcctUnit1 = null,
        string ExOptBegAcctUnit2 = null,
        string ExOptEndAcctUnit2 = null,
        string ExOptBegAcctUnit3 = null,
        string ExOptEndAcctUnit3 = null,
        string ExOptBegAcctUnit4 = null,
        string ExOptEndAcctUnit4 = null,
        string ExOptSortBy = null,
        int? StartingTransDateOffset = null,
        int? EndingTransDateOffset = null,
        int? DisplayHeader = null,
        int? ShowInternal = null,
        int? ShowExternal = null,
        string FSBName = null,
        string pSite = null)
        {
            MatlTransNumType _ExOptStartingTrans = ExOptStartingTrans;
            MatlTransNumType _ExOptEndingTrans = ExOptEndingTrans;
            ReferenceType _ExOptStartingRef = ExOptStartingRef;
            ReferenceType _ExOptEndingRef = ExOptEndingRef;
            ListYesNoType _TAnalyticalLedger = TAnalyticalLedger;
            DateType _ExOptStartingTransDate = ExOptStartingTransDate;
            DateType _ExOptEndingTransDate = ExOptEndingTransDate;
            AcctType _ExOptStartingAcc = ExOptStartingAcc;
            AcctType _ExOptEndingAcc = ExOptEndingAcc;
            InfobarType _ExOptacChartType = ExOptacChartType;
            UnitCode1Type _ExOptBegAcctUnit1 = ExOptBegAcctUnit1;
            UnitCode1Type _ExOptEndAcctUnit1 = ExOptEndAcctUnit1;
            UnitCode1Type _ExOptBegAcctUnit2 = ExOptBegAcctUnit2;
            UnitCode1Type _ExOptEndAcctUnit2 = ExOptEndAcctUnit2;
            UnitCode1Type _ExOptBegAcctUnit3 = ExOptBegAcctUnit3;
            UnitCode1Type _ExOptEndAcctUnit3 = ExOptEndAcctUnit3;
            UnitCode1Type _ExOptBegAcctUnit4 = ExOptBegAcctUnit4;
            UnitCode1Type _ExOptEndAcctUnit4 = ExOptEndAcctUnit4;
            StringType _ExOptSortBy = ExOptSortBy;
            DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
            DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
            ListYesNoType _DisplayHeader = DisplayHeader;
            FlagNyType _ShowInternal = ShowInternal;
            FlagNyType _ShowExternal = ShowExternal;
            FSBNameType _FSBName = FSBName;
            SiteType _pSite = pSite;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Rpt_MultiFSBGeneralLedgerTransactionSp";

                appDB.AddCommandParameter(cmd, "ExOptStartingTrans", _ExOptStartingTrans, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingTrans", _ExOptEndingTrans, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptStartingRef", _ExOptStartingRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingRef", _ExOptEndingRef, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TAnalyticalLedger", _TAnalyticalLedger, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptStartingTransDate", _ExOptStartingTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingTransDate", _ExOptEndingTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptStartingAcc", _ExOptStartingAcc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndingAcc", _ExOptEndingAcc, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptacChartType", _ExOptacChartType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit1", _ExOptBegAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit1", _ExOptEndAcctUnit1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit2", _ExOptBegAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit2", _ExOptEndAcctUnit2, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit3", _ExOptBegAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit3", _ExOptEndAcctUnit3, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptBegAcctUnit4", _ExOptBegAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptEndAcctUnit4", _ExOptEndAcctUnit4, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ExOptSortBy", _ExOptSortBy, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}