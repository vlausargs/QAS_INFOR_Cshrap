//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FixedAssetQuarterlyCostIncurred.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_FixedAssetQuarterlyCostIncurred
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetQuarterlyCostIncurredSp(int? ReportYear = null,
		string AssetTypes = "R",
		string StatusCodes = "A",
		string StartAssetNum = null,
		string EndAssetNum = null,
		string StartClassCode = null,
		string EndClassCode = null,
		string StartDept = null,
		string EndDept = null,
		byte? DisplayHeader = null,
		string pSite = null);
	}
	
	public class Rpt_FixedAssetQuarterlyCostIncurred : IRpt_FixedAssetQuarterlyCostIncurred
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FixedAssetQuarterlyCostIncurred(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FixedAssetQuarterlyCostIncurredSp(int? ReportYear = null,
		string AssetTypes = "R",
		string StatusCodes = "A",
		string StartAssetNum = null,
		string EndAssetNum = null,
		string StartClassCode = null,
		string EndClassCode = null,
		string StartDept = null,
		string EndDept = null,
		byte? DisplayHeader = null,
		string pSite = null)
		{
			IntType _ReportYear = ReportYear;
			Infobar _AssetTypes = AssetTypes;
			Infobar _StatusCodes = StatusCodes;
			FaNumType _StartAssetNum = StartAssetNum;
			FaNumType _EndAssetNum = EndAssetNum;
			FaClassType _StartClassCode = StartClassCode;
			FaClassType _EndClassCode = EndClassCode;
			DeptType _StartDept = StartDept;
			DeptType _EndDept = EndDept;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FixedAssetQuarterlyCostIncurredSp";
				
				appDB.AddCommandParameter(cmd, "ReportYear", _ReportYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetTypes", _AssetTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusCodes", _StatusCodes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartAssetNum", _StartAssetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndAssetNum", _EndAssetNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartClassCode", _StartClassCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndClassCode", _EndClassCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartDept", _StartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDept", _EndDept, ParameterDirection.Input);
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
