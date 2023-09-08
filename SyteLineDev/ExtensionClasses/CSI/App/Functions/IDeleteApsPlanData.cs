//PROJECT NAME: Data
//CLASS NAME: IDeleteApsPlanData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteApsPlanData
	{
		int? DeleteApsPlanDataSp(
			string OrderId);
	}
}

