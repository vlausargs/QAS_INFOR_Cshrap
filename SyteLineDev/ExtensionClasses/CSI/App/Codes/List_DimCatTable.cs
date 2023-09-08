//PROJECT NAME: Codes
//CLASS NAME: List_DimCatTable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class List_DimCatTable : IList_DimCatTable
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public List_DimCatTable(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) List_DimCatTableSp(Guid? TableRowPointer,
		string objectName,
		string Dimension)
		{
			RowPointerType _TableRowPointer = TableRowPointer;
			DimensionObjectType _objectName = objectName;
			DimensionNameType _Dimension = Dimension;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "List_DimCatTableSp";
				
				appDB.AddCommandParameter(cmd, "TableRowPointer", _TableRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "objectName", _objectName, ParameterDirection.Input);
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
