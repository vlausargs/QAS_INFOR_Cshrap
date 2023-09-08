//PROJECT NAME: Reporting
//CLASS NAME: Rpt_Exceptions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_Exceptions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ExceptionsSp(string StartPlannerCode = null,
		string EndPlannerCode = null,
		string StartItem = null,
		string EndItem = null,
		byte? ExceptionOnly = null,
		string DetailOrSummary = null,
		byte? PriorityLevel = null,
		byte? ShowZeroOS = null,
		byte? DisplayHeader = null,
		string PMessageLanguage = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_Exceptions : IRpt_Exceptions
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_Exceptions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ExceptionsSp(string StartPlannerCode = null,
		string EndPlannerCode = null,
		string StartItem = null,
		string EndItem = null,
		byte? ExceptionOnly = null,
		string DetailOrSummary = null,
		byte? PriorityLevel = null,
		byte? ShowZeroOS = null,
		byte? DisplayHeader = null,
		string PMessageLanguage = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null)
		{
			UserCodeType _StartPlannerCode = StartPlannerCode;
			UserCodeType _EndPlannerCode = EndPlannerCode;
			ItemType _StartItem = StartItem;
			ItemType _EndItem = EndItem;
			ListYesNoType _ExceptionOnly = ExceptionOnly;
			ListSingleAllType _DetailOrSummary = DetailOrSummary;
			MrpPriorityType _PriorityLevel = PriorityLevel;
			ListYesNoType _ShowZeroOS = ShowZeroOS;
			ListYesNoType _DisplayHeader = DisplayHeader;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ExceptionsSp";
				
				appDB.AddCommandParameter(cmd, "StartPlannerCode", _StartPlannerCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndPlannerCode", _EndPlannerCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExceptionOnly", _ExceptionOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DetailOrSummary", _DetailOrSummary, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriorityLevel", _PriorityLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowZeroOS", _ShowZeroOS, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
