//PROJECT NAME: Material
//CLASS NAME: IWhseaddrSp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IWhseaddr
	{
		string WhseaddrSp(
			string Whse,
			string Site,
			string Contact = null);
	}
}

