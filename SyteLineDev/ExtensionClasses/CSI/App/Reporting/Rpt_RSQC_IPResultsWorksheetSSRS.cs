//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_IPResultsWorksheetSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_IPResultsWorksheetSSRS : IRpt_RSQC_IPResultsWorksheetSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_IPResultsWorksheetSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPResultsWorksheetSSRSSp(string begitem = null,
		string enditem = null,
		int? begopernum = null,
		int? endopernum = null,
		int? printworksheet = null,
		int? numentries = null,
		int? pagepertest = null,
		int? displayheader = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null)
		{
			ItemType _begitem = begitem;
			ItemType _enditem = enditem;
			OperNumType _begopernum = begopernum;
			OperNumType _endopernum = endopernum;
			ListYesNoType _printworksheet = printworksheet;
			IntType _numentries = numentries;
			ListYesNoType _pagepertest = pagepertest;
			ListYesNoType _displayheader = displayheader;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_IPResultsWorksheetSSRSSp";
				
				appDB.AddCommandParameter(cmd, "begitem", _begitem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "enditem", _enditem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "begopernum", _begopernum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "endopernum", _endopernum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "printworksheet", _printworksheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "numentries", _numentries, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pagepertest", _pagepertest, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "displayheader", _displayheader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
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
