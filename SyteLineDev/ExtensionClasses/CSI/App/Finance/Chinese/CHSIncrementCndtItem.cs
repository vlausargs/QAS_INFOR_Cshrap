//PROJECT NAME: CSIChineseFinancials
//CLASS NAME: CHSIncrementCndtItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.Chinese
{
	public interface ICHSIncrementCndtItem
	{
		int CHSIncrementCndtItemSp(string Sym_group,
		                           string Sym_User,
		                           string DataType,
		                           ref int? Cndtitem);
	}
	
	public class CHSIncrementCndtItem : ICHSIncrementCndtItem
	{
		readonly IApplicationDB appDB;
		
		public CHSIncrementCndtItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CHSIncrementCndtItemSp(string Sym_group,
		                                  string Sym_User,
		                                  string DataType,
		                                  ref int? Cndtitem)
		{
			GroupnameType _Sym_group = Sym_group;
			UsernameType _Sym_User = Sym_User;
			DeTypeType _DataType = DataType;
			GenericIntType _Cndtitem = Cndtitem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CHSIncrementCndtItemSp";
				
				appDB.AddCommandParameter(cmd, "Sym_group", _Sym_group, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sym_User", _Sym_User, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Cndtitem", _Cndtitem, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Cndtitem = _Cndtitem;
				
				return Severity;
			}
		}
	}
}
