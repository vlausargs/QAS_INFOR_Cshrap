//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LaborAnalysisbyWorkCenter.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_LaborAnalysisbyWorkCenter : IRpt_LaborAnalysisbyWorkCenter
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_LaborAnalysisbyWorkCenter(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_LaborAnalysisbyWorkCenterSp(string StartWc = null,
		string EWc = null,
		string StartProductCode = null,
		string EProductCode = null,
		string StartItem = null,
		string EItem = null,
		DateTime? STransDate = null,
		DateTime? ETransDate = null,
		int? STransDateOffSET = null,
		int? ETransDateOffSET = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			WcType _StartWc = StartWc;
			WcType _EWc = EWc;
			ProductCodeType _StartProductCode = StartProductCode;
			ProductCodeType _EProductCode = EProductCode;
			ItemType _StartItem = StartItem;
			ItemType _EItem = EItem;
			DateType _STransDate = STransDate;
			DateType _ETransDate = ETransDate;
			DateOffsetType _STransDateOffSET = STransDateOffSET;
			DateOffsetType _ETransDateOffSET = ETransDateOffSET;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_LaborAnalysisbyWorkCenterSp";
				
				appDB.AddCommandParameter(cmd, "StartWc", _StartWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EWc", _EWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartProductCode", _StartProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EProductCode", _EProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EItem", _EItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STransDate", _STransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETransDate", _ETransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "STransDateOffSET", _STransDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ETransDateOffSET", _ETransDateOffSET, ParameterDirection.Input);
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
