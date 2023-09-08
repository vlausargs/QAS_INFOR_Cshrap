//PROJECT NAME: Logistics
//CLASS NAME: PoapGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoapGen : IPoapGen
	{
		readonly IApplicationDB appDB;
		
		
		public PoapGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PoVoucher,
		string Infobar) PoapGenSp(string PVendNum,
		string PVchAdj,
		int? PVoucher,
		DateTime? PDistDate,
		int? PIsEdi,
		int? PSeqNum,
		int? PPreRegister,
		decimal? PPurchAmt,
		decimal? PFreight,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		string PInvNum,
		DateTime? PInvDate,
		string PTermsCode,
		string PAuthorizer,
		int? PFixedRate,
		decimal? PExchRate,
		string PFormTitle,
		string CalledFrom = null,
		Guid? PProcessId = null,
		int? PAutoVoucher = null,
		int? PoVoucher = null,
		string Infobar = null,
		string CurrCode = null,
		DateTime? PTaxDate = null)
		{
			VendNumType _PVendNum = PVendNum;
			VchPrStatusType _PVchAdj = PVchAdj;
			VoucherType _PVoucher = PVoucher;
			DateType _PDistDate = PDistDate;
			ListYesNoType _PIsEdi = PIsEdi;
			EdiSeqType _PSeqNum = PSeqNum;
			PreRegisterType _PPreRegister = PPreRegister;
			AmountType _PPurchAmt = PPurchAmt;
			AmountType _PFreight = PFreight;
			AmountType _PMiscCharges = PMiscCharges;
			AmountType _PSalesTax = PSalesTax;
			AmountType _PSalesTax2 = PSalesTax2;
			VendInvNumType _PInvNum = PInvNum;
			DateType _PInvDate = PInvDate;
			TermsCodeType _PTermsCode = PTermsCode;
			UsernameType _PAuthorizer = PAuthorizer;
			ListYesNoType _PFixedRate = PFixedRate;
			ExchRateType _PExchRate = PExchRate;
			InfobarType _PFormTitle = PFormTitle;
			StringType _CalledFrom = CalledFrom;
			RowPointerType _PProcessId = PProcessId;
			ListYesNoType _PAutoVoucher = PAutoVoucher;
			VoucherType _PoVoucher = PoVoucher;
			InfobarType _Infobar = Infobar;
			CurrCodeType _CurrCode = CurrCode;
			DateType _PTaxDate = PTaxDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoapGenSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVchAdj", _PVchAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDate", _PDistDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PIsEdi", _PIsEdi, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeqNum", _PSeqNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPreRegister", _PPreRegister, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPurchAmt", _PPurchAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFreight", _PFreight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMiscCharges", _PMiscCharges, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax", _PSalesTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSalesTax2", _PSalesTax2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvDate", _PInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTermsCode", _PTermsCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAuthorizer", _PAuthorizer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFixedRate", _PFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PExchRate", _PExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFormTitle", _PFormTitle, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CalledFrom", _CalledFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProcessId", _PProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAutoVoucher", _PAutoVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoVoucher", _PoVoucher, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxDate", _PTaxDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoVoucher = _PoVoucher;
				Infobar = _Infobar;
				
				return (Severity, PoVoucher, Infobar);
			}
		}
	}
}
