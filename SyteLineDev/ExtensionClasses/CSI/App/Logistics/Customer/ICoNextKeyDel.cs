//PROJECT NAME: Logistics
//CLASS NAME: ICoNextKeyDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoNextKeyDel
	{
		(int? ReturnCode, string Infobar) CoNextKeyDelSp(string CoNum,
		string Infobar);
	}
}

