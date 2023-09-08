//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBChartofAccounts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBChartofAccounts
	{
		int LoadESBChartofAccountsSP(string ActionExpression,
		                             string Account,
		                             string Description,
		                             string AccountTypeType,
		                             string EnterAnl1,
		                             string EnterAnl2,
		                             string EnterAnl3,
		                             string EnterAnl4,
		                             ref string Infobar);
	}
	
	public class LoadESBChartofAccounts : ILoadESBChartofAccounts
	{
		readonly IApplicationDB appDB;
		
		public LoadESBChartofAccounts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBChartofAccountsSP(string ActionExpression,
		                                    string Account,
		                                    string Description,
		                                    string AccountTypeType,
		                                    string EnterAnl1,
		                                    string EnterAnl2,
		                                    string EnterAnl3,
		                                    string EnterAnl4,
		                                    ref string Infobar)
		{
			StringType _ActionExpression = ActionExpression;
			AcctType _Account = Account;
			DescriptionType _Description = Description;
			StringType _AccountTypeType = AccountTypeType;
			ShortDescType _EnterAnl1 = EnterAnl1;
			ShortDescType _EnterAnl2 = EnterAnl2;
			ShortDescType _EnterAnl3 = EnterAnl3;
			ShortDescType _EnterAnl4 = EnterAnl4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBChartofAccountsSP";
				
				appDB.AddCommandParameter(cmd, "ActionExpression", _ActionExpression, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Account", _Account, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountTypeType", _AccountTypeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EnterAnl1", _EnterAnl1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EnterAnl2", _EnterAnl2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EnterAnl3", _EnterAnl3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EnterAnl4", _EnterAnl4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
