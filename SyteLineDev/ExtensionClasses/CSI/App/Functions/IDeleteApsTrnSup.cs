//PROJECT NAME: Data
//CLASS NAME: IDeleteApsTrnSup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IDeleteApsTrnSup
	{
		int? DeleteApsTrnSupSp(
			string POrderID);
	}
}

