using MongoDB.Bson;
using System;

namespace WebApi.Domain.Common
{
    public abstract class DocumentBase : IDocumentBase
    {
        public ObjectId Id { get; set; }
        public DateTime CreatedAt => Id.CreationTime;
    }
}
