using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Tapi.TrelloEntities.Board
{
    /// <summary>
    /// defines a class to specify which properties should be loaded by the api
    /// </summary>
    public class BoardOverviewQueryParameters
    {
        public BoardFields Fields { get; set; }

        /// <summary>
        /// Creates BoardProperties with all properties set to false
        /// Id is queried by default
        /// </summary>
        public BoardOverviewQueryParameters() { }

        public string ToQueryString()
        {
            var apiPropertyNames = new List<string>();
            foreach (var property in Fields.GetType().GetProperties())
            {
                var apiPropertyName = PropertyMappings.BoardFieldMappings[property.Name];
                var includeProperty = (bool)property.GetValue(this);
                if (includeProperty) apiPropertyNames.Add(apiPropertyName);
            }
            var fieldsQueryString = "fields=" + String.Join(",", apiPropertyNames);
            return fieldsQueryString;
        }

        public static readonly BoardOverviewQueryParameters AllFields = new BoardOverviewQueryParameters
        {
            Fields = BoardFields.All
        };
    }
}
