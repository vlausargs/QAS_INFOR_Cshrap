//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroTransPostValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroTransPostValidate
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroTransPostValidateSp(
			string iMode,
			string iTable,
			string iPriceField,
			string iSroNum,
			int? iSroLine,
			int? iSroOper,
			DateTime? iTransDate,
			DateTime? iPostDate,
			string iWhse,
			decimal? iPrice,
			string iPartnerID,
			string iDept,
			string iBillCode,
			string Infobar);
	}
}

