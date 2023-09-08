//PROJECT NAME: CSICodes
//CLASS NAME: CLM_DimSubCollection.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface ICLM_DimSubCollection
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DimSubCollectionSp(string ObjectName,
		Guid? TableRowPointer,
		string Dimension,
		string FilterString,
		string OutputFormat = "C");
	}
	
	public class CLM_DimSubCollection : ICLM_DimSubCollection
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_DimSubCollection(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_DimSubCollectionSp(string ObjectName,
		Guid? TableRowPointer,
		string Dimension,
		string FilterString,
		string OutputFormat = "C")
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				DimensionObjectType _ObjectName = ObjectName;
				RowPointerType _TableRowPointer = TableRowPointer;
				DimensionNameType _Dimension = Dimension;
				LongListType _FilterString = FilterString;
				StringType _OutputFormat = OutputFormat;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_DimSubCollectionSp";
					
					appDB.AddCommandParameter(cmd, "ObjectName", _ObjectName, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "TableRowPointer", _TableRowPointer, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Dimension", _Dimension, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "FilterString", _FilterString, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "OutputFormat", _OutputFormat, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
