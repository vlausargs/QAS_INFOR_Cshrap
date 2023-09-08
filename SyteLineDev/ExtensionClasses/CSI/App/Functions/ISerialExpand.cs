//PROJECT NAME: Data
//CLASS NAME: ISerialExpand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISerialExpand
	{
		int? SerialExpandFn(
			string Site = null);
	}
}
