using Project0.Library.Control.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library.Model
{
    public abstract class AModelBase : XmlPersistence
    {
        protected readonly string _modelName;

        protected abstract void setModelName(string modelName);
    }
}
