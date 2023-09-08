//PROJECT NAME: CSIFinance
//CLASS NAME: FatranPostCreateTmp.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IFatranPostCreateTmp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) FatranPostCreateTmpSp(Guid? ProcessID,
		string AssetStarting = null,
		string AssetEnding = null,
		string AssetType = null,
		string StatusCode = null,
		string ClassCodeStarting = null,
		string ClassCodeEnding = null,
		string DepartmentStarting = null,
		string DepartmentEnding = null,
		string LocationStarting = null,
		string LocationEnding = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		short? TransDateStartingOffset = null,
		short? TransDateEndingOffset = null);
	}
	
	public class FatranPostCreateTmp : IFatranPostCreateTmp
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public FatranPostCreateTmp(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) FatranPostCreateTmpSp(Guid? ProcessID,
		string AssetStarting = null,
		string AssetEnding = null,
		string AssetType = null,
		string StatusCode = null,
		string ClassCodeStarting = null,
		string ClassCodeEnding = null,
		string DepartmentStarting = null,
		string DepartmentEnding = null,
		string LocationStarting = null,
		string LocationEnding = null,
		DateTime? TransDateStarting = null,
		DateTime? TransDateEnding = null,
		short? TransDateStartingOffset = null,
		short? TransDateEndingOffset = null)
		{
			RowPointerType _ProcessID = ProcessID;
			FaNumType _AssetStarting = AssetStarting;
			FaNumType _AssetEnding = AssetEnding;
			StringType _AssetType = AssetType;
			StringType _StatusCode = StatusCode;
			FaClassType _ClassCodeStarting = ClassCodeStarting;
			FaClassType _ClassCodeEnding = ClassCodeEnding;
			DeptType _DepartmentStarting = DepartmentStarting;
			DeptType _DepartmentEnding = DepartmentEnding;
			LocType _LocationStarting = LocationStarting;
			LocType _LocationEnding = LocationEnding;
			DateType _TransDateStarting = TransDateStarting;
			DateType _TransDateEnding = TransDateEnding;
			DateOffsetType _TransDateStartingOffset = TransDateStartingOffset;
			DateOffsetType _TransDateEndingOffset = TransDateEndingOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FatranPostCreateTmpSp";
				
				appDB.AddCommandParameter(cmd, "ProcessID", _ProcessID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetStarting", _AssetStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetEnding", _AssetEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AssetType", _AssetType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusCode", _StatusCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ClassCodeStarting", _ClassCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ClassCodeEnding", _ClassCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepartmentStarting", _DepartmentStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DepartmentEnding", _DepartmentEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationStarting", _LocationStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LocationEnding", _LocationEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStarting", _TransDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEnding", _TransDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateStartingOffset", _TransDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransDateEndingOffset", _TransDateEndingOffset, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
