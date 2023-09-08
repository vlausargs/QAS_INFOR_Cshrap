//PROJECT NAME: RFQ
//CLASS NAME: ISSSRfqGenSetSelected.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.RFQ
{
	public interface ISSSRfqGenSetSelected
	{
		(int? ReturnCode, string Infobar) SSSRfqGenSetSelectedSp(Guid? RowPointer,
		int? Selected,
		string Infobar);
	}
}

