//PROJECT NAME: Logistics
//CLASS NAME: IRmaReplCoNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IRmaReplCoNum
	{
		(int? ReturnCode, string PCoNum,
		string Infobar) RmaReplCoNumSp(string PRmaNum,
		string PCoNum,
		string Infobar);
	}
}

