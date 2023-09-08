//PROJECT NAME: Data
//CLASS NAME: ICmpltBi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICmpltBi
	{
		(int? ReturnCode,
			string Infobar) CmpltBiSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string Infobar);
	}
}

