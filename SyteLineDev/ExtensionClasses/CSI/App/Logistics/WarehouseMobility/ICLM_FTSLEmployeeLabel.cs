//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLEmployeeLabel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLEmployeeLabel
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_FTSLEmployeeLabelSp(string FromEmp,
		string ToEmp,
		int? FromRange,
		int? ToRange,
		string Infobar);
	}
}

