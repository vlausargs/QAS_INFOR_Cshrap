using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using CSI.Data.SQL.UDDT;

namespace CSI.ExternalContracts.OfficeIntegration.Excel
{
    public interface ISLDimAttributes
    {
        DataTable CLM_DimSubCollectionSp(DimensionObjectType ObjectName,
                                        RowPointerType TableRowPointer,
                                        DimensionNameType Dimension,
                                        LongListType FilterString,
                                        StringType OutputFormat);
    }
}
