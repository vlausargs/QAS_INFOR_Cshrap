//PROJECT NAME: Data
//CLASS NAME: IZeroRsv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IZeroRsv
	{
		(int? ReturnCode,
			string Infobar) ZeroRsvSp(
			string CoNum,
			string Status,
			string Infobar,
			string Site = null);
	}
}

