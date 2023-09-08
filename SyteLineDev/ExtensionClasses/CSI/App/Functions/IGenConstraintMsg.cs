//PROJECT NAME: Data
//CLASS NAME: IGenConstraintMsg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGenConstraintMsg
	{
		(int? ReturnCode,
			string Infobar) GenConstraintMsgSp(
			string TableFilter = null,
			string MessageLanguage = null,
			int? DeleteExistingMsg = 0,
			string Infobar = null);
	}
}

