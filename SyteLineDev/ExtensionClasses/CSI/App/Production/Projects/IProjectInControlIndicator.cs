//PROJECT NAME: Production
//CLASS NAME: IProjectInControlIndicator.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjectInControlIndicator
	{
		string ProjectInControlIndicatorFn(
			string ProjNum,
			int? TaskNum,
			int? Seq,
			string ProjLevel,
			string Site = null);
	}
}

