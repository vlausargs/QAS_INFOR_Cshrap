//PROJECT NAME: Material
//CLASS NAME: IMrpNet.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpNet
	{
		(int? ReturnCode, string Infobar) MrpNetSp(string UserMrpPlanningType = "R",
		string FormCaption = null,
		int? BgTaskID = null,
		string Infobar = null,
		int? DebugLevel = 0,
		int? ItemElapsedTime = 0);
	}
}

