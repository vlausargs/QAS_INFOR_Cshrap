//PROJECT NAME: Employee
//CLASS NAME: GenerateExportEmpMasterData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class GenerateExportEmpMasterData : IGenerateExportEmpMasterData
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public GenerateExportEmpMasterData(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) GenerateExportEmpMasterDataSp(string StartingDept = null,
		string EndingDept = null,
		string StartingEmpNum = null,
		string EndingEmpNum = null,
		int? IsExportChangedOnly = 0,
		int? UseEffectiveDateOverride = 0,
		DateTime? EffectiveDateOverride = null,
		int? EffectiveDateOverrideOffSet = null,
		int? UseEndDateOverride = 0,
		DateTime? EndDateOverride = null,
		int? EndDateOverrideOffSet = null,
		decimal? UserId = null)
		{
			DeptType _StartingDept = StartingDept;
			DeptType _EndingDept = EndingDept;
			EmpNumType _StartingEmpNum = StartingEmpNum;
			EmpNumType _EndingEmpNum = EndingEmpNum;
			ListYesNoType _IsExportChangedOnly = IsExportChangedOnly;
			ListYesNoType _UseEffectiveDateOverride = UseEffectiveDateOverride;
			DateType _EffectiveDateOverride = EffectiveDateOverride;
			DateOffsetType _EffectiveDateOverrideOffSet = EffectiveDateOverrideOffSet;
			ListYesNoType _UseEndDateOverride = UseEndDateOverride;
			DateType _EndDateOverride = EndDateOverride;
			DateOffsetType _EndDateOverrideOffSet = EndDateOverrideOffSet;
			TokenType _UserId = UserId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateExportEmpMasterDataSp";
				
				appDB.AddCommandParameter(cmd, "StartingDept", _StartingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDept", _EndingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingEmpNum", _StartingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingEmpNum", _EndingEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsExportChangedOnly", _IsExportChangedOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseEffectiveDateOverride", _UseEffectiveDateOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDateOverride", _EffectiveDateOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDateOverrideOffSet", _EffectiveDateOverrideOffSet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseEndDateOverride", _UseEndDateOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOverride", _EndDateOverride, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndDateOverrideOffSet", _EndDateOverrideOffSet, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
