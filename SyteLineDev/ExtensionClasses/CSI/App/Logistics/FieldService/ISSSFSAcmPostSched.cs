//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSAcmPostSched.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSAcmPostSched
	{
		(int? ReturnCode, string Infobar) SSSFSAcmPostSchedSp(string AcmNum,
		int? AcmSeq,
		DateTime? PostDate,
		string Infobar);
	}
}

