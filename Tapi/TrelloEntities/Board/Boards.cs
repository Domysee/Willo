﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tapi.WebConnection;

namespace Tapi.TrelloEntities.Board
{
    public class Boards
    {
        private TrelloWebClient webClient;

        public Boards(TrelloWebClient webClient)
        {
            this.webClient = webClient;
        }

        public async Task<IEnumerable<Board>> GetAll(MemberId memberId)
        {
            var url = $"{ConnectionData.BaseUrl}/members/{memberId}/boards";
            var result = await webClient.Get(url);
            //foreach(var boardJson in (result as JArray))
            //{

            //}
            return null;
        }
    }
}
