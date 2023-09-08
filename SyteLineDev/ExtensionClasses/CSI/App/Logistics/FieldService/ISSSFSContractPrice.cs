//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContractPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContractPrice
	{
		(int? ReturnCode,
			decimal? OutUnitPrice) SSSFSContractPriceSp(
			string InType,
			string InSroNum,
			int? InSroLine,
			DateTime? InTransDate,
			string InWorkItem,
			decimal? OutUnitPrice);
	}
}

