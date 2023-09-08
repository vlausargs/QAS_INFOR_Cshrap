//PROJECT NAME: Data
//CLASS NAME: IUnitcd4AllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUnitcd4AllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) Unitcd4AllValidSp(
			string SiteRef,
			string Unit4,
			string Description,
			string Infobar);
	}
}

