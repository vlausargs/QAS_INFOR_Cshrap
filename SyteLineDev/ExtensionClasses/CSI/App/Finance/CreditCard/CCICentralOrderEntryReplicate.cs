//PROJECT NAME: CSICCI
//CLASS NAME: CCICentralOrderEntryReplicate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Finance.CreditCard
{
	public interface ICCICentralOrderEntryReplicate
	{
		int CCICentralOrderEntryReplicateSp(Guid? CCIRowPointer,
		                                    string CoNum,
		                                    string ToSite,
		                                    ref string Infobar);
	}
	
	public class CCICentralOrderEntryReplicate : ICCICentralOrderEntryReplicate
	{
		readonly IApplicationDB appDB;
		
		public CCICentralOrderEntryReplicate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int CCICentralOrderEntryReplicateSp(Guid? CCIRowPointer,
		                                           string CoNum,
		                                           string ToSite,
		                                           ref string Infobar)
		{
			RowPointerType _CCIRowPointer = CCIRowPointer;
			CoNumType _CoNum = CoNum;
			SiteType _ToSite = ToSite;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CCICentralOrderEntryReplicateSp";
				
				appDB.AddCommandParameter(cmd, "CCIRowPointer", _CCIRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
