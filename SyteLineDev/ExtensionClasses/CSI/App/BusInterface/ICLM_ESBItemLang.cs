//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBItemLang.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBItemLang
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBItemLangSp(
			string item);
	}
}

