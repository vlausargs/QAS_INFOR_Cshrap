//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROWipRelSubRelieveMisc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROWipRelSubRelieveMisc
	{
		(int? ReturnCode,
			decimal? MiscCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar) SSSFSSROWipRelSubRelieveMiscSp(
			string PSroNum,
			int? PSroLine,
			int? PSroOper,
			DateTime? PBegTransDate,
			DateTime? PEndTransDate,
			int? PInclBillHold,
			int? PMarkBilled,
			int? CurrencyPlaces,
			decimal? MiscCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar);
	}
}

