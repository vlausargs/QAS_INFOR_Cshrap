//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitMeterUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitMeterUpdate
	{
		(int? ReturnCode,
			string Infobar) SSSFSUnitMeterUpdateSp(
			string SerNum,
			string RefType,
			string RefNum,
			int? MeterAmt,
			string Infobar,
			string Item);
	}
}

