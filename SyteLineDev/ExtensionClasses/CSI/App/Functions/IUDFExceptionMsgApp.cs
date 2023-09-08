//PROJECT NAME: Data
//CLASS NAME: IUDFExceptionMsgApp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IUDFExceptionMsgApp
	{
		string UDFExceptionMsgAppFn(
			string Infobar,
			string CaughtMsg,
			string Template);
	}
}

