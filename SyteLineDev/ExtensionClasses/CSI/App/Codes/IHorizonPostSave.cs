//PROJECT NAME: Codes
//CLASS NAME: IHorizonPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IHorizonPostSave
	{
		(int? ReturnCode, string Infobar) HorizonPostSaveSp(string Infobar);
	}
}

