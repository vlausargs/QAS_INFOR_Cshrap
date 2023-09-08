//PROJECT NAME: Data
//CLASS NAME: IPricecodeItemValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPricecodeItemValid
	{
		(int? ReturnCode,
			string PricecodeDesc,
			string Infobar) PricecodeItemValidSp(
			string Pricecode,
			string PricecodeDesc,
			string Infobar,
			string Site = null);
	}
}

