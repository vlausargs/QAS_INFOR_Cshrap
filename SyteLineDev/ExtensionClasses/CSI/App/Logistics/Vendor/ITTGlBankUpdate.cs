//PROJECT NAME: Logistics
//CLASS NAME: ITTGlBankUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITTGlBankUpdate
	{
		(int? ReturnCode, string Infobar) TTGlBankUpdateSp(Guid? PRowPointer,
		int? PProcessFlag,
		int? POverrideDate,
		string Infobar);
	}
}

