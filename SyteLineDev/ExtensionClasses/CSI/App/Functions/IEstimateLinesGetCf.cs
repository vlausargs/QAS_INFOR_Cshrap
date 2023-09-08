//PROJECT NAME: Data
//CLASS NAME: IEstimateLinesGetCf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEstimateLinesGetCf
	{
		(int? ReturnCode,
			decimal? UomConvFactor,
			decimal? QtyOrderedBase,
			string Infobar) EstimateLinesGetCfSp(
			string UM,
			string Item,
			string CustNum,
			decimal? QtyOrdered,
			decimal? UomConvFactor,
			decimal? QtyOrderedBase,
			string Infobar);
	}
}

