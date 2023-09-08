//PROJECT NAME: Data
//CLASS NAME: IUpdateVendLcr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUpdateVendLcr
	{
		(int? ReturnCode,
			string Infobar) UpdateVendLcrSp(
			string PoNum,
			string PoVendNum,
			int? AddAccum,
			string LcrNum,
			string Infobar);
	}
}

