//PROJECT NAME: Production
//CLASS NAME: IPP_InsertMaterialUsage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_InsertMaterialUsage
	{
		int? PP_InsertMaterialUsageSp(string Job = null,
		int? Suffix = null,
		int? Oper_num = null,
		int? Sequence = null,
		string Item = null,
		decimal? Length = null,
		decimal? Width = null,
		decimal? Height = null,
		int? Number_of_joints = null,
		int? Use_for_matching_criteria = null);
	}
}

