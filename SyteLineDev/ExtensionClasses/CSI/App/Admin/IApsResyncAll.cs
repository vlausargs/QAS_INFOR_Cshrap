//PROJECT NAME: Admin
//CLASS NAME: IApsResyncAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IApsResyncAll
	{
		int? ApsResyncAllSp(int? TaskNumber = null);
	}
}

