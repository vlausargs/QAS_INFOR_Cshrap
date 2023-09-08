//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSRORecalcEstTaxes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSRORecalcEstTaxes
	{
		(int? ReturnCode,
			string Infobar) SSSFSSRORecalcEstTaxesSp(
			string SroNum,
			string Infobar);
	}
}

