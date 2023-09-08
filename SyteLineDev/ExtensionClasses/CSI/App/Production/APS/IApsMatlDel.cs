//PROJECT NAME: Production
//CLASS NAME: IApsMatlDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMatlDel
	{
		int? ApsMatlDelSp(Guid? Rowp,
		string PMatl,
		int? AltNo);
	}
}

