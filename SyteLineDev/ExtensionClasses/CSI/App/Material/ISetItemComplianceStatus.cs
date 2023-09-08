//PROJECT NAME: Material
//CLASS NAME: ISetItemComplianceStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ISetItemComplianceStatus
	{
		(int? ReturnCode, string Infobar) SetItemComplianceStatusSp(int? ProcessAll = 0,
		string ComplianceProgramId = null,
		string Mode = "N",
		string Infobar = null,
		DateTime? EffectDate = null);
	}
}

