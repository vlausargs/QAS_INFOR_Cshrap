//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadResourceSkills.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadResourceSkills
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLLoadResourceSkillsSp();
	}
}

