//PROJECT NAME: Data
//CLASS NAME: IGetFullName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Data.Functions
{
	public interface IGetFullName
	{
		string GetFullNameFn(
			string lname,
			string fname,
			string mi,
			string sname);
	}
}

