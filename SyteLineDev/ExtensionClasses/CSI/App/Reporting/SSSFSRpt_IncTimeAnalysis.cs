//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_IncTimeAnalysis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_IncTimeAnalysis : ISSSFSRpt_IncTimeAnalysis
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_IncTimeAnalysis(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_IncTimeAnalysisSp(DateTime? StartingCloseDate,
		DateTime? EndingCloseDate,
		string StartingIncident,
		string EndingIncident,
		string StartingCustomer,
		string EndingCustomer,
		string StartingOwner,
		string EndingOwner,
		string StartingReasonCode1,
		string EndingReasonCode1,
		string StartingReasonCode2,
		string EndingReasonCode2,
		string StartingUnit,
		string EndingUnit,
		string StartingItem,
		string EndingItem,
		int? PrintIncident,
		int? PrintReasRes,
		int? PrintReason,
		int? PrintRes,
		int? PrintEvents,
		int? PrintInternal,
		int? PrintExternal,
		string pSite = null)
		{
			DateType _StartingCloseDate = StartingCloseDate;
			DateType _EndingCloseDate = EndingCloseDate;
			FSIncNumType _StartingIncident = StartingIncident;
			FSIncNumType _EndingIncident = EndingIncident;
			CustNumType _StartingCustomer = StartingCustomer;
			CustNumType _EndingCustomer = EndingCustomer;
			FSPartnerType _StartingOwner = StartingOwner;
			FSPartnerType _EndingOwner = EndingOwner;
			FSReasonType _StartingReasonCode1 = StartingReasonCode1;
			FSReasonType _EndingReasonCode1 = EndingReasonCode1;
			FSReasonType _StartingReasonCode2 = StartingReasonCode2;
			FSReasonType _EndingReasonCode2 = EndingReasonCode2;
			SerNumType _StartingUnit = StartingUnit;
			SerNumType _EndingUnit = EndingUnit;
			ItemType _StartingItem = StartingItem;
			ItemType _EndingItem = EndingItem;
			ListYesNoType _PrintIncident = PrintIncident;
			ListYesNoType _PrintReasRes = PrintReasRes;
			ListYesNoType _PrintReason = PrintReason;
			ListYesNoType _PrintRes = PrintRes;
			ListYesNoType _PrintEvents = PrintEvents;
			ListYesNoType _PrintInternal = PrintInternal;
			ListYesNoType _PrintExternal = PrintExternal;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_IncTimeAnalysisSp";
				
				appDB.AddCommandParameter(cmd, "StartingCloseDate", _StartingCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCloseDate", _EndingCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingIncident", _StartingIncident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingIncident", _EndingIncident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCustomer", _StartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustomer", _EndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOwner", _StartingOwner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOwner", _EndingOwner, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingReasonCode1", _StartingReasonCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingReasonCode1", _EndingReasonCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingReasonCode2", _StartingReasonCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingReasonCode2", _EndingReasonCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingUnit", _StartingUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingUnit", _EndingUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintIncident", _PrintIncident, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintReasRes", _PrintReasRes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintReason", _PrintReason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintRes", _PrintRes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintEvents", _PrintEvents, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintInternal", _PrintInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintExternal", _PrintExternal, ParameterDirection.Input);
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
