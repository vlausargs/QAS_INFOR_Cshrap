//PROJECT NAME: Admin
//CLASS NAME: Jourpost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Admin
{
	public interface IJourpost
	{
		(int? ReturnCode, int? last_seq,
		string Infobar) JourpostSp(string id,
		decimal? trans_num = 0,
		DateTime? trans_date = null,
		string acct = null,
		string acct_unit1 = null,
		string acct_unit2 = null,
		string acct_unit3 = null,
		string acct_unit4 = null,
		decimal? amount = null,
		string Ref = null,
		string vend_num = null,
		string inv_num = null,
		string voucher = "0",
		int? check_num = 0,
		DateTime? check_date = null,
		string from_site = null,
		string ref_type = null,
		string ref_num = null,
		short? ref_line_suf = 0,
		short? ref_release = 0,
		int? vouch_seq = 0,
		string bank_code = null,
		string curr_code = null,
		decimal? for_amount = null,
		decimal? exch_rate = 1,
		byte? reverse = (byte)0,
		string ControlPrefix = null,
		string ControlSite = null,
		short? ControlYear = null,
		byte? ControlPeriod = null,
		decimal? ControlNumber = null,
		int? last_seq = null,
		string Infobar = null,
		Guid? BufferJournal = null,
		string DomCurrCode = null,
		byte? DomCurrPlaces = null,
		decimal? proj_trans_num = null,
		byte? Cancellation = (byte)0,
		string comp_level = null,
		byte? compress = null,
		byte? InvNumLength = null,
		string THPaymentNumber = null);
	}
	
	public class Jourpost : IJourpost
	{
		IApplicationDB appDB;
		
		public Jourpost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? last_seq,
		string Infobar) JourpostSp(string id,
		decimal? trans_num = 0,
		DateTime? trans_date = null,
		string acct = null,
		string acct_unit1 = null,
		string acct_unit2 = null,
		string acct_unit3 = null,
		string acct_unit4 = null,
		decimal? amount = null,
		string Ref = null,
		string vend_num = null,
		string inv_num = null,
		string voucher = "0",
		int? check_num = 0,
		DateTime? check_date = null,
		string from_site = null,
		string ref_type = null,
		string ref_num = null,
		short? ref_line_suf = 0,
		short? ref_release = 0,
		int? vouch_seq = 0,
		string bank_code = null,
		string curr_code = null,
		decimal? for_amount = null,
		decimal? exch_rate = 1,
		byte? reverse = (byte)0,
		string ControlPrefix = null,
		string ControlSite = null,
		short? ControlYear = null,
		byte? ControlPeriod = null,
		decimal? ControlNumber = null,
		int? last_seq = null,
		string Infobar = null,
		Guid? BufferJournal = null,
		string DomCurrCode = null,
		byte? DomCurrPlaces = null,
		decimal? proj_trans_num = null,
		byte? Cancellation = (byte)0,
		string comp_level = null,
		byte? compress = null,
		byte? InvNumLength = null,
		string THPaymentNumber = null)
		{
			JournalIdType _id = id;
			MatlTransNumType _trans_num = trans_num;
			DateType _trans_date = trans_date;
			AcctType _acct = acct;
			UnitCode1Type _acct_unit1 = acct_unit1;
			UnitCode2Type _acct_unit2 = acct_unit2;
			UnitCode3Type _acct_unit3 = acct_unit3;
			UnitCode4Type _acct_unit4 = acct_unit4;
			AmountType _amount = amount;
			ReferenceType _ref = Ref;
			VendNumType _vend_num = vend_num;
			VendInvNumType _inv_num = inv_num;
			InvNumVoucherType _voucher = voucher;
			GlCheckNumType _check_num = check_num;
			DateType _check_date = check_date;
			SiteType _from_site = from_site;
			AnyRefTypeType _ref_type = ref_type;
			AnyRefNumType _ref_num = ref_num;
			AnyRefLineType _ref_line_suf = ref_line_suf;
			AnyRefReleaseType _ref_release = ref_release;
			VouchSeqType _vouch_seq = vouch_seq;
			BankCodeType _bank_code = bank_code;
			CurrCodeType _curr_code = curr_code;
			AmountType _for_amount = for_amount;
			ExchRateType _exch_rate = exch_rate;
			ListYesNoType _reverse = reverse;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			JournalSeqType _last_seq = last_seq;
			InfobarType _Infobar = Infobar;
			RowPointerType _BufferJournal = BufferJournal;
			CurrCodeType _DomCurrCode = DomCurrCode;
			DecimalPlacesType _DomCurrPlaces = DomCurrPlaces;
			ProjTransNumType _proj_trans_num = proj_trans_num;
			ListYesNoType _Cancellation = Cancellation;
			JournalCompLevelType _comp_level = comp_level;
			ListYesNoType _compress = compress;
			InvNumLength _InvNumLength = InvNumLength;
			PaymentNumberType _THPaymentNumber = THPaymentNumber;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "JourpostSp";
				
				appDB.AddCommandParameter(cmd, "id", _id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "trans_num", _trans_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "trans_date", _trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct", _acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit1", _acct_unit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit2", _acct_unit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit3", _acct_unit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit4", _acct_unit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "amount", _amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref", _ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vend_num", _vend_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "inv_num", _inv_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "voucher", _voucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "check_num", _check_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "check_date", _check_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "from_site", _from_site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_type", _ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_num", _ref_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_line_suf", _ref_line_suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_release", _ref_release, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vouch_seq", _vouch_seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "bank_code", _bank_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "curr_code", _curr_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "for_amount", _for_amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "exch_rate", _exch_rate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "reverse", _reverse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "last_seq", _last_seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BufferJournal", _BufferJournal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrPlaces", _DomCurrPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "proj_trans_num", _proj_trans_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cancellation", _Cancellation, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "comp_level", _comp_level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "compress", _compress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumLength", _InvNumLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "THPaymentNumber", _THPaymentNumber, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				last_seq = _last_seq;
				Infobar = _Infobar;
				
				return (Severity, last_seq, Infobar);
			}
		}
	}
}
