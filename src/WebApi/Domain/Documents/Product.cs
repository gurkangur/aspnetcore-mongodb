using WebApi.Domain.Common;

namespace WebApi.Domain.Documents
{
    [BsonCollection("products")]
    public class Product : DocumentBase
    {
        public string ProductName { get; set; }
    }
}
