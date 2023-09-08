//PROJECT NAME: Data
//CLASS NAME: ISubJobExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISubJobExists
	{
		int? SubJobExistsFn(
			string Job,
			int? Suffix);
	}
}

