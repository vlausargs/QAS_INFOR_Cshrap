//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSConInvSubCalcProrate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSConInvSubCalcProrate
	{
		(int? ReturnCode,
			DateTime? oEndDate,
			string Infobar) SSSFSConInvSubCalcProrateSp(
			DateTime? IRenewalDate,
			int? ITimes,
			DateTime? IBegdate,
			DateTime? oEndDate,
			string Infobar);
	}
}

