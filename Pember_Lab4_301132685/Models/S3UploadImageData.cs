using Amazon.DynamoDBv2.DocumentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pember_Lab4_301132685.Models
{
    class S3UploadImageData
    {
        public string ObjectKey { get; set; } = string.Empty;
        public List<UploadImageLabel> Tags { get; set; } = new();
        public string S3Acl { get; set; } = string.Empty;
        public string S3AclForThumbnail { get; set; } = string.Empty;

        public Document ToDocument()
        {
            var tagDocs = new List<Document>();
            foreach (var tag in Tags) { tagDocs.Add(tag.ToDocument()); }

            var doc = new Document
            {
                ["ObjectKey"] = ObjectKey,
                ["S3Acl"] = S3Acl,
                ["S3AclForThumbnail"] = S3AclForThumbnail,
                ["Labels"] = tagDocs
            };
            return doc;
        }
    }
}
