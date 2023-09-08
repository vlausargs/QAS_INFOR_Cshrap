//PROJECT NAME: Data
//CLASS NAME: ITHAApptcPreDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHAApptcPreDelete
	{
		(int? ReturnCode,
			string Infobar,
			string PromptMsg,
			string PromptButtons) THAApptcPreDeleteSp(
			Guid? PRowid,
			string Infobar,
			string PromptMsg,
			string PromptButtons);
	}
}

