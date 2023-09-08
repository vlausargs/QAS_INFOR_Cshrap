//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContSROGenCopyLines.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContSROGenCopyLines
	{
		(int? ReturnCode,
			int? SROLine,
			int? SROOper,
			string Infobar) SSSFSContSROGenCopyLinesSp(
			string Contract,
			string SROCopyLevel,
			string SroCopyTransFrom,
			int? MntSeq,
			string ToSroNum,
			string TemplateSroNum,
			DateTime? Date,
			string LeadPartner,
			int? SROLine,
			int? SROOper,
			string Infobar,
			int? KeepOperNums = 0,
			int? UseSroWhse = 0,
			string iSroCopyTransTo = "P");
	}
}

