//PROJECT NAME: Finance
//CLASS NAME: IApiSernumvi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IApiSernumvi
	{
		(int? ReturnCode,
			int? PReturnCode,
			string Infobatty) ApiSernumviSp(
			string PType,
			string PWhseType,
			string PWhse,
			string PItem,
			string PLoc,
			string PLot = null,
			string PTrnNum = null,
			int? PTrnLine = null,
			string PStat = null,
			decimal? PRsvdNum = null,
			string PSerNum = null,
			string PRefType = null,
			string PRefNum = null,
			int? PRefLine = null,
			int? PRefRelease = null,
			string PDoNum = null,
			int? PDoLine = null,
			int? PReturnCode = null,
			string Infobatty = null,
			string PImportDocId = null);
	}
}

