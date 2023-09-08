//PROJECT NAME: Logistics
//CLASS NAME: ICreateContactEmailCommunication.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICreateContactEmailCommunication
	{
		int? CreateContactEmailCommunicationSp(string Topic,
		string Type,
		string Note,
		string ShowContent,
		string Input,
		string ContactId,
		string EmailSubject);
	}
}

