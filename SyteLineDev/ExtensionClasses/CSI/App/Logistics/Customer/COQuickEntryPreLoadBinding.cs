//PROJECT NAME: CSICustomer
//CLASS NAME: COQuickEntryPreLoadBinding.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICOQuickEntryPreLoadBinding
	{
		int COQuickEntryPreLoadBindingSp(ref short? DuePeriod,
		                                 string CanAnyType1,
		                                 string CanAnyFormName1,
		                                 ref short? Privilege1,
		                                 string Type,
		                                 string Type1,
		                                 string Object,
		                                 string ParamSite,
		                                 ref string ApsParmApsmode,
		                                 ref string MrpParmReqSrc,
		                                 ref byte? CanDueNEProjected,
		                                 ref byte? CanDueLTProjected,
		                                 ref byte? SharedCustEnabled,
		                                 string CanAnyType2,
		                                 string CanAnyFormName2,
		                                 ref short? Privilege2,
		                                 string CanAnyType3,
		                                 string CanAnyFormName3,
		                                 ref short? Privilege3,
		                                 string CanAnyType4,
		                                 string CanAnyFormName4,
		                                 ref short? Privilege4,
		                                 ref short? VarTaxFreeImports,
		                                 ref string ConfigDetails,
		                                 ref string Site);
	}
	
	public class COQuickEntryPreLoadBinding : ICOQuickEntryPreLoadBinding
	{
		readonly IApplicationDB appDB;
		
		public COQuickEntryPreLoadBinding(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int COQuickEntryPreLoadBindingSp(ref short? DuePeriod,
		                                        string CanAnyType1,
		                                        string CanAnyFormName1,
		                                        ref short? Privilege1,
		                                        string Type,
		                                        string Type1,
		                                        string Object,
		                                        string ParamSite,
		                                        ref string ApsParmApsmode,
		                                        ref string MrpParmReqSrc,
		                                        ref byte? CanDueNEProjected,
		                                        ref byte? CanDueLTProjected,
		                                        ref byte? SharedCustEnabled,
		                                        string CanAnyType2,
		                                        string CanAnyFormName2,
		                                        ref short? Privilege2,
		                                        string CanAnyType3,
		                                        string CanAnyFormName3,
		                                        ref short? Privilege3,
		                                        string CanAnyType4,
		                                        string CanAnyFormName4,
		                                        ref short? Privilege4,
		                                        ref short? VarTaxFreeImports,
		                                        ref string ConfigDetails,
		                                        ref string Site)
		{
			DuePeriodType _DuePeriod = DuePeriod;
			LongList _CanAnyType1 = CanAnyType1;
			AuthorizationObjectNameType _CanAnyFormName1 = CanAnyFormName1;
			PrivilegeType _Privilege1 = Privilege1;
			StringType _Type = Type;
			StringType _Type1 = Type1;
			StringType _Object = Object;
			SiteType _ParamSite = ParamSite;
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			MrpReqSrcType _MrpParmReqSrc = MrpParmReqSrc;
			ListYesNoType _CanDueNEProjected = CanDueNEProjected;
			ListYesNoType _CanDueLTProjected = CanDueLTProjected;
			ListYesNoType _SharedCustEnabled = SharedCustEnabled;
			LongList _CanAnyType2 = CanAnyType2;
			AuthorizationObjectNameType _CanAnyFormName2 = CanAnyFormName2;
			PrivilegeType _Privilege2 = Privilege2;
			LongList _CanAnyType3 = CanAnyType3;
			AuthorizationObjectNameType _CanAnyFormName3 = CanAnyFormName3;
			PrivilegeType _Privilege3 = Privilege3;
			LongList _CanAnyType4 = CanAnyType4;
			AuthorizationObjectNameType _CanAnyFormName4 = CanAnyFormName4;
			PrivilegeType _Privilege4 = Privilege4;
			RetentionDaysType _VarTaxFreeImports = VarTaxFreeImports;
			ConfiguratorType _ConfigDetails = ConfigDetails;
			SiteType _Site = Site;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "COQuickEntryPreLoadBindingSp";
				
				appDB.AddCommandParameter(cmd, "DuePeriod", _DuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType1", _CanAnyType1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName1", _CanAnyFormName1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege1", _Privilege1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Type", _Type, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Type1", _Type1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Object", _Object, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParamSite", _ParamSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MrpParmReqSrc", _MrpParmReqSrc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDueNEProjected", _CanDueNEProjected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDueLTProjected", _CanDueLTProjected, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SharedCustEnabled", _SharedCustEnabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType2", _CanAnyType2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName2", _CanAnyFormName2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege2", _Privilege2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType3", _CanAnyType3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName3", _CanAnyFormName3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege3", _Privilege3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyType4", _CanAnyType4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanAnyFormName4", _CanAnyFormName4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Privilege4", _Privilege4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VarTaxFreeImports", _VarTaxFreeImports, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfigDetails", _ConfigDetails, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DuePeriod = _DuePeriod;
				Privilege1 = _Privilege1;
				ApsParmApsmode = _ApsParmApsmode;
				MrpParmReqSrc = _MrpParmReqSrc;
				CanDueNEProjected = _CanDueNEProjected;
				CanDueLTProjected = _CanDueLTProjected;
				SharedCustEnabled = _SharedCustEnabled;
				Privilege2 = _Privilege2;
				Privilege3 = _Privilege3;
				Privilege4 = _Privilege4;
				VarTaxFreeImports = _VarTaxFreeImports;
				ConfigDetails = _ConfigDetails;
				Site = _Site;
				
				return Severity;
			}
		}
	}
}
