//PROJECT NAME: Data
//CLASS NAME: ITransNatureAllValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITransNatureAllValid
	{
		(int? ReturnCode,
			string Description,
			string Infobar) TransNatureAllValidSp(
			string SiteRef,
			string TransNat,
			string Description,
			string Infobar);
	}
}

