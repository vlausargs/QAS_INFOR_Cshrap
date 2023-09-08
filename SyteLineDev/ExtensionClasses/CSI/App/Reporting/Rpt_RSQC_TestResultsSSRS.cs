//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_TestResultsSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_TestResultsSSRS : IRpt_RSQC_TestResultsSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_TestResultsSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_TestResultsSSRSSp(string begitem = null,
		string enditem = null,
		DateTime? begtdate = null,
		DateTime? endtdate = null,
		string beginsp = null,
		string endinsp = null,
		string begrefnum = null,
		string endrefnum = null,
		int? begrcvr = null,
		int? endrcvr = null,
		string testtype = null,
		string reftype = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		int? displayheader = null,
		int? firstarticle = null,
		string psite = null)
		{
			ItemType _begitem = begitem;
			ItemType _enditem = enditem;
			DateType _begtdate = begtdate;
			DateType _endtdate = endtdate;
			EmpNumType _beginsp = beginsp;
			EmpNumType _endinsp = endinsp;
			StringType _begrefnum = begrefnum;
			StringType _endrefnum = endrefnum;
			QCRcvrNumType _begrcvr = begrcvr;
			QCRcvrNumType _endrcvr = endrcvr;
			StringType _testtype = testtype;
			StringType _reftype = reftype;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			ListYesNoType _displayheader = displayheader;
			ListYesNoType _firstarticle = firstarticle;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_TestResultsSSRSSp";
				
				appDB.AddCommandParameter(cmd, "begitem", _begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enditem", _enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begtdate", _begtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endtdate", _endtdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beginsp", _beginsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endinsp", _endinsp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begrefnum", _begrefnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endrefnum", _endrefnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begrcvr", _begrcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endrcvr", _endrcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "testtype", _testtype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "reftype", _reftype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "displayheader", _displayheader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "firstarticle", _firstarticle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "psite", _psite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
