//PROJECT NAME: CSIMaterial
//CLASS NAME: PhyinvPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IPhyinvPost
	{
		(int? ReturnCode, int? Counter, string Infobar) PhyinvPostSp(string Whse,
		byte? ReturnIfMissing = (byte)1,
		int? Counter = null,
		string Infobar = null);
	}
	
	public class PhyinvPost : IPhyinvPost
	{
		readonly IApplicationDB appDB;
		
		public PhyinvPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Counter, string Infobar) PhyinvPostSp(string Whse,
		byte? ReturnIfMissing = (byte)1,
		int? Counter = null,
		string Infobar = null)
		{
			WhseType _Whse = Whse;
			ListYesNoType _ReturnIfMissing = ReturnIfMissing;
			IntType _Counter = Counter;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhyinvPostSp";
				
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnIfMissing", _ReturnIfMissing, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Counter", _Counter, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Counter = _Counter;
				Infobar = _Infobar;
				
				return (Severity, Counter, Infobar);
			}
		}
	}
}
