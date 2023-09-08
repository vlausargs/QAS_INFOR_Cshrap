//PROJECT NAME: Logistics
//CLASS NAME: ICreateSourceCommunication.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateSourceCommunication
	{
		int? CreateSourceCommunicationSp(string SourceType,
		string SourceKey,
		string Topic,
		string Type,
		string Note,
		int? ShowContent,
		string Input);
	}
}

