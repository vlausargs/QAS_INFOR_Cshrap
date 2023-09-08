//PROJECT NAME: Data
//CLASS NAME: SetNextInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class SetNextInvNum : ISetNextInvNum
	{
		readonly IApplicationDB appDB;
		
		public SetNextInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string NewInvNum,
			string Infobar) SetNextInvNumSp(
			string Category,
			DateTime? InvDate,
			string TableName,
			string ColumnName,
			int? KeyLength,
			string Type,
			string NewInvNum,
			string Action,
			string Infobar)
		{
			InvCategoryType _Category = Category;
			DateType _InvDate = InvDate;
			StringType _TableName = TableName;
			StringType _ColumnName = ColumnName;
			IntType _KeyLength = KeyLength;
			ArinvTypeType _Type = Type;
			InvNumType _NewInvNum = NewInvNum;
			StringType _Action = Action;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SetNextInvNumSp";
				
				appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TableName", _TableName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ColumnName", _ColumnName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "KeyLength", _KeyLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewInvNum", _NewInvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NewInvNum = _NewInvNum;
				Infobar = _Infobar;
				
				return (Severity, NewInvNum, Infobar);
			}
		}
	}
}
