//PROJECT NAME: Data
//CLASS NAME: InvJour.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvJour : IInvJour
	{
		readonly IApplicationDB appDB;
		
		public InvJour(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			int? last_seq) InvJourSp(
			string JournalId = "IC Dist",
			string acct = null,
			string acct_unit1 = null,
			string acct_unit2 = null,
			string acct_unit3 = null,
			string acct_unit4 = null,
			decimal? amount = null,
			string caller = null,
			string occur = null,
			string ref_type = null,
			string ref_num = null,
			int? ref_line_suf = 0,
			int? ref_release = 0,
			string _ref = null,
			DateTime? trans_date = null,
			decimal? trans_num = 0,
			string vend_num = null,
			string acct_label = null,
			string file_label = null,
			string key_label_1 = null,
			string key_value_1 = null,
			string key_label_2 = null,
			string key_value_2 = null,
			string key_label_3 = null,
			string key_value_3 = null,
			string key_label_4 = null,
			string key_value_4 = null,
			int? keys = 0,
			string curr_code = null,
			decimal? for_amount = 0,
			decimal? exch_rate = 1M,
			int? ParmsPostJour = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			int? AccountsValidated = 0,
			string Infobar = null,
			int? last_seq = null,
			Guid? BufferJournal = null,
			decimal? proj_trans_num = null,
			int? DomCurrPlaces = null,
			string ParmsSite = null,
			string comp_level = null,
			int? compress = null,
			int? InvNumLength = null)
		{
			JournalIdType _JournalId = JournalId;
			AcctType _acct = acct;
			UnitCode1Type _acct_unit1 = acct_unit1;
			UnitCode2Type _acct_unit2 = acct_unit2;
			UnitCode3Type _acct_unit3 = acct_unit3;
			UnitCode4Type _acct_unit4 = acct_unit4;
			AmountType _amount = amount;
			StringType _caller = caller;
			LangLabelType _occur = occur;
			AnyRefTypeType _ref_type = ref_type;
			AnyRefNumType _ref_num = ref_num;
			AnyRefLineType _ref_line_suf = ref_line_suf;
			AnyRefReleaseType _ref_release = ref_release;
			ReferenceType __ref = _ref;
			DateType _trans_date = trans_date;
			MatlTransNumType _trans_num = trans_num;
			VendNumType _vend_num = vend_num;
			StringType _acct_label = acct_label;
			StringType _file_label = file_label;
			StringType _key_label_1 = key_label_1;
			StringType _key_value_1 = key_value_1;
			StringType _key_label_2 = key_label_2;
			StringType _key_value_2 = key_value_2;
			StringType _key_label_3 = key_label_3;
			StringType _key_value_3 = key_value_3;
			StringType _key_label_4 = key_label_4;
			StringType _key_value_4 = key_value_4;
			IntType _keys = keys;
			CurrCodeType _curr_code = curr_code;
			AmountType _for_amount = for_amount;
			ExchRateType _exch_rate = exch_rate;
			ListYesNoType _ParmsPostJour = ParmsPostJour;
			StringType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			ListYesNoType _AccountsValidated = AccountsValidated;
			InfobarType _Infobar = Infobar;
			JournalSeqType _last_seq = last_seq;
			RowPointerType _BufferJournal = BufferJournal;
			ProjTransNumType _proj_trans_num = proj_trans_num;
			DecimalPlacesType _DomCurrPlaces = DomCurrPlaces;
			SiteType _ParmsSite = ParmsSite;
			JournalCompLevelType _comp_level = comp_level;
			ListYesNoType _compress = compress;
			InvNumLength _InvNumLength = InvNumLength;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvJourSp";
				
				appDB.AddCommandParameter(cmd, "JournalId", _JournalId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct", _acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit1", _acct_unit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit2", _acct_unit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit3", _acct_unit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit4", _acct_unit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "amount", _amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "caller", _caller, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "occur", _occur, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_type", _ref_type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_num", _ref_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_line_suf", _ref_line_suf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref_release", _ref_release, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref", __ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "trans_date", _trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "trans_num", _trans_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "vend_num", _vend_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_label", _acct_label, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "file_label", _file_label, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_label_1", _key_label_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_value_1", _key_value_1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_label_2", _key_label_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_value_2", _key_value_2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_label_3", _key_label_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_value_3", _key_value_3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_label_4", _key_label_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "key_value_4", _key_value_4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "keys", _keys, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "curr_code", _curr_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "for_amount", _for_amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "exch_rate", _exch_rate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsPostJour", _ParmsPostJour, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountsValidated", _AccountsValidated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "last_seq", _last_seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BufferJournal", _BufferJournal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "proj_trans_num", _proj_trans_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrPlaces", _DomCurrPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsSite", _ParmsSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "comp_level", _comp_level, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "compress", _compress, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNumLength", _InvNumLength, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				last_seq = _last_seq;
				
				return (Severity, Infobar, last_seq);
			}
		}
	}
}
