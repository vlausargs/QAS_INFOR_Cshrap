//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROWipRelSubRelieveLineMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROWipRelSubRelieveLineMatl
	{
		(int? ReturnCode,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar) SSSFSSROWipRelSubRelieveLineMatlSp(
			string PSroNum,
			int? PSroLine,
			DateTime? PBegTransDate,
			DateTime? PEndTransDate,
			int? PInclBillHold,
			int? PMarkBilled,
			int? CurrencyPlaces,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar);
	}
}

