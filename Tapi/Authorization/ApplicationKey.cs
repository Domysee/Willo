using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Tapi.Authorization
{
    public struct ApplicationKey
    {
        private string key;

        public ApplicationKey(string key)
        {
            checkKey(key);
            this.key = key;
        }

        public static implicit operator ApplicationKey(string key)
        {
            return new ApplicationKey(key);
        }

        public static explicit operator string(ApplicationKey key)
        {
            return key.key;
        }

        private static void checkKey(string key)
        {
            if (key.Length != 32)
                throw new ArgumentException("A Trello application key must be 32 characters");

            var allowedCharacters = new Regex("^[0-9a-z]*$");
            if (!allowedCharacters.IsMatch(key))
                throw new ArgumentException("A Trello application key must only contain alphanumeric, lowercase characters");
        }

        public override string ToString()
        {
            return key;
        }
    }
}
