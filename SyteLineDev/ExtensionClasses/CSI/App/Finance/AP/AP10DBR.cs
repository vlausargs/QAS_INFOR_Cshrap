//PROJECT NAME: Finance
//CLASS NAME: AP10DBR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AP
{
	public class AP10DBR : IAP10DBR
	{
		readonly IApplicationDB appDB;
		
		public AP10DBR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			decimal? PAmtPaid,
			decimal? PAmtDisc,
			string PApStr,
			int? PBadVouch,
			int? PBadAp,
			int? PBadDisc,
			string Infobar) AP10DBRSP(
			string PSite,
			string PType,
			string PVendNum,
			int? PVoucher,
			string PDiscAcct,
			string PInvNum,
			DateTime? PInvDate,
			decimal? PInvAdj,
			decimal? PAmtPaid,
			decimal? PAmtDisc,
			string PApStr,
			int? PBadVouch,
			int? PBadAp,
			int? PBadDisc,
			string Infobar)
		{
			SiteType _PSite = PSite;
			AppmtdTypeType _PType = PType;
			VendNumType _PVendNum = PVendNum;
			VoucherType _PVoucher = PVoucher;
			AcctType _PDiscAcct = PDiscAcct;
			VendInvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			AmountType _PInvAdj = PInvAdj;
			AmountType _PAmtPaid = PAmtPaid;
			AmountType _PAmtDisc = PAmtDisc;
			AcctType _PApStr = PApStr;
			FlagNyType _PBadVouch = PBadVouch;
			FlagNyType _PBadAp = PBadAp;
			FlagNyType _PBadDisc = PBadDisc;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AP10DBRSP";
				
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PType", _PType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDiscAcct", _PDiscAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PInvAdj", _PInvAdj, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtPaid", _PAmtPaid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAmtDisc", _PAmtDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PApStr", _PApStr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBadVouch", _PBadVouch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBadAp", _PBadAp, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PBadDisc", _PBadDisc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PInvNum = _PInvNum;
				PInvDate = _PInvDate;
				PInvAdj = _PInvAdj;
				PAmtPaid = _PAmtPaid;
				PAmtDisc = _PAmtDisc;
				PApStr = _PApStr;
				PBadVouch = _PBadVouch;
				PBadAp = _PBadAp;
				PBadDisc = _PBadDisc;
				Infobar = _Infobar;
				
				return (Severity, PInvNum, PInvDate, PInvAdj, PAmtPaid, PAmtDisc, PApStr, PBadVouch, PBadAp, PBadDisc, Infobar);
			}
		}
	}
}
