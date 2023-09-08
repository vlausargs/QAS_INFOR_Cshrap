//PROJECT NAME: Data
//CLASS NAME: InvAdjC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class InvAdjC : IInvAdjC
	{
		readonly IApplicationDB appDB;
		
		public InvAdjC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) InvAdjCSp(
			string PCoNum,
			int? PCoLine,
			int? PCoRelease,
			decimal? PNewDisc,
			decimal? PNewPriceConv,
			decimal? PNewPrice,
			string Infobar)
		{
			CoNumType _PCoNum = PCoNum;
			CoLineType _PCoLine = PCoLine;
			CoReleaseType _PCoRelease = PCoRelease;
			LineDiscType _PNewDisc = PNewDisc;
			CostPrcType _PNewPriceConv = PNewPriceConv;
			CostPrcType _PNewPrice = PNewPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvAdjCSp";
				
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoLine", _PCoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoRelease", _PCoRelease, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewDisc", _PNewDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPriceConv", _PNewPriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewPrice", _PNewPrice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
