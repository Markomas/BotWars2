﻿using BotWars2Server.Code.Logic;
using BotWars2Server.Code.State;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotWars2Server.Tests.LogicTests.GameManagerTests
{
    public class CheckForCollisionsTests
    {
        [Test]
        public void TestCollision()
        {
            var players = new Player[]
            {
                new Player(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new Position(5, 50)),
                new Player(Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), new Position(5, 15))
            };
            var arena = new Arena
            {
                Height = 100,
                Width = 100,
                Players = players,
                Tracks = new Track[]
                {
                    new Track(players.First()),
                    new Track(players.Last())
                }
            };
            for (int i = 0; i < players.First().Position.Y; i++)
            {
                arena.Tracks.ElementAt(0).PreviousPositions.Add(new Position(players.First().Position.X, i));
            }

            GameManager.CheckForCollisions(arena);

            Assert.IsFalse(players.Last().IsAlive);
        }
    }
}
