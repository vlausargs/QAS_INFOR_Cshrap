//PROJECT NAME: Data
//CLASS NAME: ITaxcd2D.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITaxcd2D
	{
		(int? ReturnCode,
			string Infobar) Taxcd2DSp(
			string TaxCodeType,
			int? TaxSystem,
			string TaxCode,
			string Site,
			string Infobar);
	}
}

