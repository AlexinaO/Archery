using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace Archery.Validators
{
    [SerializableAttribute]
    [SuppressMessageAttribute("Microsoft.Design", "CA1032:ImplementStandardExceptionConstructors", Justification = "SerializeObjectState used instead")]
    public class SaveChanges : DataException
    {

    }
}