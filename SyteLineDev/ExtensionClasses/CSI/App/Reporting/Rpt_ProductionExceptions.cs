//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionExceptions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProductionExceptions : IRpt_ProductionExceptions
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProductionExceptions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProductionExceptionsSp(string ScheduleType = null,
		string SJob = null,
		string EJob = null,
		int? SSuffix = null,
		int? ESuffix = null,
		string SItem = null,
		string EItem = null,
		decimal? SDaysLate = null,
		decimal? EDaysLate = null,
		int? ShowDetail = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			InfobarType _ScheduleType = ScheduleType;
			JobType _SJob = SJob;
			JobType _EJob = EJob;
			SuffixType _SSuffix = SSuffix;
			SuffixType _ESuffix = ESuffix;
			ItemType _SItem = SItem;
			ItemType _EItem = EItem;
			ApsFloatType _SDaysLate = SDaysLate;
			ApsFloatType _EDaysLate = EDaysLate;
			ListYesNoType _ShowDetail = ShowDetail;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProductionExceptionsSp";
				
				appDB.AddCommandParameter(cmd, "ScheduleType", _ScheduleType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SJob", _SJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EJob", _EJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SSuffix", _SSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ESuffix", _ESuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SItem", _SItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EItem", _EItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SDaysLate", _SDaysLate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EDaysLate", _EDaysLate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
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
