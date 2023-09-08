//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IncompleteSSDOrderInformation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_IncompleteSSDOrderInformation : IRpt_IncompleteSSDOrderInformation
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_IncompleteSSDOrderInformation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_IncompleteSSDOrderInformationSp(DateTime? PStartingPeriod = null,
		DateTime? PEndingPeriod = null,
		int? PStartingPeriodOffset = null,
		int? PEndingPeriodOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			DateType _PStartingPeriod = PStartingPeriod;
			DateType _PEndingPeriod = PEndingPeriod;
			DateOffsetType _PStartingPeriodOffset = PStartingPeriodOffset;
			DateOffsetType _PEndingPeriodOffset = PEndingPeriodOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_IncompleteSSDOrderInformationSp";
				
				appDB.AddCommandParameter(cmd, "PStartingPeriod", _PStartingPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingPeriod", _PEndingPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingPeriodOffset", _PStartingPeriodOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingPeriodOffset", _PEndingPeriodOffset, ParameterDirection.Input);
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
