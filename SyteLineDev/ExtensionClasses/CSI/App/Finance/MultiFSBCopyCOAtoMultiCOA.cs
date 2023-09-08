//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBCopyCOAtoMultiCOA.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public interface IMultiFSBCopyCOAtoMultiCOA
	{
		(int? ReturnCode, string Infobar) MultiFSBCopyCOAtoMultiCOASp(string FSBChartofAccount = null,
		string AccountTypes = null,
		string AccountStarting = null,
		string AccountEnding = null,
		string Infobar = null);
	}
	
	public class MultiFSBCopyCOAtoMultiCOA : IMultiFSBCopyCOAtoMultiCOA
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBCopyCOAtoMultiCOA(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) MultiFSBCopyCOAtoMultiCOASp(string FSBChartofAccount = null,
		string AccountTypes = null,
		string AccountStarting = null,
		string AccountEnding = null,
		string Infobar = null)
		{
			FSBChartOfAcctNameType _FSBChartofAccount = FSBChartofAccount;
			InfobarType _AccountTypes = AccountTypes;
			AcctType _AccountStarting = AccountStarting;
			AcctType _AccountEnding = AccountEnding;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBCopyCOAtoMultiCOASp";
				
				appDB.AddCommandParameter(cmd, "FSBChartofAccount", _FSBChartofAccount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountTypes", _AccountTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountStarting", _AccountStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountEnding", _AccountEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
