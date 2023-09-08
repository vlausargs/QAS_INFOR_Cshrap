//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBJourpost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBJourpost
	{
		(int? ReturnCode,
			int? last_seq,
			string Infobar) MultiFSBJourpostSp(
			string FSBName,
			string id = "General",
			DateTime? trans_date = null,
			string acct = null,
			string acct_unit1 = null,
			string acct_unit2 = null,
			string acct_unit3 = null,
			string acct_unit4 = null,
			decimal? amount = null,
			string _ref = null,
			string curr_code = null,
			decimal? exch_rate = 1M,
			int? reverse = 0,
			int? last_seq = null,
			string Infobar = null,
			Guid? BufferJournal = null,
			string DomCurrCode = null,
			int? DomCurrPlaces = null);
	}
}

