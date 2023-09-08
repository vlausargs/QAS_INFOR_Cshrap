//PROJECT NAME: Data
//CLASS NAME: IErrorMessageCat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IErrorMessageCat
	{
		(int? ReturnCode,
			string MsgCat) ErrorMessageCatSp(
			string Msg1 = null,
			string Msg2 = null,
			string Msg3 = null,
			string Msg4 = null,
			string Msg5 = null,
			string Msg6 = null,
			string Msg7 = null,
			string Msg8 = null,
			string Msg9 = null,
			string Msg10 = null,
			string MsgCat = null);
	}
}

