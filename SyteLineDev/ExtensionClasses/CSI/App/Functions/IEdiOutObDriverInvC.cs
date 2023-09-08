//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriverInvC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriverInvC
	{
		(int? ReturnCode,
			string Infobar) EdiOutObDriverInvCSp(
			string PInvNum,
			string Infobar);
	}
}

