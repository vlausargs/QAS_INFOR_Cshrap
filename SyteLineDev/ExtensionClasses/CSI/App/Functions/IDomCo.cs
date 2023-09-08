//PROJECT NAME: Data
//CLASS NAME: IDomCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDomCo
	{
		(int? ReturnCode,
			string Infobar) DomCoSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string Infobar);
	}
}

