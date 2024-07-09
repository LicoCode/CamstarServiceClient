using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarService.Reflection
{
    public enum ReflectionTypeEnum
    {
        NamedDataObject,
        RevisionedObject,
        Subentity,
        NamedSubentity,
        SubentityCollection,
        EnumValue,
        PrimitiveValue,
        NamedDataObjectCollection,
        RevisionedObjectCollection,
        Container,
        String,
        ObjectChanges,
        RevisionedObjectMaint,
        NamedDataObjectMaint,
        NamedSubentityChangesCollection,
        DateTime,
        ContainerCollection,
        Other
    }
}
