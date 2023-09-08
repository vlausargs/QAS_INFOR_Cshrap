//PROJECT NAME: Data
//CLASS NAME: IItemwhseAllExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IItemwhseAllExists
	{
		int? ItemwhseAllExistsFn(
			string Item,
			string Whse,
			string Site);
	}
}

