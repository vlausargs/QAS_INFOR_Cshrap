//PROJECT NAME: Finance
//CLASS NAME: CHSGLGroupAccount.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public class CHSGLGroupAccount : ICHSGLGroupAccount
	{
		readonly IApplicationDB appDB;
		
		public CHSGLGroupAccount(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Pstartdr,
			decimal? Pstartcr,
			decimal? Pdramount,
			decimal? Pcramount,
			decimal? Penddr,
			decimal? Pendcr) CHSGLGroupAccountSP(
			int? Pseq,
			decimal? Pstartdr,
			decimal? Pstartcr,
			decimal? Pdramount,
			decimal? Pcramount,
			decimal? Penddr,
			decimal? Pendcr,
			DateTime? Psdate,
			DateTime? Pedate)
		{
			IntType _Pseq = Pseq;
			AmountType _Pstartdr = Pstartdr;
			AmountType _Pstartcr = Pstartcr;
			AmountType _Pdramount = Pdramount;
			AmountType _Pcramount = Pcramount;
			AmountType _Penddr = Penddr;
			AmountType _Pendcr = Pendcr;
			DateType _Psdate = Psdate;
			DateType _Pedate = Pedate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSGLGroupAccountSP";
				
				appDB.AddCommandParameter(cmd, "Pseq", _Pseq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pstartdr", _Pstartdr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pstartcr", _Pstartcr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pdramount", _Pdramount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pcramount", _Pcramount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Penddr", _Penddr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Pendcr", _Pendcr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Psdate", _Psdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pedate", _Pedate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Pstartdr = _Pstartdr;
				Pstartcr = _Pstartcr;
				Pdramount = _Pdramount;
				Pcramount = _Pcramount;
				Penddr = _Penddr;
				Pendcr = _Pendcr;
				
				return (Severity, Pstartdr, Pstartcr, Pdramount, Pcramount, Penddr, Pendcr);
			}
		}
	}
}
