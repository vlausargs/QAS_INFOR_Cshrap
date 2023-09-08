//PROJECT NAME: Data
//CLASS NAME: ReverseSystemTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ReverseSystemTransaction : IReverseSystemTransaction
	{
		readonly IApplicationDB appDB;
		
		public ReverseSystemTransaction(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ReverseSystemTransactionSp(
			string PReverseTransactionType = null,
			string Pcontrol_prefix = null,
			string Pcontrol_site = null,
			int? Pcontrol_year = null,
			int? Pcontrol_period = null,
			decimal? Pcontrol_number = null,
			decimal? PUserId = null,
			string Infobar = null,
			DateTime? TransDate = null)
		{
			StringType _PReverseTransactionType = PReverseTransactionType;
			JourControlPrefixType _Pcontrol_prefix = Pcontrol_prefix;
			SiteType _Pcontrol_site = Pcontrol_site;
			FiscalYearType _Pcontrol_year = Pcontrol_year;
			FinPeriodType _Pcontrol_period = Pcontrol_period;
			LastTranType _Pcontrol_number = Pcontrol_number;
			TokenType _PUserId = PUserId;
			InfobarType _Infobar = Infobar;
			DateType _TransDate = TransDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ReverseSystemTransactionSp";
				
				appDB.AddCommandParameter(cmd, "PReverseTransactionType", _PReverseTransactionType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pcontrol_prefix", _Pcontrol_prefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pcontrol_site", _Pcontrol_site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pcontrol_year", _Pcontrol_year, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pcontrol_period", _Pcontrol_period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pcontrol_number", _Pcontrol_number, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUserId", _PUserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
