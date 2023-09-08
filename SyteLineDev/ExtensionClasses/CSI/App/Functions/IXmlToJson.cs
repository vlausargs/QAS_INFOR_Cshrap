//PROJECT NAME: Data
//CLASS NAME: IXmlToJson.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IXmlToJson
	{
		string XmlToJsonFn(
			SqlXmlType XmlData);
	}
}

