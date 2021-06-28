using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.IO;

namespace Pyrite.Content.Domain
{
    public class Resource
    {
        public string Identifier { get; private set; }

        public IEnumerable<KeyValuePair<string, StringValues>> Headers { get; private set; }

        public Stream Body { get; private set; }

        public Resource
        (
            string identifier,
            IEnumerable<KeyValuePair<string, StringValues>> headers,
            Stream body
        )
        : this
        (
            identifier,
            headers
        )
        {
            this.Body = body;
        }

        public Resource
        (
            string identifier,
            IEnumerable<KeyValuePair<string, StringValues>> headers
        )
        {
            this.Identifier = identifier;
            this.Headers = headers;
        }
    }
}