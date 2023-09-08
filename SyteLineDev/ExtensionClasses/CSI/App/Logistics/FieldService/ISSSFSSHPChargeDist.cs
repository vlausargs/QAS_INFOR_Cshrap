//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSHPChargeDist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSHPChargeDist
	{
		(int? ReturnCode,
			string Infobar) SSSFSSHPChargeDistSp(
			string SroNum,
			decimal? DistAmt,
			string Infobar);
	}
}

