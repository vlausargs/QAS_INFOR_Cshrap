//PROJECT NAME: Material
//CLASS NAME: PhytagsCountMethod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PhytagsCountMethod : IPhytagsCountMethod
	{
		readonly IApplicationDB appDB;
		
		
		public PhytagsCountMethod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string CountMethod,
		string Infobar) PhytagsCountMethodSp(string Whse,
		string CountMethod,
		string Infobar)
		{
			WhseType _Whse = Whse;
			PhytagsCountMethType _CountMethod = CountMethod;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhytagsCountMethodSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CountMethod", _CountMethod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CountMethod = _CountMethod;
				Infobar = _Infobar;
				
				return (Severity, CountMethod, Infobar);
			}
		}
	}
}
