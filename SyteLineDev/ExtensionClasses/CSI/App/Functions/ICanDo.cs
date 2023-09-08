//PROJECT NAME: Data
//CLASS NAME: ICanDoSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICanDo
	{
		int? CanDoSp(
			string Type,
			string Interface);
	}
}

