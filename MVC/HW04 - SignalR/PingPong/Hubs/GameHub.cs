﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;

namespace PingPong.Hubs
{
    [HubName("game")]
    public class GameHub : Hub
    {
        private static bool otherUser = false;

        public override Task OnDisconnected()
        {
            otherUser = false;
            return base.OnDisconnected();
        }

        public void DrawOpponent(int y)
        {
            Clients.Others.drawOpponent(y);
        }

        public void GameWon(int player)
        {
            Clients.All.resetGame(player);
        }


        public bool CheckForUser(bool a)
        {
            if (!otherUser)
            {
                otherUser = true;
                return false;
            }

            bool ballLeft = new Random().Next(0, 2) > 0 ? true : false;

            Clients.All.gameStarts(ballLeft);

            otherUser = true;
            return otherUser;
        }
    }
}