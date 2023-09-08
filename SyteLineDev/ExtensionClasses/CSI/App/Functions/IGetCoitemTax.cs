//PROJECT NAME: Data
//CLASS NAME: IGetCoitemTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetCoitemTax
	{
		(int? ReturnCode,
			string Infobar) GetCoitemTaxSp(
			int? ProrateTax,
			string Infobar);
	}
}

