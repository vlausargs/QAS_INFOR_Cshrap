//PROJECT NAME: Data
//CLASS NAME: IFeatureIsActivated.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFeatureIsActivated
	{
		int? FeatureIsActivatedSp(
			string ProductName = "CSI",
			string FeatureID = null);
	}
}

