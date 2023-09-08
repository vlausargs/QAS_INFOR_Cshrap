//PROJECT NAME: Logistics
//CLASS NAME: ISetCoStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISetCoStatus
	{
		(int? ReturnCode, string Infobar) SetCoStatusSp(string CoNumList,
		string Infobar);
	}
}

