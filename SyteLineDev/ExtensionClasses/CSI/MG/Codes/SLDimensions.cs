//PROJECT NAME: CodesExt
//CLASS NAME: SLDimensions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Codes;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Codes
{
	[IDOExtensionClass("SLDimensions")]
	public class SLDimensions : ExtensionClassBase
	{

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GLAttributesUpdateSp(int? UpdateAnalysisAttributes,
		int? OverwriteExsiting,
		DateTime? TransDateStarting,
		DateTime? TransDateEnding,
		string AccountStarting,
		string AccountEnding,
		string DimensionStarting,
		string DimensionEnding,
		ref string Infobar,
        int? CommitSize,
        int? Debug,
        int? TaskID,
        int? ChartCount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGLAttributesUpdateExt = new GLAttributesUpdateFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGLAttributesUpdateExt.GLAttributesUpdateSp(UpdateAnalysisAttributes,
				OverwriteExsiting,
				TransDateStarting,
				TransDateEnding,
				AccountStarting,
				AccountEnding,
				DimensionStarting,
				DimensionEnding,
				Infobar,
                CommitSize,
                Debug,
                TaskID,
                ChartCount);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
