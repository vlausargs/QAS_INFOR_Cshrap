//PROJECT NAME: Data
//CLASS NAME: IDomCoh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDomCoh
	{
		(int? ReturnCode,
			string Infobar) DomCohSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string Infobar);
	}
}

