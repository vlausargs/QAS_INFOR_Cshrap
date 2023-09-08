//PROJECT NAME: CSIProjects
//CLASS NAME: PmatlUMValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IPmatlUMValid
	{
		int PmatlUMValidSp(string PItem,
		                   decimal? PMatlQty,
		                   ref string PUM,
		                   ref double? UomConvFactor,
		                   ref decimal? TQty,
		                   ref string Infobar);
	}
	
	public class PmatlUMValid : IPmatlUMValid
	{
		readonly IApplicationDB appDB;
		
		public PmatlUMValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PmatlUMValidSp(string PItem,
		                          decimal? PMatlQty,
		                          ref string PUM,
		                          ref double? UomConvFactor,
		                          ref decimal? TQty,
		                          ref string Infobar)
		{
			ItemType _PItem = PItem;
			QtyPerType _PMatlQty = PMatlQty;
			UMType _PUM = PUM;
			UMConvFactorType _UomConvFactor = UomConvFactor;
			QtyPerType _TQty = TQty;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmatlUMValidSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatlQty", _PMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UomConvFactor", _UomConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PUM = _PUM;
				UomConvFactor = _UomConvFactor;
				TQty = _TQty;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
