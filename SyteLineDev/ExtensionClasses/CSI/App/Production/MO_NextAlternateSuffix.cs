//PROJECT NAME: Production
//CLASS NAME: MO_NextAlternateSuffix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class MO_NextAlternateSuffix : IMO_NextAlternateSuffix
	{
		readonly IApplicationDB appDB;
		
		
		public MO_NextAlternateSuffix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? Suffix) MO_NextAlternateSuffixSp(string Item,
		int? Suffix)
		{
			ItemType _Item = Item;
			SuffixType _Suffix = Suffix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MO_NextAlternateSuffixSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Suffix = _Suffix;
				
				return (Severity, Suffix);
			}
		}
	}
}
