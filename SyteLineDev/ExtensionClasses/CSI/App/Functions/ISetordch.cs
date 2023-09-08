//PROJECT NAME: Data
//CLASS NAME: ISetordch.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISetordch
	{
		int? SetordchSp(
			string CoNum,
			string ArReasonCode);
	}
}

