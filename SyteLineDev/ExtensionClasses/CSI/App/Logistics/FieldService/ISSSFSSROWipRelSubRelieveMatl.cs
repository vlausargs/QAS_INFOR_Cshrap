//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROWipRelSubRelieveMatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROWipRelSubRelieveMatl
	{
		(int? ReturnCode,
			decimal? MatlCost,
			decimal? LbrCost,
			decimal? FovCost,
			decimal? VovCost,
			decimal? OutCost,
			string Infobar) SSSFSSROWipRelSubRelieveMatlSp(
			string PSroNum,
			int? PSroLine,
			int? PSroOper,
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

