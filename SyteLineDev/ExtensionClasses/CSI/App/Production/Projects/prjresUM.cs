//PROJECT NAME: CSIProjects
//CLASS NAME: prjresUM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IprjresUM
	{
		int prjresUMSp(string PItem,
		               string POldItem,
		               string PUM,
		               string POldUM,
		               string PProjNum,
		               int? PTaskNum,
		               int? PSeq,
		               byte? PAddMode,
		               decimal? PMatlQty,
		               ref decimal? PCost,
		               ref decimal? PMatlCost,
		               ref decimal? PLbrCost,
		               ref decimal? PFovhdCost,
		               ref decimal? PVovhdCost,
		               ref decimal? POutCost,
		               ref string Infobar);
	}
	
	public class prjresUM : IprjresUM
	{
		readonly IApplicationDB appDB;
		
		public prjresUM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int prjresUMSp(string PItem,
		                      string POldItem,
		                      string PUM,
		                      string POldUM,
		                      string PProjNum,
		                      int? PTaskNum,
		                      int? PSeq,
		                      byte? PAddMode,
		                      decimal? PMatlQty,
		                      ref decimal? PCost,
		                      ref decimal? PMatlCost,
		                      ref decimal? PLbrCost,
		                      ref decimal? PFovhdCost,
		                      ref decimal? PVovhdCost,
		                      ref decimal? POutCost,
		                      ref string Infobar)
		{
			ItemType _PItem = PItem;
			ItemType _POldItem = POldItem;
			UMType _PUM = PUM;
			UMType _POldUM = POldUM;
			ProjNumType _PProjNum = PProjNum;
			TaskNumType _PTaskNum = PTaskNum;
			ProjmatlSeqType _PSeq = PSeq;
			FlagNyType _PAddMode = PAddMode;
			QtyPerType _PMatlQty = PMatlQty;
			CostPrcType _PCost = PCost;
			CostPrcType _PMatlCost = PMatlCost;
			CostPrcType _PLbrCost = PLbrCost;
			CostPrcType _PFovhdCost = PFovhdCost;
			CostPrcType _PVovhdCost = PVovhdCost;
			CostPrcType _POutCost = POutCost;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "prjresUMSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldItem", _POldItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POldUM", _POldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PProjNum", _PProjNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaskNum", _PTaskNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSeq", _PSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAddMode", _PAddMode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMatlQty", _PMatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCost", _PCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMatlCost", _PMatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLbrCost", _PLbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PFovhdCost", _PFovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PVovhdCost", _PVovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POutCost", _POutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PCost = _PCost;
				PMatlCost = _PMatlCost;
				PLbrCost = _PLbrCost;
				PFovhdCost = _PFovhdCost;
				PVovhdCost = _PVovhdCost;
				POutCost = _POutCost;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
