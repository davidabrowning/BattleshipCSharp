﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipCSharp
{
    internal class Fleet : IAttackable
    {
        public List<Ship> Ships { get; private set; }
        public int Size { get { return Ships.Count; } }
        public Fleet()
        {
            Ships = new List<Ship>();
        }
        public void Add(Ship ship)
        {
            Ships.Add(ship);
        }
        public bool IsSunk()
        {
            foreach (Ship ship in Ships)
                if (!ship.IsSunk())
                    return false;
            return true;
        }
        public bool IsSunk(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.IsHit(location) && ship.IsSunk())
                    return true;
            return false;
        }
        public bool IsHit(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.IsHit(location))
                    return true;
            return false;
        }
        public bool Contains(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.Contains(location))
                    return true;
            return false;
        }
        public void ProcessHit(Location location)
        {
            foreach (Ship ship in Ships)
                if (ship.Contains(location))
                    ship.ProcessHit(location);
            if (IsSunk())
                TextPrinter.PrintSuccess("All ships in fleet have been sunk!");
        }
        public void PlaceRandomly(Board board)
        {
            foreach (Ship ship in Ships)
                ship.PlaceRandomly(board);
        }
    }
}
