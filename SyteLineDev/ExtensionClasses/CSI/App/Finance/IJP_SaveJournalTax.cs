//PROJECT NAME: Finance
//CLASS NAME: IJP_SaveJournalTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJP_SaveJournalTax
	{
		int? JP_SaveJournalTaxSp(int? JPTaxable,
		Guid? RowPointer,
		string JPTaxCode,
		decimal? JPTaxRate,
		decimal? JPTaxAmount,
		int? JPEntryIsTax);
	}
}

