//PROJECT NAME: Finance
//CLASS NAME: CHSDetailLeftOverItemAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSDetailLeftOverItemAccount : ICHSDetailLeftOverItemAccount
	{
		readonly IApplicationDB appDB;
		
		public CHSDetailLeftOverItemAccount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Psdebit,
			decimal? Pscredit,
			decimal? Pdebitamt,
			decimal? Pcreditamt,
			decimal? Pedebit,
			decimal? Pecredit,
			DateTime? Psdate,
			DateTime? Pedate) CHSDetailLeftOverItemAccountSP(
			string Group,
			int? Psseq,
			int? Peseq,
			decimal? Psdebit = 0,
			decimal? Pscredit = 0,
			decimal? Pdebitamt = 0,
			decimal? Pcreditamt = 0,
			decimal? Pedebit = 0,
			decimal? Pecredit = 0,
			DateTime? Psdate = null,
			DateTime? Pedate = null)
		{
			StringType _Group = Group;
			IntType _Psseq = Psseq;
			IntType _Peseq = Peseq;
			AmountType _Psdebit = Psdebit;
			AmountType _Pscredit = Pscredit;
			AmountType _Pdebitamt = Pdebitamt;
			AmountType _Pcreditamt = Pcreditamt;
			AmountType _Pedebit = Pedebit;
			AmountType _Pecredit = Pecredit;
			DateTimeType _Psdate = Psdate;
			DateTimeType _Pedate = Pedate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSDetailLeftOverItemAccountSP";
				
				appDB.AddCommandParameter(cmd, "Group", _Group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Psseq", _Psseq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Peseq", _Peseq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Psdebit", _Psdebit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pscredit", _Pscredit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pdebitamt", _Pdebitamt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pcreditamt", _Pcreditamt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pedebit", _Pedebit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pecredit", _Pecredit, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Psdate", _Psdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pedate", _Pedate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Psdebit = _Psdebit;
				Pscredit = _Pscredit;
				Pdebitamt = _Pdebitamt;
				Pcreditamt = _Pcreditamt;
				Pedebit = _Pedebit;
				Pecredit = _Pecredit;
				Psdate = _Psdate;
				Pedate = _Pedate;
				
				return (Severity, Psdebit, Pscredit, Pdebitamt, Pcreditamt, Pedebit, Pecredit, Psdate, Pedate);
			}
		}
	}
}
