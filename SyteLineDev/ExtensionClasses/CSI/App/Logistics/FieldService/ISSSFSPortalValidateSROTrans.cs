//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPortalValidateSROTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPortalValidateSROTrans
	{
		(int? ReturnCode,
			string Infobar) SSSFSPortalValidateSROTransSp(
			string SroNum,
			int? SroLine,
			int? SroOper,
			string PartnerID,
			DateTime? TransDate,
			string CustNum,
			string CustSeq,
			string Username,
			string Infobar);
	}
}

