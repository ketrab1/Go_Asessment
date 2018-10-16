using System;

namespace GeneralKnowledge.Test.App.Domain.Model
{
    public class Country
    {
        public Country()
        {
            
        }

        public Country(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(name);
            Name = name;
            Id = Guid.NewGuid();
        }

        public string Name { get; set; }

        public virtual Asset Asset { get; set; }
        public Guid Id { get; set; }
    }
}