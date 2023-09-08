//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetRuleValues2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetRuleValues2
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetRuleValues2Sp(int? AltNo,
		int? PRuleType,
		string RuleValueFilter = null);
	}
}

