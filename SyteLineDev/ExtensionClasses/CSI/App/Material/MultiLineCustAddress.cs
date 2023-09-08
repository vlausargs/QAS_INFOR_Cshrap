//PROJECT NAME: Finance
//CLASS NAME: MultiLineCustAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiLineCustAddress : IMultiLineCustAddress
	{
		readonly IApplicationDB appDB;
		
		public MultiLineCustAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MultiLineCustAddressSp(
			int? ContactNum,
			string CustNum,
			int? CustSeq)
		{
			GenericNoType _ContactNum = ContactNum;
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MultiLineCustAddressSp](@ContactNum, @CustNum, @CustSeq)";
				
				appDB.AddCommandParameter(cmd, "ContactNum", _ContactNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
