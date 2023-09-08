//PROJECT NAME: Data
//CLASS NAME: IUDFExceptionMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUDFExceptionMsg
	{
		string UDFExceptionMsgFn(
			string CaughtMsg,
			string Template);
	}
}

