//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSDrpProcessCreatePo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSDrpProcessCreatePo
	{
		(int? ReturnCode,
			string oPONum,
			string Infobar) SSSFSDrpProcessCreatePoSp(
			string iVendNum,
			string iWhse,
			string iDefaultPOPrefix,
			int? iPOKeyLength,
			string oPONum,
			string Infobar);
	}
}

