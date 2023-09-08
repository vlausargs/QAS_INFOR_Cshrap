//PROJECT NAME: Finance
//CLASS NAME: ExtFin_GetSTaxDebitCreditAmountsForInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.Data;

namespace CSI.Finance.ExtFin
{
	public class ExtFin_GetSTaxDebitCreditAmountsForInvNum : IExtFin_GetSTaxDebitCreditAmountsForInvNum
	{
		readonly IApplicationDB appDB;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		readonly IDataTableUtil dataTableUtil;
		
		public ExtFin_GetSTaxDebitCreditAmountsForInvNum(IApplicationDB appDB, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse, IDataTableUtil dataTableUtil)
		{
			this.appDB = appDB;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
			this.dataTableUtil = dataTableUtil;
		}
		
		public ICollectionLoadResponse ExtFin_GetSTaxDebitCreditAmountsForInvNumFn(
			string InvNum,
			int? InvSeq)
		{
			InvNumType _InvNum = InvNum;
			ArInvSeqType _InvSeq = InvSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT * FROM dbo.[ExtFin_GetSTaxDebitCreditAmountsForInvNum](@InvNum, @InvSeq)";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				
				dtReturn = appDB.ExecuteQuery(cmd);
				dtReturn.TableName = "#fnt_ExtFin_GetSTaxDebitCreditAmountsForInvNum";
				dataTableUtil.CloneDataTableIntoDB(dtReturn);
				
				return dataTableToCollectionLoadResponse.Process(dtReturn);
			}
		}
	}
}
