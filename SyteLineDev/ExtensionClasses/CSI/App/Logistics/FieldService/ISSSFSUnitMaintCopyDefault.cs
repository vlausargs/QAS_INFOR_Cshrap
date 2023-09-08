//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSUnitMaintCopyDefault.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSUnitMaintCopyDefault
	{
		int? SSSFSUnitMaintCopyDefaultSP(
			string InItem,
			string InSerNum);
	}
}

