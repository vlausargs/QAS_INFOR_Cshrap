//PROJECT NAME: Material
//CLASS NAME: IMrpdtom.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpdtom
	{
		(int? ReturnCode,
			int? Next,
			DateTime? McalMDate,
			int? McalMdayNum,
			Guid? McalRowPointer,
			string Infobar) MrpdtomSp(
			DateTime? PDate,
			string OrderNum,
			string OrderType,
			int? OrdLineSuf,
			int? OrderRel,
			string RcvReq,
			string Item,
			int? Next,
			DateTime? McalMDate,
			int? McalMdayNum,
			Guid? McalRowPointer,
			string Infobar);
	}
}

