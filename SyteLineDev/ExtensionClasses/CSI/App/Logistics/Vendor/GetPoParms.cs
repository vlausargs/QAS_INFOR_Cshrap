//PROJECT NAME: CSIVendor
//CLASS NAME: GetPoParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IGetPoParms
	{
		(int? ReturnCode, byte? ParmsPostJour, decimal? ParmsEcConvFact, byte? PoParmsVendorRequired, byte? PoParmsAmendPo, string PoParmsPoChange, short? PurOrdTemplate) GetPoParmsSp(byte? ParmsPostJour,
		decimal? ParmsEcConvFact,
		byte? PoParmsVendorRequired,
		byte? PoParmsAmendPo,
		string PoParmsPoChange,
		string Site = null,
		short? PurOrdTemplate = null);
	}
	
	public class GetPoParms : IGetPoParms
	{
		readonly IApplicationDB appDB;
		
		public GetPoParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? ParmsPostJour, decimal? ParmsEcConvFact, byte? PoParmsVendorRequired, byte? PoParmsAmendPo, string PoParmsPoChange, short? PurOrdTemplate) GetPoParmsSp(byte? ParmsPostJour,
		decimal? ParmsEcConvFact,
		byte? PoParmsVendorRequired,
		byte? PoParmsAmendPo,
		string PoParmsPoChange,
		string Site = null,
		short? PurOrdTemplate = null)
		{
			ListYesNoType _ParmsPostJour = ParmsPostJour;
			EcConvFactorType _ParmsEcConvFact = ParmsEcConvFact;
			ByteType _PoParmsVendorRequired = PoParmsVendorRequired;
			ListYesNoType _PoParmsAmendPo = PoParmsAmendPo;
			ListAlwaysSometimesNeverType _PoParmsPoChange = PoParmsPoChange;
			SiteType _Site = Site;
			ReportTemplateIdType _PurOrdTemplate = PurOrdTemplate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetPoParmsSp";
				
				appDB.AddCommandParameter(cmd, "ParmsPostJour", _ParmsPostJour, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ParmsEcConvFact", _ParmsEcConvFact, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoParmsVendorRequired", _PoParmsVendorRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoParmsAmendPo", _PoParmsAmendPo, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoParmsPoChange", _PoParmsPoChange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PurOrdTemplate", _PurOrdTemplate, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ParmsPostJour = _ParmsPostJour;
				ParmsEcConvFact = _ParmsEcConvFact;
				PoParmsVendorRequired = _PoParmsVendorRequired;
				PoParmsAmendPo = _PoParmsAmendPo;
				PoParmsPoChange = _PoParmsPoChange;
				PurOrdTemplate = _PurOrdTemplate;
				
				return (Severity, ParmsPostJour, ParmsEcConvFact, PoParmsVendorRequired, PoParmsAmendPo, PoParmsPoChange, PurOrdTemplate);
			}
		}
	}
}
