//PROJECT NAME: Data
//CLASS NAME: IGetSlsmanNameSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetSlsmanName
	{
		string GetSlsmanNameSp(
			string Slsman);
	}
}

