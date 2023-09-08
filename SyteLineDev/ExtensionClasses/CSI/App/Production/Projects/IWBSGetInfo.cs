//PROJECT NAME: Production
//CLASS NAME: IWBSGetInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IWBSGetInfo
	{
		int? WBSGetInfoSp(
			string PcostNum,
			string PType,
			string PNum,
			int? PLine,
			int? PSeq,
			string Site);
	}
}

