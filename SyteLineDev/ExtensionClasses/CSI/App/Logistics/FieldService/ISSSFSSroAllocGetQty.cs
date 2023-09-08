//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroAllocGetQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroAllocGetQty
	{
		(int? ReturnCode,
			decimal? oQty,
			string Infobar) SSSFSSroAllocGetQtySp(
			string iWhse,
			string iItem,
			decimal? iMatlQty,
			string iSroStat,
			string iOpStat,
			decimal? oQty,
			string Infobar);
	}
}

