//PROJECT NAME: CSIAdmin
//CLASS NAME: MonitoredResource_NotifySubscribers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Admin
{
	public interface IMonitoredResource_NotifySubscribers
	{
		int MonitoredResource_NotifySubscribersSp(string PublicationName,
		                                          Guid? MRRowPointer,
		                                          int? ServiceStatus,
		                                          ref string Infobar);
	}
	
	public class MonitoredResource_NotifySubscribers : IMonitoredResource_NotifySubscribers
	{
		IApplicationDB appDB;
		
		public MonitoredResource_NotifySubscribers(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int MonitoredResource_NotifySubscribersSp(string PublicationName,
		                                                 Guid? MRRowPointer,
		                                                 int? ServiceStatus,
		                                                 ref string Infobar)
		{
			NameType _PublicationName = PublicationName;
			RowPointerType _MRRowPointer = MRRowPointer;
			IntType _ServiceStatus = ServiceStatus;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MonitoredResource_NotifySubscribersSp";
				
				appDB.AddCommandParameter(cmd, "PublicationName", _PublicationName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MRRowPointer", _MRRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ServiceStatus", _ServiceStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
