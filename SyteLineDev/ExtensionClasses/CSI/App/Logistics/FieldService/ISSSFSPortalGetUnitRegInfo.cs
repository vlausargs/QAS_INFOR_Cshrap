//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSPortalGetUnitRegInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSPortalGetUnitRegInfo
	{
		(int? ReturnCode,
			string Email,
			string SerNum,
			string Infobar) SSSFSPortalGetUnitRegInfoSp(
			decimal? TransNum,
			string Email,
			string SerNum,
			string Infobar);
	}
}

