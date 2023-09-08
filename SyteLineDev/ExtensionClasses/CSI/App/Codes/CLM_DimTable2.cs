//PROJECT NAME: Codes
//CLASS NAME: CLM_DimTable2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CLM_DimTable2 : ICLM_DimTable2
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_DimTable2(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_DimTable2Sp(
			Guid? TableRowPointer,
			string ObjectName,
			string Dimension)
		{
			RowPointerType _TableRowPointer = TableRowPointer;
			DimensionObjectType _ObjectName = ObjectName;
			DimensionNameType _Dimension = Dimension;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_DimTable2Sp";
				
				appDB.AddCommandParameter(cmd, "TableRowPointer", _TableRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Dimension", _Dimension, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
