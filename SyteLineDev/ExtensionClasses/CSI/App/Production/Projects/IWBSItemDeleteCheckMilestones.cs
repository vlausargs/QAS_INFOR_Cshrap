//PROJECT NAME: Production
//CLASS NAME: IWBSItemDeleteCheckMilestones.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IWBSItemDeleteCheckMilestones
	{
		(int? ReturnCode, string Infobar) WBSItemDeleteCheckMilestonesSp(string ProjNum,
		string WbsNum,
		string WbsItemRefType,
		string Infobar);
	}
}

