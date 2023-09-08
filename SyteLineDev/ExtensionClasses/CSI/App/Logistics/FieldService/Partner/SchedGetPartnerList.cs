//PROJECT NAME: Logistics
//CLASS NAME: SchedGetPartnerList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Logistics.FieldService.Partner
{
	public class SchedGetPartnerList : ISchedGetPartnerList
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public SchedGetPartnerList(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse SchedGetPartnerListSp(
			string FilterUsername,
			string FilterName,
			int? FilterType)
		{
			StringType _FilterUsername = FilterUsername;
			StringType _FilterName = FilterName;
			IntType _FilterType = FilterType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[SchedGetPartnerListSp](@FilterUsername, @FilterName, @FilterType)";
				
				appDB.AddCommandParameter(cmd, "FilterUsername", _FilterUsername, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterName", _FilterName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FilterType", _FilterType, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_SchedGetPartnerList";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
