//PROJECT NAME: Data
//CLASS NAME: IReverseSystemTransaction.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IReverseSystemTransaction
	{
		(int? ReturnCode,
			string Infobar) ReverseSystemTransactionSp(
			string PReverseTransactionType = null,
			string Pcontrol_prefix = null,
			string Pcontrol_site = null,
			int? Pcontrol_year = null,
			int? Pcontrol_period = null,
			decimal? Pcontrol_number = null,
			decimal? PUserId = null,
			string Infobar = null,
			DateTime? TransDate = null);
	}
}

