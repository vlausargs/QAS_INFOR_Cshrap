//PROJECT NAME: Data
//CLASS NAME: IInvJour.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvJour
	{
		(int? ReturnCode,
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
			int? InvNumLength = null);
	}
}

