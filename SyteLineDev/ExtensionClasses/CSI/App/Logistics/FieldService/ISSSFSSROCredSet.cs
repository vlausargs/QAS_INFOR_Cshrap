//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROCredSet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROCredSet
	{
		int? SSSFSSROCredSetSp(
			string SroNum,
			string ArReasonCode);
	}
}

