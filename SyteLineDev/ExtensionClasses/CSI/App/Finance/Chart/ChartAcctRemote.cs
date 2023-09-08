//PROJECT NAME: Data
//CLASS NAME: ChartAcctRemote.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chart
{
	public class ChartAcctRemote : IChartAcctRemote
	{
		readonly IApplicationDB appDB;
		
		public ChartAcctRemote(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ChartAcctRemoteSp(
			string pMode,
			string pacct,
			string ptype,
			string pdescription,
			string preports_to_acct,
			DateTime? peff_date,
			DateTime? pobs_date,
			string paccess_unit1,
			string paccess_unit2,
			string paccess_unit3,
			string paccess_unit4,
			string pacct_class,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null,
			int? is_control = 0,
			string UETListPairs = null,
			string TransMethod = "N")
		{
			InfobarType _pMode = pMode;
			AcctType _pacct = pacct;
			ChartTypeType _ptype = ptype;
			DescriptionType _pdescription = pdescription;
			AcctType _preports_to_acct = preports_to_acct;
			DateType _peff_date = peff_date;
			DateType _pobs_date = pobs_date;
			UnitCodeAccessType _paccess_unit1 = paccess_unit1;
			UnitCodeAccessType _paccess_unit2 = paccess_unit2;
			UnitCodeAccessType _paccess_unit3 = paccess_unit3;
			UnitCodeAccessType _paccess_unit4 = paccess_unit4;
			AcctClassType _pacct_class = pacct_class;
			InfobarType _Infobar = Infobar;
			ListYesNoType _RepFromTrigger = RepFromTrigger;
			SiteType _RepFromSite = RepFromSite;
			ListYesNoType _is_control = is_control;
			VeryLongListType _UETListPairs = UETListPairs;
			CurrTransMethodType _TransMethod = TransMethod;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ChartAcctRemoteSp";
				
				appDB.AddCommandParameter(cmd, "pMode", _pMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pacct", _pacct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ptype", _ptype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pdescription", _pdescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "preports_to_acct", _preports_to_acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "peff_date", _peff_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pobs_date", _pobs_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "paccess_unit1", _paccess_unit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "paccess_unit2", _paccess_unit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "paccess_unit3", _paccess_unit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "paccess_unit4", _paccess_unit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pacct_class", _pacct_class, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RepFromTrigger", _RepFromTrigger, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RepFromSite", _RepFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "is_control", _is_control, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UETListPairs", _UETListPairs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransMethod", _TransMethod, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
