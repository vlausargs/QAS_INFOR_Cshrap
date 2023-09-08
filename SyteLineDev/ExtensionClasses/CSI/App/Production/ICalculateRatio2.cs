//PROJECT NAME: Production
//CLASS NAME: ICalculateRatio2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICalculateRatio2
	{
		(int? ReturnCode, int? PRatio2,
		string Infobar) CalculateRatio2Sp(string PJob,
		int? PSuffix,
		string PItem,
		int? POldRatio2,
		int? PRatio2,
		string Infobar);
	}
}

