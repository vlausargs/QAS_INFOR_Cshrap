//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroReSumAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroReSumAll
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroReSumAllSp(
			string SroNum,
			string Infobar,
			int? CalledFromInvoicing = 0);
	}
}

