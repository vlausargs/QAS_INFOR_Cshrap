//PROJECT NAME: Logistics
//CLASS NAME: AU_GetCoItemReleasePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class AU_GetCoItemReleasePrice : IAU_GetCoItemReleasePrice
	{
		readonly IApplicationDB appDB;
		
		public AU_GetCoItemReleasePrice(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? PriceConv,
			string Infobar) AU_GetCoItemReleasePriceSp(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			decimal? PriceConv,
			string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			CoReleaseType _CoRelease = CoRelease;
			CostPrcType _PriceConv = PriceConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "AU_GetCoItemReleasePriceSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRelease", _CoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PriceConv = _PriceConv;
				Infobar = _Infobar;
				
				return (Severity, PriceConv, Infobar);
			}
		}
	}
}
