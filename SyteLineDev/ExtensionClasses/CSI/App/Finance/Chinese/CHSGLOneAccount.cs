//PROJECT NAME: Finance
//CLASS NAME: CHSGLOneAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGLOneAccount : ICHSGLOneAccount
	{
		readonly IApplicationDB appDB;
		
		public CHSGLOneAccount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance) CHSGLOneAccountSp(
			string PAcct,
			DateTime? Psdate,
			DateTime? Pedate,
			decimal? Psbalance,
			decimal? Pdamount,
			decimal? Pcamount,
			decimal? Pebalance)
		{
			AcctType _PAcct = PAcct;
			DateTimeType _Psdate = Psdate;
			DateTimeType _Pedate = Pedate;
			AmountType _Psbalance = Psbalance;
			AmountType _Pdamount = Pdamount;
			AmountType _Pcamount = Pcamount;
			AmountType _Pebalance = Pebalance;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSGLOneAccountSp";
				
				appDB.AddCommandParameter(cmd, "PAcct", _PAcct, ParameterDirection.Input);
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
