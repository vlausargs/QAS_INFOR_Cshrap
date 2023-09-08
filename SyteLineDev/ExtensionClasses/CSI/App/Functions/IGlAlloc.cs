//PROJECT NAME: Data
//CLASS NAME: IGlAlloc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGlAlloc
	{
		(int? ReturnCode,
			decimal? DomAmount,
			decimal? DomRemainder,
			decimal? ForAmount,
			decimal? ForRemainder,
			decimal? TotalPercent,
			string Infobar) GlAllocSp(
			decimal? DomAmount,
			decimal? DomPAmount,
			decimal? DomRemainder,
			int? DomPlaces,
			decimal? ForAmount,
			decimal? ForPAmount,
			decimal? ForRemainder,
			int? ForPlaces,
			string AllocationBasisType,
			decimal? AllocationBasisRate,
			decimal? TotalPercent,
			string Infobar);
	}
}

