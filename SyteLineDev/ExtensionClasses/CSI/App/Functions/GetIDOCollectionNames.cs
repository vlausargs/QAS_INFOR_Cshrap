//PROJECT NAME: Data
//CLASS NAME: GetIDOCollectionNames.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Functions
{
	public class GetIDOCollectionNames : IGetIDOCollectionNames
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public GetIDOCollectionNames(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse GetIDOCollectionNamesFn(
			string IDO_Name)
		{
			StringType _IDO_Name = IDO_Name;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[GetIDOCollectionNames](@IDO_Name)";
				
				appDB.AddCommandParameter(cmd, "IDO_Name", _IDO_Name, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_GetIDOCollectionNames";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
