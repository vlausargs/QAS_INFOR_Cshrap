//PROJECT NAME: Finance
//CLASS NAME: SSSCCICheckOrderAuthorized.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCICheckOrderAuthorized
	{
		(int? ReturnCode, string Infobar) SSSCCICheckOrderAuthorizedSp(string RefType,
		string RefNum,
		string Infobar);
	}
	
	public class SSSCCICheckOrderAuthorized : ISSSCCICheckOrderAuthorized
	{
		readonly IApplicationDB appDB;
		
		public SSSCCICheckOrderAuthorized(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSCCICheckOrderAuthorizedSp(string RefType,
		string RefNum,
		string Infobar)
		{
			CCITransRefTypeType _RefType = RefType;
			InvNumType _RefNum = RefNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSCCICheckOrderAuthorizedSp";
				
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
