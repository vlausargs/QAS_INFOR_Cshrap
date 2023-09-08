//PROJECT NAME: CSICodes
//CLASS NAME: UpdatePortalOrderLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IUpdatePortalOrderLine
	{
		int UpdatePortalOrderLineSp(string CoNum,
		                            short? CoLine,
		                            string UM,
		                            decimal? PriceConv,
		                            ref string Infobar);
	}
	
	public class UpdatePortalOrderLine : IUpdatePortalOrderLine
	{
		readonly IApplicationDB appDB;
		
		public UpdatePortalOrderLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int UpdatePortalOrderLineSp(string CoNum,
		                                   short? CoLine,
		                                   string UM,
		                                   decimal? PriceConv,
		                                   ref string Infobar)
		{
			CoNumType _CoNum = CoNum;
			CoLineType _CoLine = CoLine;
			UMType _UM = UM;
			CostPrcType _PriceConv = PriceConv;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdatePortalOrderLineSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
