//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PastDueJobOperations.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PastDueJobOperations : IRpt_PastDueJobOperations
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PastDueJobOperations(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PastDueJobOperationsSp(string JobStarting = null,
		string JobEnding = null,
		int? JobSuffixStarting = null,
		int? JobSuffixEnding = null,
		string ItemStarting = null,
		string ItemEnding = null,
		string CustomerStarting = null,
		string CustomerEnding = null,
		string Ord_type = null,
		string RefStarting = null,
		string RefEnding = null,
		DateTime? LastTrxDateStarting = null,
		DateTime? LastTrxDateEnding = null,
		int? LastTrxDateStartingOffset = null,
		int? LastTrxDateEndingOffset = null,
		DateTime? JobDateStarting = null,
		DateTime? JobDateEnding = null,
		int? JobDateStartingOffset = null,
		int? JobDateEndingOffset = null,
		DateTime? PastDueDate = null,
		int? PastDueOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			JobType _JobStarting = JobStarting;
			JobType _JobEnding = JobEnding;
			SuffixType _JobSuffixStarting = JobSuffixStarting;
			SuffixType _JobSuffixEnding = JobSuffixEnding;
			ItemType _ItemStarting = ItemStarting;
			ItemType _ItemEnding = ItemEnding;
			CustNumType _CustomerStarting = CustomerStarting;
			CustNumType _CustomerEnding = CustomerEnding;
			RefTypeIKOTType _Ord_type = Ord_type;
			CoProjTrnNumType _RefStarting = RefStarting;
			CoProjTrnNumType _RefEnding = RefEnding;
			DateType _LastTrxDateStarting = LastTrxDateStarting;
			DateType _LastTrxDateEnding = LastTrxDateEnding;
			DateOffsetType _LastTrxDateStartingOffset = LastTrxDateStartingOffset;
			DateOffsetType _LastTrxDateEndingOffset = LastTrxDateEndingOffset;
			DateType _JobDateStarting = JobDateStarting;
			DateType _JobDateEnding = JobDateEnding;
			DateOffsetType _JobDateStartingOffset = JobDateStartingOffset;
			DateOffsetType _JobDateEndingOffset = JobDateEndingOffset;
			DateType _PastDueDate = PastDueDate;
			DateOffsetType _PastDueOffset = PastDueOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PastDueJobOperationsSp";
				
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffixStarting", _JobSuffixStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobSuffixEnding", _JobSuffixEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemStarting", _ItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemEnding", _ItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerStarting", _CustomerStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustomerEnding", _CustomerEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Ord_type", _Ord_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefStarting", _RefStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefEnding", _RefEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateStarting", _LastTrxDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateEnding", _LastTrxDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateStartingOffset", _LastTrxDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LastTrxDateEndingOffset", _LastTrxDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStarting", _JobDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEnding", _JobDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateStartingOffset", _JobDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobDateEndingOffset", _JobDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PastDueDate", _PastDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PastDueOffset", _PastDueOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
