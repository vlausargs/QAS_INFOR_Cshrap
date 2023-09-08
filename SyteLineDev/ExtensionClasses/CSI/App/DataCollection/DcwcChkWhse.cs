//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcwcChkWhse.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcwcChkWhse
	{
		int DcwcChkWhseSp(string DCitemItem,
		                  string DcWhse,
		                  ref string Infobar);
	}
	
	public class DcwcChkWhse : IDcwcChkWhse
	{
		readonly IApplicationDB appDB;
		
		public DcwcChkWhse(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int DcwcChkWhseSp(string DCitemItem,
		                         string DcWhse,
		                         ref string Infobar)
		{
			ItemType _DCitemItem = DCitemItem;
			WhseType _DcWhse = DcWhse;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcwcChkWhseSp";
				
				appDB.AddCommandParameter(cmd, "DCitemItem", _DCitemItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DcWhse", _DcWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
