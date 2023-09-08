//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RSQC_CustFinalInspectionWorksheetSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RSQC_CustFinalInspectionWorksheetSSRS : IRpt_RSQC_CustFinalInspectionWorksheetSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RSQC_CustFinalInspectionWorksheetSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CustFinalInspectionWorksheetSSRSSp(string BegCust = null,
		string EndCust = null,
		string BegItem = null,
		string EndItem = null,
		int? NumEntries = null,
		int? PrintWorksheet = null,
		int? DisplayHeader = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null)
		{
			CustNumType _BegCust = BegCust;
			CustNumType _EndCust = EndCust;
			ItemType _BegItem = BegItem;
			ItemType _EndItem = EndItem;
			IntType _NumEntries = NumEntries;
			ListYesNoType _PrintWorksheet = PrintWorksheet;
			ListYesNoType _DisplayHeader = DisplayHeader;
			FlagNyType _PrintInternal = PrintInternal;
			FlagNyType _PrintExternal = PrintExternal;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RSQC_CustFinalInspectionWorksheetSSRSSp";
				
				appDB.AddCommandParameter(cmd, "BegCust", _BegCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndCust", _EndCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegItem", _BegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NumEntries", _NumEntries, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintWorksheet", _PrintWorksheet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
