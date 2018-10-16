using System;

namespace GeneralKnowledge.Test.App.Domain.Model
{
    public class MimeType
    {
        public MimeType()
        {
            
        }

        public MimeType(string type)
        {
            if (string.IsNullOrEmpty(type))
                throw new ArgumentNullException(type);
            Type = type;
            Id = Guid.NewGuid();
        }

        public string Type { get; set; }

        public virtual Asset Asset { get; set; }
        public Guid Id { get; set; }

    }
}