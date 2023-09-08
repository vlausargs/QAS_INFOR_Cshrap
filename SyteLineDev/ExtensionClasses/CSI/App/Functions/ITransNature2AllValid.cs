//PROJECT NAME: Data
//CLASS NAME: ITransNature2AllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransNature2AllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) TransNature2AllValidSp(
			string SiteRef,
			string TransNat2,
			string Description,
			string Infobar);
	}
}

