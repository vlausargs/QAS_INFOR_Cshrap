//PROJECT NAME: Codes
//CLASS NAME: CLM_DimensionAttributes.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public class CLM_DimensionAttributes : ICLM_DimensionAttributes
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_DimensionAttributes(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_DimensionAttributesSp(string ObectName,
		string DimName,
		string ParentDimension)
		{
			DimensionObjectNameType _ObectName = ObectName;
			DimensionNameType _DimName = DimName;
			DimensionNameType _ParentDimension = ParentDimension;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CLM_DimensionAttributesSp";
				
				appDB.AddCommandParameter(cmd, "ObectName", _ObectName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DimName", _DimName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParentDimension", _ParentDimension, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
