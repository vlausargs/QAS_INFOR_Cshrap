//PROJECT NAME: Finance
//CLASS NAME: CHSDetailLeftOverOneAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSDetailLeftOverOneAccount : ICHSDetailLeftOverOneAccount
	{
		readonly IApplicationDB appDB;
		
		public CHSDetailLeftOverOneAccount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance) CHSDetailLeftOverOneAccountSp(
			string PAcct,
			string Punit1,
			string PUnit2,
			string PUnit3,
			string PUnit4,
			DateTime? Psdate,
			DateTime? Pedate,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance)
		{
			AcctType _PAcct = PAcct;
			UnitCode1Type _Punit1 = Punit1;
			UnitCode1Type _PUnit2 = PUnit2;
			UnitCode1Type _PUnit3 = PUnit3;
			UnitCode1Type _PUnit4 = PUnit4;
			DateTimeType _Psdate = Psdate;
			DateTimeType _Pedate = Pedate;
			AmountType _Psbalance = Psbalance;
			AmountType _Pdamount = Pdamount;
			AmountType _Pcamount = Pcamount;
			AmountType _Pebalance = Pebalance;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSDetailLeftOverOneAccountSp";
				
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Punit1", _Punit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnit2", _PUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnit3", _PUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUnit4", _PUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Psdate", _Psdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pedate", _Pedate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Psbalance", _Psbalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pdamount", _Pdamount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pcamount", _Pcamount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pebalance", _Pebalance, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Psbalance = _Psbalance;
				Pdamount = _Pdamount;
				Pcamount = _Pcamount;
				Pebalance = _Pebalance;
				
				return (Severity, Psbalance, Pdamount, Pcamount, Pebalance);
			}
		}
	}
}
