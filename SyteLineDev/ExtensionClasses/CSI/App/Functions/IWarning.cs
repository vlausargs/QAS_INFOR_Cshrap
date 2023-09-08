//PROJECT NAME: Data
//CLASS NAME: IWarning.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IWarning
	{
		int? WarningSp(
			string Infobar);
	}
}

