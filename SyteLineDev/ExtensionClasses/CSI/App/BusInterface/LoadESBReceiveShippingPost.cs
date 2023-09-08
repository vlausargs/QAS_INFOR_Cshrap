//PROJECT NAME: CSIBusInterface
//CLASS NAME: LoadESBReceiveShippingPost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.BusInterface
{
	public interface ILoadESBReceiveShippingPost
	{
		int LoadESBReceiveShippingPostSp(string DocumentIDName,
		                                 string BODNOUN,
		                                 string BODVERB,
		                                 string DocumentID,
		                                 string PurchaseOrderRef,
		                                 string SalesOrderRef,
		                                 string Status,
		                                 ref string InfoBar);
	}
	
	public class LoadESBReceiveShippingPost : ILoadESBReceiveShippingPost
	{
		readonly IApplicationDB appDB;
		
		public LoadESBReceiveShippingPost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int LoadESBReceiveShippingPostSp(string DocumentIDName,
		                                        string BODNOUN,
		                                        string BODVERB,
		                                        string DocumentID,
		                                        string PurchaseOrderRef,
		                                        string SalesOrderRef,
		                                        string Status,
		                                        ref string InfoBar)
		{
			StringType _DocumentIDName = DocumentIDName;
			StringType _BODNOUN = BODNOUN;
			StringType _BODVERB = BODVERB;
			StringType _DocumentID = DocumentID;
			StringType _PurchaseOrderRef = PurchaseOrderRef;
			StringType _SalesOrderRef = SalesOrderRef;
			StringType _Status = Status;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LoadESBReceiveShippingPostSp";
				
				appDB.AddCommandParameter(cmd, "DocumentIDName", _DocumentIDName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODNOUN", _BODNOUN, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BODVERB", _BODVERB, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentID", _DocumentID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurchaseOrderRef", _PurchaseOrderRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SalesOrderRef", _SalesOrderRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Status", _Status, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
