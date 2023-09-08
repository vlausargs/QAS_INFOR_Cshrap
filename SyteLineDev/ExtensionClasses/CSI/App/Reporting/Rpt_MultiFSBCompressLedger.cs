//PROJECT NAME: Reporting
//CLASS NAME: Rpt_MultiFSBCompressLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_MultiFSBCompressLedger : IRpt_MultiFSBCompressLedger
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_MultiFSBCompressLedger(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_MultiFSBCompressLedgerSp(string ProcessId,
		DateTime? PerStart,
		DateTime? PerEnd,
		string AcctStart,
		string AcctEnd,
		string FSBNameStart,
		string FSBNameEnd,
		string pSite = null)
		{
			StringType _ProcessId = ProcessId;
			DateType _PerStart = PerStart;
			DateType _PerEnd = PerEnd;
			AcctType _AcctStart = AcctStart;
			AcctType _AcctEnd = AcctEnd;
			FSBNameType _FSBNameStart = FSBNameStart;
			FSBNameType _FSBNameEnd = FSBNameEnd;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_MultiFSBCompressLedgerSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctStart", _AcctStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctEnd", _AcctEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBNameStart", _FSBNameStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FSBNameEnd", _FSBNameEnd, ParameterDirection.Input);
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
