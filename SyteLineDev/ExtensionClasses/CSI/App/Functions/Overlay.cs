//PROJECT NAME: Data
//CLASS NAME: Overlay.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Overlay : IOverlay
	{
		readonly IApplicationDB appDB;
		
		public Overlay(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string OverlayFn(
			string target,
			int? pos,
			int? len,
			string source)
		{
			LongList _target = target;
			IntType _pos = pos;
			IntType _len = len;
			LongList _source = source;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[Overlay](@target, @pos, @len, @source)";
				
				appDB.AddCommandParameter(cmd, "target", _target, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pos", _pos, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "len", _len, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "source", _source, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
