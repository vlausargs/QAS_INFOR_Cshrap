//PROJECT NAME: Logistics
//CLASS NAME: ICheckPrefix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICheckPrefix
	{
		(int? ReturnCode, string Infobar) CheckPrefixSp(string PStartInv,
		string PEndInv,
		string Infobar);
	}
}

