//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetCustCurrCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetCustCurrCode
	{
		(int? ReturnCode,
			string PCurrCode,
			string Infobar) SSSFSGetCustCurrCodeSp(
			string PCustNum,
			string PCurrCode,
			string Infobar);

		string SSSFSGetCustCurrCodeFn(
			string SroNum,
			int? SroLine,
			int? SroOper = null);
	}
}

