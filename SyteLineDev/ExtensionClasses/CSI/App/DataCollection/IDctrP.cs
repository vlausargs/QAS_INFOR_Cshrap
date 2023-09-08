//PROJECT NAME: DataCollection
//CLASS NAME: IDctrP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.DataCollection
{
	public interface IDctrP
	{
		(int? ReturnCode, string Infobar) DctrPSp(int? PTransNum,
		string Infobar,
		string DocumentNum = null);
	}
}

