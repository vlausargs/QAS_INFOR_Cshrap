//PROJECT NAME: Data
//CLASS NAME: MaskBank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaskBank : IMaskBank
	{
		readonly IApplicationDB appDB;
		
		public MaskBank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MaskBankFn(
			string PBankAcct)
		{
			BankAccountType _PBankAcct = PBankAcct;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaskBank](@PBankAcct)";
				
				appDB.AddCommandParameter(cmd, "PBankAcct", _PBankAcct, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
