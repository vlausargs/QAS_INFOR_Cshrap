//PROJECT NAME: Production
//CLASS NAME: IprjresMatlQtyConv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IprjresMatlQtyConv
	{
		(int? ReturnCode, string Infobar) prjresMatlQtyConvSp(decimal? NewMatlQty,
		string PItem,
		string Infobar);
	}
}

