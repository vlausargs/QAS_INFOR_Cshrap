//PROJECT NAME: Data
//CLASS NAME: IEdiOutObDriverAsnC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutObDriverAsnC
	{
		(int? ReturnCode,
			string Infobar) EdiOutObDriverAsnCSp(
			string PDoNum,
			string Infobar);
	}
}

