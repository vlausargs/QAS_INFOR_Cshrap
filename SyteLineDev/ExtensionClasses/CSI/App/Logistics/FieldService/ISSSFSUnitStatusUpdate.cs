//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitStatusUpdate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitStatusUpdate
	{
		(int? ReturnCode,
			string Infobar) SSSFSUnitStatusUpdateSp(
			string SerNum,
			string RefType,
			string RefNum,
			string UnitStatCode,
			string Infobar,
			DateTime? StatDate = null,
			string Item = null);
	}
}

