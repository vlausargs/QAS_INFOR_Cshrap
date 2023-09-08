//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContactLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContactLoad : ISSSFSContactLoad
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;

		public SSSFSContactLoad(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}

		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSContactLoadSp(string CustNum,
		int? CustSeq,
		string UsrNum,
		int? UsrSeq,
		string ContactName)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			NameType _ContactName = ContactName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContactLoadSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactName", _ContactName, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}

		public ICollectionLoadResponse SSSFSContactLoadFn(
			string CustNum,
			int? CustSeq,
			string UsrNum,
			int? UsrSeq,
			string ContactName)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			FSUsrNumType _UsrNum = UsrNum;
			FSUsrSeqType _UsrSeq = UsrSeq;
			NameType _ContactName = ContactName;

			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[SSSFSContactLoad](@CustNum, @CustSeq, @UsrNum, @UsrSeq, @ContactName)";

				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrNum", _UsrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UsrSeq", _UsrSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContactName", _ContactName, ParameterDirection.Input);

				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_SSSFSContactLoad";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);

				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
