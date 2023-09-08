//PROJECT NAME: Data
//CLASS NAME: GetInvoiceList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetInvoiceList : IGetInvoiceList
	{
		readonly IApplicationDB appDB;
		
		public GetInvoiceList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetInvoiceListFn(
			int? DirectDebitNum)
		{
			DirectDebitNumType _DirectDebitNum = DirectDebitNum;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetInvoiceList](@DirectDebitNum)";
				
				appDB.AddCommandParameter(cmd, "DirectDebitNum", _DirectDebitNum, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
