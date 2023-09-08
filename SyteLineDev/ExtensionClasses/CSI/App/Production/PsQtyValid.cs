//PROJECT NAME: Production
//CLASS NAME: PsQtyValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IPsQtyValid
	{
		(int? ReturnCode, string Infobar) PsQtyValidSp(decimal? Qty,
		string PItem,
		byte? CmplFlag = (byte)0,
		byte? ScrpFlag = (byte)0,
		string Infobar = null);
	}
	
	public class PsQtyValid : IPsQtyValid
	{
		readonly IApplicationDB appDB;
		
		public PsQtyValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PsQtyValidSp(decimal? Qty,
		string PItem,
		byte? CmplFlag = (byte)0,
		byte? ScrpFlag = (byte)0,
		string Infobar = null)
		{
			QtyUnitType _Qty = Qty;
			ItemType _PItem = PItem;
			ListYesNoType _CmplFlag = CmplFlag;
			ListYesNoType _ScrpFlag = ScrpFlag;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PsQtyValidSp";
				
				appDB.AddCommandParameter(cmd, "Qty", _Qty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CmplFlag", _CmplFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ScrpFlag", _ScrpFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
