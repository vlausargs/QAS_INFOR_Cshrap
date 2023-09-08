//PROJECT NAME: Data
//CLASS NAME: IPoTotalValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoTotalValue
	{
		(int? ReturnCode,
			string Infobar) PoTotalValueSp(
			string VLcrNum,
			string VendNum,
			string Infobar);
	}
}

