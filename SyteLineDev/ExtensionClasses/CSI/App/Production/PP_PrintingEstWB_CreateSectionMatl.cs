//PROJECT NAME: Production
//CLASS NAME: PP_PrintingEstWB_CreateSectionMatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class PP_PrintingEstWB_CreateSectionMatl : IPP_PrintingEstWB_CreateSectionMatl
	{
		readonly IApplicationDB appDB;
		
		
		public PP_PrintingEstWB_CreateSectionMatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PP_PrintingEstWB_CreateSectionMatlSp(string Job,
		int? Suffix,
		string Item,
		decimal? Quantity,
		string Infobar)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			ItemType _Item = Item;
			QtyUnitType _Quantity = Quantity;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_PrintingEstWB_CreateSectionMatlSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Quantity", _Quantity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
