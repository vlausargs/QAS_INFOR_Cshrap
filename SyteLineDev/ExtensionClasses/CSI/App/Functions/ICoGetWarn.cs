//PROJECT NAME: Data
//CLASS NAME: ICoGetWarn.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICoGetWarn
	{
		(int? ReturnCode,
			string Infobar) CoGetWarnSp(
			string CoNum,
			string Infobar,
			string Site = null);
	}
}

