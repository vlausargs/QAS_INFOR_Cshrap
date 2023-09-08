//PROJECT NAME: Production
//CLASS NAME: IApsMessageString.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsMessageString
	{
		string ApsMessageStringFn(
			int? MsgID,
			string Parm1,
			string Parm2,
			string Parm3,
			string Parm4);
	}
}

