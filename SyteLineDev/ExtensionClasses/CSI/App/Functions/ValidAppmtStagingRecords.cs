//PROJECT NAME: Data
//CLASS NAME: ValidAppmtStagingRecords.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class ValidAppmtStagingRecords : IValidAppmtStagingRecords
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public ValidAppmtStagingRecords(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse ValidAppmtStagingRecordsFn(
			Guid? PProcessId,
			string PStartingVendNum,
			string PEndingVendNum,
			string PStartingVendName,
			string PEndingVendName,
			string PSortNameNum)
		{
			GuidType _PProcessId = PProcessId;
			VendNumType _PStartingVendNum = PStartingVendNum;
			VendNumType _PEndingVendNum = PEndingVendNum;
			NameType _PStartingVendName = PStartingVendName;
			NameType _PEndingVendName = PEndingVendName;
			LongDescType _PSortNameNum = PSortNameNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[ValidAppmtStagingRecords](@PProcessId, @PStartingVendNum, @PEndingVendNum, @PStartingVendName, @PEndingVendName, @PSortNameNum)";
				
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendNum", _PStartingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendNum", _PEndingVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingVendName", _PStartingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingVendName", _PEndingVendName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSortNameNum", _PSortNameNum, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_ValidAppmtStagingRecords";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
