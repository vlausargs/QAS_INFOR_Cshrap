//PROJECT NAME: Data
//CLASS NAME: IUnitcd1AllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUnitcd1AllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) Unitcd1AllValidSp(
			string SiteRef,
			string Unit1,
			string Description,
			string Infobar);
	}
}

