using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pember_Lab4_301132685.Models
{
    class UploadImageLabel
    {
        public string Label { get; set; } = string.Empty;
        public string Confidence { get; set; } = string.Empty; 
        public string AdditionalInfo { get; set; } = string.Empty;

        public Document ToDocument()
        {
            return new Document
            {
                ["Label"] = Label,
                ["Confidence"] = Confidence,
                ["AdditionalInfo"] = AdditionalInfo
            };
        }
    }
}
