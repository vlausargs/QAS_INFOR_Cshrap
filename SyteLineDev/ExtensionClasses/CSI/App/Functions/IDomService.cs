//PROJECT NAME: Data
//CLASS NAME: IDomService.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDomService
	{
		(int? ReturnCode,
			string Infobar) DomServiceSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			string Infobar);
	}
}

