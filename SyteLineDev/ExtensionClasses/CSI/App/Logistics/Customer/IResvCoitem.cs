//PROJECT NAME: Logistics
//CLASS NAME: IResvCoitem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IResvCoitem
	{
		(int? ReturnCode, string Infobar) ResvCoitemSp(string CurCoNum,
		int? CurCoLine,
		int? CurCoRel,
		string Infobar);
	}
}

