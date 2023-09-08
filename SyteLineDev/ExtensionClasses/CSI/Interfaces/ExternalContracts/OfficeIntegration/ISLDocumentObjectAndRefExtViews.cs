using System;
using System.Collections.Generic;
using System.Text;

namespace CSI.ExternalContracts.OfficeIntegration.Outlook
{
    public interface ISLDocumentObjectAndRefExtViews
    {
        int UpdateDocumentObjectAndRefExtViewsSp(string TableName,
                                                 Guid? TableRowPointer,
                                                 decimal? RefSequence,
                                                 ref Guid? DocumentObjectRowPointer,
                                                 Guid? RowPointer,
                                                 string DocumentName,
                                                 decimal? Sequence,
                                                 string Description,
                                                 string DocumentType,
                                                 string DocumentExtension,
                                                 byte? Internal,
                                                 string Revision,
                                                 string Status,
                                                 DateTime? effective_start_date,
                                                 DateTime? effective_end_date,
                                                 byte? is_external,
                                                 byte[] DocumentObject,
                                                 ref string Infobar);
    }
}
