using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Domain.Entities
{
    public abstract class ExtensionBassEntities:BassEntites
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }

    }
}
