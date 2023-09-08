//PROJECT NAME: Reporting
//CLASS NAME: EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailTT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailTT : IEXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailTT
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailTT(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailTTFn()
		{
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailTT]()";
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_EXTSSSFSRpt_PurchaseRequirementsTimePhaseDetailTT";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
