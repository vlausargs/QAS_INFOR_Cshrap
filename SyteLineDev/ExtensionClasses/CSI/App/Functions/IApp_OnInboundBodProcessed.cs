//PROJECT NAME: Data
//CLASS NAME: IApp_OnInboundBodProcessed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_OnInboundBodProcessed
	{
		int? App_OnInboundBodProcessedSp(
			string bodNoun,
			string bodVerb,
			string bodXml,
			int? success,
			string failureMessage);
	}
}

