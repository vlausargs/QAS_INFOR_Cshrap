//PROJECT NAME: Reporting
//CLASS NAME: EXTSSSFSRpt_TotalWIPValueByAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Reporting
{
	public class EXTSSSFSRpt_TotalWIPValueByAccount : IEXTSSSFSRpt_TotalWIPValueByAccount
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public EXTSSSFSRpt_TotalWIPValueByAccount(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse EXTSSSFSRpt_TotalWIPValueByAccountFn(
			string ExBegproductcode,
			string ExEndProductcode,
			string ExBegItem,
			string ExEndItem,
			string SRONumBeg,
			string SRONumEnd,
			string SROOperStatus)
		{
			ProductCodeType _ExBegproductcode = ExBegproductcode;
			ProductCodeType _ExEndProductcode = ExEndProductcode;
			ItemType _ExBegItem = ExBegItem;
			ItemType _ExEndItem = ExEndItem;
			FSSRONumType _SRONumBeg = SRONumBeg;
			FSSRONumType _SRONumEnd = SRONumEnd;
			Infobar _SROOperStatus = SROOperStatus;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[EXTSSSFSRpt_TotalWIPValueByAccount](@ExBegproductcode, @ExEndProductcode, @ExBegItem, @ExEndItem, @SRONumBeg, @SRONumEnd, @SROOperStatus)";
				
				appDB.AddCommandParameter(cmd, "ExBegproductcode", _ExBegproductcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndProductcode", _ExEndProductcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExBegItem", _ExBegItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExEndItem", _ExEndItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONumBeg", _SRONumBeg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SRONumEnd", _SRONumEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SROOperStatus", _SROOperStatus, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_EXTSSSFSRpt_TotalWIPValueByAccount";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
