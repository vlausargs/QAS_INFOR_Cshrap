//PROJECT NAME: Data
//CLASS NAME: BreakList.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class BreakList : IBreakList
	{
		readonly IApplicationDB appDB;
		
		public BreakList(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Var1,
			string Var2,
			string Var3,
			string Var4,
			string Var5,
			string Var6,
			string Var7,
			string Var8,
			string Var9,
			string Var10,
			string Var11,
			string Var12,
			string Var13,
			string Var14,
			string Var15) BreakListSp(
			string List,
			string Delimeter = ",",
			string Var1 = null,
			string Var2 = null,
			string Var3 = null,
			string Var4 = null,
			string Var5 = null,
			string Var6 = null,
			string Var7 = null,
			string Var8 = null,
			string Var9 = null,
			string Var10 = null,
			string Var11 = null,
			string Var12 = null,
			string Var13 = null,
			string Var14 = null,
			string Var15 = null)
		{
			LongList _List = List;
			LongList _Delimeter = Delimeter;
			LongList _Var1 = Var1;
			LongList _Var2 = Var2;
			LongList _Var3 = Var3;
			LongList _Var4 = Var4;
			LongList _Var5 = Var5;
			LongList _Var6 = Var6;
			LongList _Var7 = Var7;
			LongList _Var8 = Var8;
			LongList _Var9 = Var9;
			LongList _Var10 = Var10;
			LongList _Var11 = Var11;
			LongList _Var12 = Var12;
			LongList _Var13 = Var13;
			LongList _Var14 = Var14;
			LongList _Var15 = Var15;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "BreakListSp";
				
				appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Delimeter", _Delimeter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Var1", _Var1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var2", _Var2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var3", _Var3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var4", _Var4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var5", _Var5, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var6", _Var6, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var7", _Var7, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var8", _Var8, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var9", _Var9, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var10", _Var10, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var11", _Var11, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var12", _Var12, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var13", _Var13, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var14", _Var14, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Var15", _Var15, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Var1 = _Var1;
				Var2 = _Var2;
				Var3 = _Var3;
				Var4 = _Var4;
				Var5 = _Var5;
				Var6 = _Var6;
				Var7 = _Var7;
				Var8 = _Var8;
				Var9 = _Var9;
				Var10 = _Var10;
				Var11 = _Var11;
				Var12 = _Var12;
				Var13 = _Var13;
				Var14 = _Var14;
				Var15 = _Var15;
				
				return (Severity, Var1, Var2, Var3, Var4, Var5, Var6, Var7, Var8, Var9, Var10, Var11, Var12, Var13, Var14, Var15);
			}
		}
	}
}
