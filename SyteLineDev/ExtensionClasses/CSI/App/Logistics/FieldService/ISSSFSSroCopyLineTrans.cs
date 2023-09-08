//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroCopyLineTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroCopyLineTrans
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroCopyLineTransSp(
			string iSroCopyLevel,
			string iSroCopyCalledFrom,
			string iToSroNum,
			int? iToSroLine,
			string iTemplateSroNum,
			int? iTemplateSroLine,
			string Infobar,
			int? iUseSroWhse = 0);
	}
}

