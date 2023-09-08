//PROJECT NAME: Data
//CLASS NAME: ICheckIntegerMultiple.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckIntegerMultiple
	{
		(int? ReturnCode,
			string Infobar) CheckIntegerMultipleSp(
			decimal? PQtyReleased,
			int? PRatio1,
			string Infobar);
	}
}

