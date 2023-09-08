//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSROGenTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSROGenTT : ISSSFSSROGenTT
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public SSSFSSROGenTT(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse SSSFSSROGenTTFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[SSSFSSROGenTT]()";
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_SSSFSSROGenTT";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
