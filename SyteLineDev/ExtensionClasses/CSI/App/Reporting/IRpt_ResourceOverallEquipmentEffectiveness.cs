//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceOverallEquipmentEffectiveness.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ResourceOverallEquipmentEffectiveness
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceOverallEquipmentEffectivenessSp(string RgrpType = null,
		string StartResourceGroup = null,
		string EndResourceGroup = null,
		DateTime? StartDate = null,
		DateTime? EndDate = null,
		int? StartDateOffset = null,
		int? EndDateOffset = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

