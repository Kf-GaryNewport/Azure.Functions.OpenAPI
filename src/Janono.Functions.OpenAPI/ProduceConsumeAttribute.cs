using System;
using System.Collections.Generic;

namespace Janono.Functions.OpenAPI
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ProduceConsumeAttribute : Attribute
    {
        public string Verb { get; }

        public IEnumerable<string> Produces { get; }

        public IEnumerable<string> Consumes { get; set; }

        public ProduceConsumeAttribute(string verb, IEnumerable<string> produceTypes, IEnumerable<string> consumeTypes)
        {
            if (string.IsNullOrWhiteSpace(verb))
                throw new ArgumentNullException(nameof(verb));
            Verb = verb;
            Produces = produceTypes ?? throw new ArgumentNullException(nameof(produceTypes));
            Consumes = consumeTypes ?? throw new ArgumentNullException(nameof(consumeTypes));
        }
    }
}
