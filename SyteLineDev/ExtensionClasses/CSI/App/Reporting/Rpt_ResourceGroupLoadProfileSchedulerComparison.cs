//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupLoadProfileSchedulerComparison.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupLoadProfileSchedulerComparison : IRpt_ResourceGroupLoadProfileSchedulerComparison
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ResourceGroupLoadProfileSchedulerComparison(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupLoadProfileSchedulerComparisonSp(string RGIDStarting,
		string RGIDEnding,
		DateTime? StartDate = null,
		int? IntervalCount = 12,
		int? IntervalType = 3,
		int? AltNum = 0,
		int? AltNum2 = 0,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ApsResgroupType _RGIDStarting = RGIDStarting;
			ApsResgroupType _RGIDEnding = RGIDEnding;
			DateTimeType _StartDate = StartDate;
			ShortType _IntervalCount = IntervalCount;
			ShortType _IntervalType = IntervalType;
			ApsAltNoType _AltNum = AltNum;
			ApsAltNoType _AltNum2 = AltNum2;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ResourceGroupLoadProfileSchedulerComparisonSp";
				
				appDB.AddCommandParameter(cmd, "RGIDStarting", _RGIDStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RGIDEnding", _RGIDEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDate", _StartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IntervalCount", _IntervalCount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IntervalType", _IntervalType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNum", _AltNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltNum2", _AltNum2, ParameterDirection.Input);
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
