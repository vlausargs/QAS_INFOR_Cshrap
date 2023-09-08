//PROJECT NAME: Data
//CLASS NAME: IShipcodeAllUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IShipcodeAllUsed
	{
		(int? ReturnCode,
			string Infobar) ShipcodeAllUsedSp(
			string SiteRef,
			string Shipcode,
			string Infobar);
	}
}

