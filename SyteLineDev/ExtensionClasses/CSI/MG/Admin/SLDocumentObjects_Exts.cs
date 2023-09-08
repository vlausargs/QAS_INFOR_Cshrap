//PROJECT NAME: AdminExt
//CLASS NAME: SLDocumentObjects_Exts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Admin;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Admin
{
	[IDOExtensionClass("SLDocumentObjects_Exts")]
	public class SLDocumentObjects_Exts : ExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UpdateDocumentObject_ExtSp(string DocumentName,
		decimal? Sequence,
		string Description,
		string DocumentType,
		string DocumentExtension,
		int? Internal,
		Guid? DocumentObjectRowPointer,
		string Revision,
		string Status,
		DateTime? effective_start_date,
		DateTime? effective_end_date,
		int? is_external,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUpdateDocumentObject_ExtExt = new UpdateDocumentObject_ExtFactory().Create(appDb);
				
				var result = iUpdateDocumentObject_ExtExt.UpdateDocumentObject_ExtSp(DocumentName,
				Sequence,
				Description,
				DocumentType,
				DocumentExtension,
				Internal,
				DocumentObjectRowPointer,
				Revision,
				Status,
				effective_start_date,
				effective_end_date,
				is_external,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
	}
}
