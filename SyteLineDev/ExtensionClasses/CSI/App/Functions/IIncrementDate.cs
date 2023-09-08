//PROJECT NAME: Data
//CLASS NAME: IIncrementDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIncrementDate
	{
		(int? ReturnCode,
			DateTime? POutDate,
			int? POutTick,
			string Infobar) IncrementDateSp(
			DateTime? PInDate,
			int? PIncr,
			int? PEnd,
			DateTime? POutDate,
			int? POutTick,
			string Infobar);
	}
}

