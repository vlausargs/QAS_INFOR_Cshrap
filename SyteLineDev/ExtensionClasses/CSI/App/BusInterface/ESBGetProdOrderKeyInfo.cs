//PROJECT NAME: BusInterface
//CLASS NAME: ESBGetProdOrderKeyInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.BusInterface
{
	public class ESBGetProdOrderKeyInfo : IESBGetProdOrderKeyInfo
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public ESBGetProdOrderKeyInfo(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse ESBGetProdOrderKeyInfoFn(
			string ProdOrderKey)
		{
			LongListType _ProdOrderKey = ProdOrderKey;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[ESBGetProdOrderKeyInfo](@ProdOrderKey)";
				
				appDB.AddCommandParameter(cmd, "ProdOrderKey", _ProdOrderKey, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_ESBGetProdOrderKeyInfo";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
