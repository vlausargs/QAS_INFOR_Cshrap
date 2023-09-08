//PROJECT NAME: Data
//CLASS NAME: XmlToJson.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class XmlToJson : IXmlToJson
	{
		readonly IApplicationDB appDB;
		
		public XmlToJson(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string XmlToJsonFn(
			SqlXmlType XmlData)
		{
			SqlXmlType _XmlData = XmlData;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[XmlToJson](@XmlData)";
				
				appDB.AddCommandParameter(cmd, "XmlData", _XmlData, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
