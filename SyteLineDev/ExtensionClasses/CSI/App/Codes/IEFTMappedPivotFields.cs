//PROJECT NAME: Codes
//CLASS NAME: IEFTMappedPivotFields.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IEFTMappedPivotFields
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string InfoBar) EFTMappedPivotFieldsSp(string FileName,
		string ChildSequence,
		string Status,
		string RefType,
		string RefObject,
		string FilterString,
		string InfoBar);
	}
}

