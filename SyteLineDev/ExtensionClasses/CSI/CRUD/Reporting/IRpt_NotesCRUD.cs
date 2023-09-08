using CSI.Data.CRUD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSI.CRUD.Reporting
{
    public interface IRpt_NotesCRUD
    {
        ICollectionLoadResponse Load(Guid? pRefRowPointer = null, int? pShowExternal = 1, int? pShowInternal = 1);
    }
}
