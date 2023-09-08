//PROJECT NAME: Production
//CLASS NAME: IHome_MetricProjectMilestones.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IHome_MetricProjectMilestones
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_MetricProjectMilestonesSp(string MilestoneIndicator);
	}
}

