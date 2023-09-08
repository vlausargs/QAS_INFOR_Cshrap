//PROJECT NAME: Data
//CLASS NAME: IEdiGenFindCo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiGenFindCo
	{
		(int? ReturnCode,
			string PCoNum,
			Guid? PCoRecid,
			int? PNewCoFlag,
			int? PError,
			string Infobar) EdiGenFindCoSp(
			string PCustNum,
			int? PCustSeq,
			string PCustPo,
			string POrdType,
			string PEdiCoNum,
			int? PCreateCo,
			string PTrxCode,
			string PCoNum,
			Guid? PCoRecid,
			int? PNewCoFlag,
			int? PError,
			string Infobar,
			string Site = null);
	}
}

