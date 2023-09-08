//PROJECT NAME: Data
//CLASS NAME: GetRmtForSEPAFormat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetRmtForSEPAFormat : IGetRmtForSEPAFormat
	{
		readonly IApplicationDB appDB;
		
		public GetRmtForSEPAFormat(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string GetRmtForSEPAFormatFn(
			string VendNum,
			int? CheckSeq,
			string BankCode)
		{
			VendNumType _VendNum = VendNum;
			ApCheckSeqType _CheckSeq = CheckSeq;
			BankCodeType _BankCode = BankCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[GetRmtForSEPAFormat](@VendNum, @CheckSeq, @BankCode)";
				
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CheckSeq", _CheckSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
