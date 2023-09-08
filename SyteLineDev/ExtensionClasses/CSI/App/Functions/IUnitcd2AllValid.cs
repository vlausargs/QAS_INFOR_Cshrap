//PROJECT NAME: Data
//CLASS NAME: IUnitcd2AllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUnitcd2AllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) Unitcd2AllValidSp(
			string SiteRef,
			string Unit2,
			string Description,
			string Infobar);
	}
}

