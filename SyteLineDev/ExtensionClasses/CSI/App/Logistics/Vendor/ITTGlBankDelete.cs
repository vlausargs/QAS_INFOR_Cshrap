//PROJECT NAME: Logistics
//CLASS NAME: ITTGlBankDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ITTGlBankDelete
	{
		(int? ReturnCode, string Infobar) TTGlBankDeleteSp(string Infobar);
	}
}

