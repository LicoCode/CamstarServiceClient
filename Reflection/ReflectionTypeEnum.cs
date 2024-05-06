using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamstarServiceClient.Reflection
{
    public enum ReflectionTypeEnum
    {
        NamedDataObject,
        RevisionedObject,
        ServiceData,
        ServiceDataCollection,
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
        Other,
        DateTime
    }
}
