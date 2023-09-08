//PROJECT NAME: Production
//CLASS NAME: IUpdateSeqNo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IUpdateSeqNo
	{
		(int? ReturnCode, string Infobar) UpdateSeqNoSp(string TableName,
		int? AltNum = null,
		string Infobar = null);
	}
}

