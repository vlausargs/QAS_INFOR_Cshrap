//PROJECT NAME: Data
//CLASS NAME: UseBuyRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class UseBuyRate : IUseBuyRate
	{
		readonly IApplicationDB appDB;
		
		public UseBuyRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? UseBuyRateFn(
			string Type,
			string RefType,
			string BankCode)
		{
			GlbankTypeType _Type = Type;
			GlbankRefTypeType _RefType = RefType;
			BankCodeType _BankCode = BankCode;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[UseBuyRate](@Type, @RefType, @BankCode)";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
