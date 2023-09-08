//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContractPriceEnt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContractPriceEnt
	{
		(int? ReturnCode,
			decimal? OutPercent) SSSFSContractPriceEntSp(
			string InType,
			string Contract,
			int? ContLine,
			string SroType,
			string InFamilyWork,
			decimal? OutPercent);
	}
}

