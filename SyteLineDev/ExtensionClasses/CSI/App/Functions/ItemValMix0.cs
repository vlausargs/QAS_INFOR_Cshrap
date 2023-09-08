//PROJECT NAME: Data
//CLASS NAME: ItemValMix0.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemValMix0 : IItemValMix0
	{
		readonly IApplicationDB appDB;
		
		public ItemValMix0(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) ItemValMix0Sp(
			string PProdMix,
			int? PPhantomDo = 0,
			string Infobar = null)
		{
			ProdMixType _PProdMix = PProdMix;
			ListYesNoType _PPhantomDo = PPhantomDo;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemValMix0Sp";
				
				appDB.AddCommandParameter(cmd, "PProdMix", _PProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPhantomDo", _PPhantomDo, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
