//PROJECT NAME: Data
//CLASS NAME: ICheckforTHALC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICheckforTHALC
	{
		(int? ReturnCode,
			int? THLC) CheckforTHALCSp(
			int? THLC);
	}
}

