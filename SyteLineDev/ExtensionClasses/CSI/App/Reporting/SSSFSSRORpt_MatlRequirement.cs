//PROJECT NAME: Reporting
//CLASS NAME: SSSFSSRORpt_MatlRequirement.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSSRORpt_MatlRequirement : ISSSFSSRORpt_MatlRequirement
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSSRORpt_MatlRequirement(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode, string Infobar) SSSFSSRORpt_MatlRequirementSP(string PSRONumberStarting = null,
		string PSRONumberEnding = null,
		int? PSROLineNumberStarting = null,
		int? PSROLineNumberEnding = null,
		int? PSROOperNumberStarting = null,
		int? PSROOperNumberEnding = null,
		string PItemStarting = null,
		string PItemEnding = null,
		int? PIncludePostedPlanned = 0,
		string Infobar = null,
		int? PIncludeSRODemand = 1,
		string PCustNumStarting = null,
		string PCustNumEnding = null,
		string PProdCodeStarting = null,
		string PProdCodeEnding = null,
		DateTime? PSROLineDueDateStarting = null,
		DateTime? PSROLineDueDateEnding = null,
		int? PShowShortages = 0,
		string PSortby = "SRO",
		string pSite = null)
		{
			FSSRONumType _PSRONumberStarting = PSRONumberStarting;
			FSSRONumType _PSRONumberEnding = PSRONumberEnding;
			FSSROLineType _PSROLineNumberStarting = PSROLineNumberStarting;
			FSSROLineType _PSROLineNumberEnding = PSROLineNumberEnding;
			FSSROOperType _PSROOperNumberStarting = PSROOperNumberStarting;
			FSSROOperType _PSROOperNumberEnding = PSROOperNumberEnding;
			ItemType _PItemStarting = PItemStarting;
			ItemType _PItemEnding = PItemEnding;
			ListYesNoType _PIncludePostedPlanned = PIncludePostedPlanned;
			Infobar _Infobar = Infobar;
			ListYesNoType _PIncludeSRODemand = PIncludeSRODemand;
			CustNumType _PCustNumStarting = PCustNumStarting;
			CustNumType _PCustNumEnding = PCustNumEnding;
			ProductCodeType _PProdCodeStarting = PProdCodeStarting;
			ProductCodeType _PProdCodeEnding = PProdCodeEnding;
			DateType _PSROLineDueDateStarting = PSROLineDueDateStarting;
			DateType _PSROLineDueDateEnding = PSROLineDueDateEnding;
			ListYesNoType _PShowShortages = PShowShortages;
			StringType _PSortby = PSortby;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSRORpt_MatlRequirementSP";
				
				appDB.AddCommandParameter(cmd, "PSRONumberStarting", _PSRONumberStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSRONumberEnding", _PSRONumberEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROLineNumberStarting", _PSROLineNumberStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROLineNumberEnding", _PSROLineNumberEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROOperNumberStarting", _PSROOperNumberStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROOperNumberEnding", _PSROOperNumberEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemStarting", _PItemStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItemEnding", _PItemEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIncludePostedPlanned", _PIncludePostedPlanned, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PIncludeSRODemand", _PIncludeSRODemand, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNumStarting", _PCustNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNumEnding", _PCustNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProdCodeStarting", _PProdCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProdCodeEnding", _PProdCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROLineDueDateStarting", _PSROLineDueDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSROLineDueDateEnding", _PSROLineDueDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PShowShortages", _PShowShortages, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortby", _PSortby, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				Infobar = _Infobar;
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value, Infobar);
			}
		}
	}
}
