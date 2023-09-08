//PROJECT NAME: Data
//CLASS NAME: IInvAdjC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IInvAdjC
	{
		(int? ReturnCode,
			string Infobar) InvAdjCSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			decimal? PNewDisc,
			decimal? PNewPriceConv,
			decimal? PNewPrice,
			string Infobar);
	}
}

