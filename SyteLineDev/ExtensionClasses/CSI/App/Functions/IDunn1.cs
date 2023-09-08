//PROJECT NAME: Data
//CLASS NAME: IDunn1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDunn1
	{
		(int? ReturnCode,
			decimal? PTaTotal,
			decimal? PGdTotal,
			string Infobar) Dunn1Sp(
			string PCustNum = null,
			DateTime? PSDate = null,
			DateTime? PEDate = null,
			decimal? PTaTotal = null,
			decimal? PGdTotal = null,
			string PSiteRef = null,
			string Infobar = null);
	}
}

