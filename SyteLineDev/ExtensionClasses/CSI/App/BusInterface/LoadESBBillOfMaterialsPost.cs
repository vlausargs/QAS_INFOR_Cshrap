//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBBillOfMaterialsPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBBillOfMaterialsPost
	{
		int LoadESBBillOfMaterialsPostSp(string ParentItem,
		                                 ref string Infobar);
	}
	
	public class LoadESBBillOfMaterialsPost : ILoadESBBillOfMaterialsPost
	{
		readonly IApplicationDB appDB;
		
		public LoadESBBillOfMaterialsPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBBillOfMaterialsPostSp(string ParentItem,
		                                        ref string Infobar)
		{
			ItemType _ParentItem = ParentItem;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBBillOfMaterialsPostSp";
				
				appDB.AddCommandParameter(cmd, "ParentItem", _ParentItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
