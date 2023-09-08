//PROJECT NAME: CSICodes
//CLASS NAME: PortalUpdateOrderLineQuantities.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Codes
{
	public interface IPortalUpdateOrderLineQuantities
	{
		(int? ReturnCode, string Infobar) PortalUpdateOrderLineQuantitiesSp(string CoNum,
		string CoLineList = null,
		string QtyOrderedConvList = null,
		string Infobar = null);
	}
	
	public class PortalUpdateOrderLineQuantities : IPortalUpdateOrderLineQuantities
	{
		readonly IApplicationDB appDB;
		
		public PortalUpdateOrderLineQuantities(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PortalUpdateOrderLineQuantitiesSp(string CoNum,
		string CoLineList = null,
		string QtyOrderedConvList = null,
		string Infobar = null)
		{
			CoNumType _CoNum = CoNum;
			StringType _CoLineList = CoLineList;
			StringType _QtyOrderedConvList = QtyOrderedConvList;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PortalUpdateOrderLineQuantitiesSp";
				
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoLineList", _CoLineList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConvList", _QtyOrderedConvList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
