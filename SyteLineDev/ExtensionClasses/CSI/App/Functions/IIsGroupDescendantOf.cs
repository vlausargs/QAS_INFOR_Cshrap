//PROJECT NAME: Data
//CLASS NAME: IIsGroupDescendantOf.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsGroupDescendantOf
	{
		int? IsGroupDescendantOfFn(
			string DescendantGroup,
			string GroupName);
	}
}

