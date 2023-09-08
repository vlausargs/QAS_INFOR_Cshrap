//PROJECT NAME: Reporting
//CLASS NAME: RPT_RSQC_GageReport.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_RSQC_GageReport : IRPT_RSQC_GageReport
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RPT_RSQC_GageReport(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RPT_RSQC_GageReportSp(
			string BegGage = null,
			string EndGage = null,
			string BegStat = null,
			string EndStat = null,
			string BegGageType = null,
			string EndGageType = null,
			int? DisplayHistory = null,
			int? DisplayHeader = null)
		{
			QCCharType _BegGage = BegGage;
			QCCharType _EndGage = EndGage;
			QCCodeType _BegStat = BegStat;
			QCCodeType _EndStat = EndStat;
			QCCharType _BegGageType = BegGageType;
			QCCharType _EndGageType = EndGageType;
			ListYesNoType _DisplayHistory = DisplayHistory;
			ListYesNoType _DisplayHeader = DisplayHeader;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_RSQC_GageReportSp";
				
				appDB.AddCommandParameter(cmd, "BegGage", _BegGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGage", _EndGage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegStat", _BegStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndStat", _EndStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BegGageType", _BegGageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndGageType", _EndGageType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHistory", _DisplayHistory, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
