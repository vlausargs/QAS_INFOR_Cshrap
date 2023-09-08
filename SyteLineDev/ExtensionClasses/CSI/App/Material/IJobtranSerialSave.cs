//PROJECT NAME: Material
//CLASS NAME: IJobtranSerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IJobtranSerialSave
	{
		int? JobtranSerialSaveSp(string SerNum,
		int? Selected,
		Guid? TmpSerId = null,
		string Item = null,
		int? PreassignSerials = null,
		string TrxRestrictCode = null);
	}
}

