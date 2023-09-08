//PROJECT NAME: PPIndPackExt
//CLASS NAME: PPOperTypeCodeMatls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production.PrintingPackaging;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.PPIndPack
{
	[IDOExtensionClass("PPOperTypeCodeMatls")]
	public class PPOperTypeCodeMatls : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PP_UpdateOperTypeCodeMaterialSp(string OperType,
		string OperTypeCode,
		string Item,
		decimal? StdConsumptionRate,
		int? NumberOfDimensions,
		int? DivideByUp,
		int? UseForMatchingCriteria)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPP_UpdateOperTypeCodeMaterialExt = new PP_UpdateOperTypeCodeMaterialFactory().Create(appDb);
				
				var result = iPP_UpdateOperTypeCodeMaterialExt.PP_UpdateOperTypeCodeMaterialSp(OperType,
				OperTypeCode,
				Item,
				StdConsumptionRate,
				NumberOfDimensions,
				DivideByUp,
				UseForMatchingCriteria);
				
				int Severity = result.Value;
				return Severity;
			}
		}
	}
}
