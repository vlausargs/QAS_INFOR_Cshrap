//PROJECT NAME: Data
//CLASS NAME: IIsFeatureActive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IIsFeatureActive
	{
		(int? ReturnCode,
			int? FeatureActive,
			string InfoBar) IsFeatureActiveSp(
			string ProductName = "CSI",
			string FeatureID = null,
			int? FeatureActive = 0,
			string InfoBar = null);

		int? IsFeatureActiveFn(
			string ProductName,
			string FeatureID);
	}
}

