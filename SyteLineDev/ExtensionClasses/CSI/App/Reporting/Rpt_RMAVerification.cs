//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RMAVerification.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_RMAVerification : IRpt_RMAVerification
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_RMAVerification(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_RMAVerificationSp(string PStartingRMA = null,
		string PEndingRMA = null,
		string PStatus = "OS",
		string PStartingCustomer = null,
		string PEndingCustomer = null,
		string PStartingWhse = null,
		string PEndingWhse = null,
		DateTime? PStartingRMADate = null,
		DateTime? PEndingRMADate = null,
		int? PStartingRMALine = null,
		int? PEndingRMALine = null,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? PrintItemOverview = 0,
		int? PrintRMATable = 1,
		int? PrintRMAItemTable = 1,
		int? PrintReasonText = 0,
		int? PStartingRMADateOffset = null,
		int? PEndingRMADateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			RmaNumType _PStartingRMA = PStartingRMA;
			RmaNumType _PEndingRMA = PEndingRMA;
			Infobar _PStatus = PStatus;
			CustNumType _PStartingCustomer = PStartingCustomer;
			CustNumType _PEndingCustomer = PEndingCustomer;
			WhseType _PStartingWhse = PStartingWhse;
			WhseType _PEndingWhse = PEndingWhse;
			DateType _PStartingRMADate = PStartingRMADate;
			DateType _PEndingRMADate = PEndingRMADate;
			RmaLineType _PStartingRMALine = PStartingRMALine;
			RmaLineType _PEndingRMALine = PEndingRMALine;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			ListYesNoType _PrintItemOverview = PrintItemOverview;
			ListYesNoType _PrintRMATable = PrintRMATable;
			ListYesNoType _PrintRMAItemTable = PrintRMAItemTable;
			ListYesNoType _PrintReasonText = PrintReasonText;
			DateOffsetType _PStartingRMADateOffset = PStartingRMADateOffset;
			DateOffsetType _PEndingRMADateOffset = PEndingRMADateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_RMAVerificationSp";
				
				appDB.AddCommandParameter(cmd, "PStartingRMA", _PStartingRMA, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingRMA", _PEndingRMA, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStatus", _PStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingCustomer", _PStartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingCustomer", _PEndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingWhse", _PStartingWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingWhse", _PEndingWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingRMADate", _PStartingRMADate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingRMADate", _PEndingRMADate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingRMALine", _PStartingRMALine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingRMALine", _PEndingRMALine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintItemOverview", _PrintItemOverview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRMATable", _PrintRMATable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRMAItemTable", _PrintRMAItemTable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintReasonText", _PrintReasonText, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingRMADateOffset", _PStartingRMADateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingRMADateOffset", _PEndingRMADateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
