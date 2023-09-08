//PROJECT NAME: Logistics
//CLASS NAME: GetCoLinePlanAndPriceParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IGetCoLinePlanAndPriceParms
	{
		(int? ReturnCode, byte? PostJour, string ApsParmApsmode, string MrpParmReqSrc, byte? CanDueNEProjected, byte? CanDueLTProjected, byte? SharedCustEnabled, byte? PUseAltPriceCalc) GetCoLinePlanAndPriceParmsSp(byte? PostJour,
		string Type,
		string Type1,
		string Object,
		string ParamSite,
		string ApsParmApsmode,
		string MrpParmReqSrc,
		byte? CanDueNEProjected,
		byte? CanDueLTProjected,
		byte? SharedCustEnabled,
		byte? PUseAltPriceCalc);
	}
	
	public class GetCoLinePlanAndPriceParms : IGetCoLinePlanAndPriceParms
	{
		readonly IApplicationDB appDB;
		
		public GetCoLinePlanAndPriceParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? PostJour, string ApsParmApsmode, string MrpParmReqSrc, byte? CanDueNEProjected, byte? CanDueLTProjected, byte? SharedCustEnabled, byte? PUseAltPriceCalc) GetCoLinePlanAndPriceParmsSp(byte? PostJour,
		string Type,
		string Type1,
		string Object,
		string ParamSite,
		string ApsParmApsmode,
		string MrpParmReqSrc,
		byte? CanDueNEProjected,
		byte? CanDueLTProjected,
		byte? SharedCustEnabled,
		byte? PUseAltPriceCalc)
		{
			ListYesNoType _PostJour = PostJour;
			StringType _Type = Type;
			StringType _Type1 = Type1;
			StringType _Object = Object;
			SiteType _ParamSite = ParamSite;
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			MrpReqSrcType _MrpParmReqSrc = MrpParmReqSrc;
			ListYesNoType _CanDueNEProjected = CanDueNEProjected;
			ListYesNoType _CanDueLTProjected = CanDueLTProjected;
			ListYesNoType _SharedCustEnabled = SharedCustEnabled;
			ListYesNoType _PUseAltPriceCalc = PUseAltPriceCalc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCoLinePlanAndPriceParmsSp";
				
				appDB.AddCommandParameter(cmd, "PostJour", _PostJour, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type1", _Type1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Object", _Object, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamSite", _ParamSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MrpParmReqSrc", _MrpParmReqSrc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDueNEProjected", _CanDueNEProjected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDueLTProjected", _CanDueLTProjected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SharedCustEnabled", _SharedCustEnabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PUseAltPriceCalc", _PUseAltPriceCalc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PostJour = _PostJour;
				ApsParmApsmode = _ApsParmApsmode;
				MrpParmReqSrc = _MrpParmReqSrc;
				CanDueNEProjected = _CanDueNEProjected;
				CanDueLTProjected = _CanDueLTProjected;
				SharedCustEnabled = _SharedCustEnabled;
				PUseAltPriceCalc = _PUseAltPriceCalc;
				
				return (Severity, PostJour, ApsParmApsmode, MrpParmReqSrc, CanDueNEProjected, CanDueLTProjected, SharedCustEnabled, PUseAltPriceCalc);
			}
		}
	}
}
