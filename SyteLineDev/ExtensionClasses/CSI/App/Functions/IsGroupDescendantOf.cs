//PROJECT NAME: Data
//CLASS NAME: IsGroupDescendantOf.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class IsGroupDescendantOf : IIsGroupDescendantOf
	{
		readonly IApplicationDB appDB;
		
		public IsGroupDescendantOf(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? IsGroupDescendantOfFn(
			string DescendantGroup,
			string GroupName)
		{
			GroupnameType _DescendantGroup = DescendantGroup;
			GroupnameType _GroupName = GroupName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[IsGroupDescendantOf](@DescendantGroup, @GroupName)";
				
				appDB.AddCommandParameter(cmd, "DescendantGroup", _DescendantGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "GroupName", _GroupName, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<int?>(cmd);
				
				return Output;
			}
		}
	}
}
