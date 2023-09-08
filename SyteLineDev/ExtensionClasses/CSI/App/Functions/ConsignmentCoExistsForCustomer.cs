//PROJECT NAME: Data
//CLASS NAME: ConsignmentCoExistsForCustomer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ConsignmentCoExistsForCustomer : IConsignmentCoExistsForCustomer
	{
		readonly IApplicationDB appDB;
		
		public ConsignmentCoExistsForCustomer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? ConsignmentCoExistsForCustomerFn(
			string CustNum,
			int? CustSeq)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[ConsignmentCoExistsForCustomer](@CustNum, @CustSeq)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
