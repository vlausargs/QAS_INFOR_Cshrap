//PROJECT NAME: Data
//CLASS NAME: NextInvNum.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class NextInvNum : INextInvNum
	{
		readonly IApplicationDB appDB;
		
		public NextInvNum(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InvNum,
			string Infobar) NextInvNumSp(
			string Custnum,
			DateTime? InvDate = null,
			string Type = null,
			string InvNum = null,
			string Action = null,
			string Infobar = null,
			string Category = null)
		{
			CustNumType _Custnum = Custnum;
			DateType _InvDate = InvDate;
			ArinvTypeType _Type = Type;
			InvNumType _InvNum = InvNum;
			StringType _Action = Action;
			InfobarType _Infobar = Infobar;
			InvCategoryType _Category = Category;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "NextInvNumSp";
				
				appDB.AddCommandParameter(cmd, "Custnum", _Custnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Category", _Category, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvNum = _InvNum;
				Infobar = _Infobar;
				
				return (Severity, InvNum, Infobar);
			}
		}
	}
}
