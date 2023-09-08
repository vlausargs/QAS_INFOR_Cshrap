//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROTransDefs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROTransDefs
	{
		(int? ReturnCode,
			string BillCode,
			string Whse,
			string Dept,
			DateTime? PostDate,
			string Infobar,
			string PriceCode,
			int? ReimbMatl,
			string WorkCode,
			string MiscCode) SSSFSSROTransDefsSp(
			string Table,
			string SRONum,
			int? SROLine,
			int? SROOper,
			string PartnerId,
			DateTime? TransDate,
			string BillCode,
			string Whse,
			string Dept,
			DateTime? PostDate,
			string Infobar,
			string PriceCode = null,
			int? ReimbMatl = null,
			string WorkCode = null,
			string MiscCode = null);
	}
}

