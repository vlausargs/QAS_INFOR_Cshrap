//PROJECT NAME: Logistics
//CLASS NAME: GetCOLineParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCOLineParms : IGetCOLineParms
	{
		readonly IApplicationDB appDB;
		
		
		public GetCOLineParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ApsParmApsmode,
		string MrpParmReqSrc,
		int? CanDueNEProjected,
		int? CanDueLTProjected,
		int? SharedCustEnabled) GetCOLineParmsSp(string Type,
		string Type1,
		string Object,
		string ParamSite,
		string ApsParmApsmode,
		string MrpParmReqSrc,
		int? CanDueNEProjected,
		int? CanDueLTProjected,
		int? SharedCustEnabled)
		{
			StringType _Type = Type;
			StringType _Type1 = Type1;
			StringType _Object = Object;
			SiteType _ParamSite = ParamSite;
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			MrpReqSrcType _MrpParmReqSrc = MrpParmReqSrc;
			ListYesNoType _CanDueNEProjected = CanDueNEProjected;
			ListYesNoType _CanDueLTProjected = CanDueLTProjected;
			ListYesNoType _SharedCustEnabled = SharedCustEnabled;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCOLineParmsSp";
				
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type1", _Type1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Object", _Object, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamSite", _ParamSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MrpParmReqSrc", _MrpParmReqSrc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDueNEProjected", _CanDueNEProjected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDueLTProjected", _CanDueLTProjected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SharedCustEnabled", _SharedCustEnabled, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ApsParmApsmode = _ApsParmApsmode;
				MrpParmReqSrc = _MrpParmReqSrc;
				CanDueNEProjected = _CanDueNEProjected;
				CanDueLTProjected = _CanDueLTProjected;
				SharedCustEnabled = _SharedCustEnabled;
				
				return (Severity, ApsParmApsmode, MrpParmReqSrc, CanDueNEProjected, CanDueLTProjected, SharedCustEnabled);
			}
		}
	}
}
