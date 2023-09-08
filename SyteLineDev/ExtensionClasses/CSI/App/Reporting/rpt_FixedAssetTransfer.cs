//PROJECT NAME: Reporting
//CLASS NAME: rpt_FixedAssetTransfer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface Irpt_FixedAssetTransfer
	{
		(ICollectionLoadResponse Data, int? ReturnCode) rpt_FixedAssetTransfersp(string AssetType = null,
		string StatusCode = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		short? TransDateStartingOffset = null,
		short? TransDateEndingOffset = null,
		string AssetStarting = null,
		string AssetEnding = null,
		string ClassCodeStarting = null,
		string ClassCodeEnding = null,
		string DepartmentStarting = null,
		string DepartmentEnding = null,
		string LocationStarting = null,
		string LocationEnding = null,
		byte? DisplayHeader = null,
		Guid? ProcessID = null,
		string BGSessionId = null,
		string pSite = null);
	}
	
	public class rpt_FixedAssetTransfer : Irpt_FixedAssetTransfer
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public rpt_FixedAssetTransfer(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) rpt_FixedAssetTransfersp(string AssetType = null,
		string StatusCode = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		short? TransDateStartingOffset = null,
		short? TransDateEndingOffset = null,
		string AssetStarting = null,
		string AssetEnding = null,
		string ClassCodeStarting = null,
		string ClassCodeEnding = null,
		string DepartmentStarting = null,
		string DepartmentEnding = null,
		string LocationStarting = null,
		string LocationEnding = null,
		byte? DisplayHeader = null,
		Guid? ProcessID = null,
		string BGSessionId = null,
		string pSite = null)
		{
			StringType _AssetType = AssetType;
			StringType _StatusCode = StatusCode;
			DateType _TransDateStarting = TransDateStarting;
			DateType _TransDateEnding = TransDateEnding;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			FaNumType _AssetStarting = AssetStarting;
			FaNumType _AssetEnding = AssetEnding;
			FaClassType _ClassCodeStarting = ClassCodeStarting;
			FaClassType _ClassCodeEnding = ClassCodeEnding;
			DeptType _DepartmentStarting = DepartmentStarting;
			DeptType _DepartmentEnding = DepartmentEnding;
			LocType _LocationStarting = LocationStarting;
			LocType _LocationEnding = LocationEnding;
			ListYesNoType _DisplayHeader = DisplayHeader;
			RowPointerType _ProcessID = ProcessID;
			StringType _BGSessionId = BGSessionId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "rpt_FixedAssetTransfersp";
				
				appDB.AddCommandParameter(cmd, "AssetType", _AssetType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusCode", _StatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetStarting", _AssetStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetEnding", _AssetEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ClassCodeStarting", _ClassCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ClassCodeEnding", _ClassCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepartmentStarting", _DepartmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepartmentEnding", _DepartmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationStarting", _LocationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationEnding", _LocationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
