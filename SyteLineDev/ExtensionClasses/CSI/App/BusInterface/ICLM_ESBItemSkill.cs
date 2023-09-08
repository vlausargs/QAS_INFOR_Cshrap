//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBItemSkill.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBItemSkill
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBItemSkillSp(string SroNum,
		int? SroLine);
	}
}

