//PROJECT NAME: Production
//CLASS NAME: IEngWBCreateResourceGroup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IEngWBCreateResourceGroup
	{
		(int? ReturnCode, string Infobar) EngWBCreateResourceGroupSp(string Job,
		int? Suffix,
		int? OperNum,
		string JrtWc,
		string Infobar);
	}
}

