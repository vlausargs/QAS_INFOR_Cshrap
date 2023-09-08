//PROJECT NAME: Data
//CLASS NAME: FormatAddressShort.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class FormatAddressShort : IFormatAddressShort
	{
		readonly IApplicationDB appDB;
		
		public FormatAddressShort(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string FormatAddressShortFn(
			string CustNum,
			int? CustSeq)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatAddressShort](@CustNum, @CustSeq)";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
