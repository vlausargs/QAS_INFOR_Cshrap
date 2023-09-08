//PROJECT NAME: Employee
//CLASS NAME: IMessageToPrtrxToPrintPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Employee
{
	public interface IMessageToPrtrxToPrintPost
	{
		(int? ReturnCode, string Infobar) MessageToPrtrxToPrintPostSp(Guid? pSessionID,
		Guid? pPrtrxRowPointer,
		string pMessage,
		string Infobar);
	}
}

