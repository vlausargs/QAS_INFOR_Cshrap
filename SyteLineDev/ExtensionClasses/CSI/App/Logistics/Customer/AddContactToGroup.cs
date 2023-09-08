//PROJECT NAME: Logistics
//CLASS NAME: AddContactToGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AddContactToGroup : IAddContactToGroup
	{
		readonly IApplicationDB appDB;
		
		
		public AddContactToGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? AddContactToGroupSp(string ContactId,
		string GroupName,
		string TableName)
		{
			ContactIDType _ContactId = ContactId;
			GroupnameType _GroupName = GroupName;
			StringType _TableName = TableName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AddContactToGroupSp";
				
				appDB.AddCommandParameter(cmd, "ContactId", _ContactId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupName", _GroupName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
