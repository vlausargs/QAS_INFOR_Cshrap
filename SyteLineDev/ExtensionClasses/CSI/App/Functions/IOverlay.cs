//PROJECT NAME: Data
//CLASS NAME: IOverlay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IOverlay
	{
		string OverlayFn(
			string target,
			int? pos,
			int? len,
			string source);
	}
}

