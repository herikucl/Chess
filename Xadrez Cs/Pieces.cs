﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess_Cs
{
    public abstract class Piece
    {
        public int PosX;
        public int PosY;
        public bool Alive = true;
        public bool black;
        public string name;
        public Image img;
        public bool CanMove;

        public Piece(int x, int y, bool b)
        {
            black = b;
            PosX = x;
            PosY = y;
        }

        public virtual bool Move(Point location)
        {
            return CanMove;
        }

        public virtual bool Kill(Point point)
        {
            return false;
        }
    }

        public class King : Piece
    {
        public King(int x, int y, bool black) : base(x, y, black)
        {
            if (black)
            {
                img = Image.FromFile("BKing.png");
                name = "BKing";
            }
            else
            {
                img = Image.FromFile("WKing.png");
                name = "WKing";
            }
        }

        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if ((Math.Abs(newLocation.X - PosX)<=1) && (Math.Abs(newLocation.Y - PosY) <= 1))
            {
                CanMove = true;
            }
            return CanMove; 
        }
    }

    public class Queen : Piece
    {
        public Queen(int x, int y, bool black) : base(x, y, black)
        {
            
            if (black)
            {
                img = Image.FromFile("BQueen.png");
                name = "BQueen";
            }
            else
            {
                img = Image.FromFile("WQueen.png");
                name = "WQueen";
            }
        }

        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (((Math.Abs(newLocation.X - PosX) > 0) && (Math.Abs(newLocation.Y - PosY) == 0)) || ((Math.Abs(newLocation.X - PosX) == 0) && (Math.Abs(newLocation.Y - PosY) > 0)) || (Math.Abs(newLocation.X - PosX) == Math.Abs(newLocation.Y - PosY)))
            {
                CanMove = true;
            }
            return CanMove;
        }
    }

    public class Bishop : Piece
    {
        public Bishop(int x, int y, bool black) : base(x, y, black)
        {
            
            if (black)
            {
                img = Image.FromFile("BBishop.png");
                name = "BBishop";
            }
            else
            {
                img = Image.FromFile("WBishop.png");
                name = "WBishop";
            }
        }
        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (Math.Abs(newLocation.X - PosX) == Math.Abs(newLocation.Y - PosY))
            {
                CanMove = true;
            }
            return CanMove;
        }

    }

    public class Rook : Piece
    {
        public Rook(int x, int y, bool black) : base(x, y, black)
        {
            if (black)
            {
                img = Image.FromFile("BRook.png");
                name = "BRook";
            }
            else
            {
                img = Image.FromFile("WRook.png");
                name = "WRook";
            }
        }
        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (((Math.Abs(newLocation.X - PosX) > 0) && (Math.Abs(newLocation.Y - PosY) == 0)) || ((Math.Abs(newLocation.X - PosX) == 0) && (Math.Abs(newLocation.Y - PosY) > 0)))
            {
                CanMove = true;
            }
            return CanMove;
        }
    }

    public class Knight : Piece
    {
        public Knight(int x, int y, bool black) : base(x, y, black)
        { 
            if (black)
            {
                img = Image.FromFile("BKnight.png");
                name = "BKnight";
            }
            else
            {
                img = Image.FromFile("WKnight.png");
                name = "WKnight";
            }
        }

        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (((newLocation.X - PosX == 1) && (newLocation.Y - PosY == 2))   ||
                ((newLocation.X - PosX == 1) && (newLocation.Y - PosY == -2))  ||
                ((newLocation.X - PosX == -1) && (newLocation.Y - PosY == 2))  ||
                ((newLocation.X - PosX == -1) && (newLocation.Y - PosY == -2)) ||
                ((newLocation.X - PosX == 2) && (newLocation.Y - PosY == 1))   ||
                ((newLocation.X - PosX == 2) && (newLocation.Y - PosY == -1))  ||
                ((newLocation.X - PosX == -2) && (newLocation.Y - PosY == 1))  ||
                ((newLocation.X - PosX == -2) && (newLocation.Y - PosY == -1)))
            {
                CanMove = true;
            }
            return CanMove;
        }
    }

    public class Pawn : Piece
    {
        public Pawn(int x, int y, bool black) : base(x, y, black)
        {
            if (black)
            {
                img = Image.FromFile("BPawn.png");
                name = "BPawn";
            }
            else
            {
                img = Image.FromFile("WPawn.png");
                name = "WPawn";
            }
        }
        public override bool Move(Point newLocation)
        {
            CanMove = false;
            if (newLocation.X - PosX == 0) 
            {
                if (((name == "WPawn") && (newLocation.Y - PosY == -1)) || ((name == "BPawn") && (newLocation.Y - PosY == 1)))
                {
                    CanMove = true;
                }
            }
            return CanMove;
        }

        public override bool Kill(Point newLocation)
        {
            if (Math.Abs(newLocation.X - PosX) == 1)
            {
                if (((name == "WPawn") && (newLocation.Y - PosY == -1)) || ((name == "BPawn") && (newLocation.Y - PosY == 1)))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
