//PROJECT NAME: Data
//CLASS NAME: DisplayedAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DisplayedAddress : IDisplayedAddress
	{
		readonly IApplicationDB appDB;
		
		public DisplayedAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string DisplayedAddressSp(
			string CustNum,
			int? CustSeq)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[DisplayedAddressSp](@CustNum, @CustSeq)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
