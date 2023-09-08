//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSkill.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSkill
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSkillSp(string EmpNum);
	}
}

