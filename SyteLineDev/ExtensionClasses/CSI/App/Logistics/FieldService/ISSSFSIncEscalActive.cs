//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSIncEscalActive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSIncEscalActive
	{
		(int? ReturnCode,
			string Infobar) SSSFSIncEscalActiveSp(
			string IncNum,
			int? Seq,
			string Infobar);
	}
}

