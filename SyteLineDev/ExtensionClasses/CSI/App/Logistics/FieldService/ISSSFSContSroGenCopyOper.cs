//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSContSROGenCopyOper.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContSROGenCopyOper
	{
		(int? ReturnCode,
			int? NewSroOper,
			string Infobar) SSSFSContSROGenCopyOperSp(
			string Contract,
			int? MntSeq,
			string SROCopyLevel,
			string SroCopyTransFrom,
			string ToSroNum,
			int? ToSroLine,
			string TemplateSroNum,
			int? TemplateSroLine,
			DateTime? Date,
			string LeadPartner,
			int? NewSroOper,
			string Infobar,
			int? KeepOperNums = 0,
			int? UseSroWhse = 0,
			string iSroCopyTransTo = "P");
	}
}

