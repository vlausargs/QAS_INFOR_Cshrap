//PROJECT NAME: Finance
//CLASS NAME: Ap01DbR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class Ap01DbR : IAp01DbR
	{
		readonly IApplicationDB appDB;
		
		public Ap01DbR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar) Ap01DbRSp(
			string PSite,
			string PVendNum,
			int? PVoucher,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			string Infobar)
		{
			SiteType _PSite = PSite;
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			VendInvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			AmountType _PInvAdj = PInvAdj;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Ap01DbRSp";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvAdj", _PInvAdj, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PInvNum = _PInvNum;
				PInvDate = _PInvDate;
				PInvAdj = _PInvAdj;
				Infobar = _Infobar;
				
				return (Severity, PInvNum, PInvDate, PInvAdj, Infobar);
			}
		}
	}
}
