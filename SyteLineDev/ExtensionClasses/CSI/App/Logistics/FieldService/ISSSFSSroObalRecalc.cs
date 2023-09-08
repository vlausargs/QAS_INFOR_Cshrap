//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroObalRecalc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroObalRecalc
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroObalRecalcSp(
			string SroNum,
			string Infobar,
			int? SetSro = 1,
			int? SetOpers = 1,
			int? SetTrans = 1,
			int? SroLine = null,
			int? SroOper = null,
			int? SetLines = 1);
	}
}

