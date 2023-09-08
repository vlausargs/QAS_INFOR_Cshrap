//PROJECT NAME: Admin
//CLASS NAME: IHome_BGTaskAnalysis.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IHome_BGTaskAnalysis
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Home_BGTaskAnalysisSp(string FilterString,
			DateTime? StartDate = null,
			DateTime? EndDate = null,
			string DatabaseName = null,
			string Site = null);
	}
}

