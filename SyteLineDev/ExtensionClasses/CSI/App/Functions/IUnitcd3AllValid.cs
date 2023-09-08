//PROJECT NAME: Data
//CLASS NAME: IUnitcd3AllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUnitcd3AllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) Unitcd3AllValidSp(
			string SiteRef,
			string Unit3,
			string Description,
			string Infobar);
	}
}

