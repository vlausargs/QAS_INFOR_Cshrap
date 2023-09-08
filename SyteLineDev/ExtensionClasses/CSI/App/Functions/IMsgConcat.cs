//PROJECT NAME: Data
//CLASS NAME: IMsgConcat.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMsgConcat
	{
		(int? ReturnCode,
			string Infobar) MsgConcatSp(
			string Infobar,
			string NextMessage);
	}
}

