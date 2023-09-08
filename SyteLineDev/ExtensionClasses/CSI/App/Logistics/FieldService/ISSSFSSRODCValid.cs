//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSRODCValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSRODCValid
	{
		(int? ReturnCode,
			int? SROLine,
			int? SROOper,
			string BillCode,
			string SroDesc,
			string LineItem,
			string OperDesc,
			string Infobar) SSSFSSRODCValidSp(
			string Table,
			string Level,
			string PartnerID,
			string SRONum,
			int? SROLine,
			int? SROOper,
			DateTime? TransDate,
			string BillCode,
			string SroDesc,
			string LineItem,
			string OperDesc,
			string Infobar);
	}
}

