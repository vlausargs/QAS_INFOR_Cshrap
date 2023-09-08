//PROJECT NAME: Data
//CLASS NAME: PSVal6.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PSVal6 : IPSVal6
	{
		readonly IApplicationDB appDB;
		
		public PSVal6(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PSVal6Sp(
			string PSNum,
			string PSItem,
			string Infobar)
		{
			PsNumType _PSNum = PSNum;
			ItemType _PSItem = PSItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PSVal6Sp";
				
				appDB.AddCommandParameter(cmd, "PSNum", _PSNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSItem", _PSItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
