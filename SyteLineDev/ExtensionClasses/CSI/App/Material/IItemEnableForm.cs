//PROJECT NAME: Material
//CLASS NAME: IItemEnableForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemEnableForm
	{
		(int? ReturnCode, int? use_wholesale_price,
		int? use_backflush) ItemEnableFormSp(int? use_wholesale_price,
		int? use_backflush,
		string PSite = null);
	}
}

