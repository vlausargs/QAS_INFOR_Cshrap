//PROJECT NAME: Data
//CLASS NAME: IPoChange1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPoChange1
	{
		(int? ReturnCode,
			int? PoChangePrompt1User,
			string Infobar) PoChange1Sp(
			string PoNum,
			string PoStatus,
			int? PoChangePrompt1User,
			string Infobar);
	}
}

