using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7x7_game
{
    internal class MowingCube
    {
        Color[] sides = new Color[5];
        byte red = 2;

        public Color GetColor(int side)
        {
            return sides[side];
        }

        public MowingCube(Color[] sides)
        {
            this.sides = sides;
        }

        public string[,] MoveUp(string[,] map, byte[] palayerLocation, out string succes, out byte[] palayerLocation1)
        {
            if (palayerLocation[0] == 7 && palayerLocation[1] == 3)
            {
                succes = "Finish";
                palayerLocation1 = palayerLocation;
                return map;
            }
            if(map[palayerLocation[0]-1,palayerLocation[1]] != " H " && sides[0] != Color.piros)
            {
                switch (red)
                {
                    case 2:
                        {
                            red = 0;
                            sides[0] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                    case 4:
                        {
                            red = 2;
                            sides[2] = Color.piros;
                            sides[4] = Color.kék;
                            break;
                        }
                }
                map[palayerLocation[0], palayerLocation[1]] = "   ";
                map[palayerLocation[0] - 1, palayerLocation[1]] = " # ";
                palayerLocation1 = new byte[] { (byte)((int)palayerLocation[0] - 1), palayerLocation[1] };
                succes = "succes";
                return map;
            }
            succes = "failed";
            palayerLocation1 = palayerLocation;
            return map;
        }
        public string[,] MoveDown(string[,] map, byte[] palayerLocation, out string succes, out byte[] palayerLocation1)
        {
            if (palayerLocation[0] == 7 && palayerLocation[1] == 3)
            {
                succes = "Finish";
                palayerLocation1 = palayerLocation;
                return map;
            }
            if (map[palayerLocation[0] + 1, palayerLocation[1]] != " H " && sides[4] != Color.piros)
            {
                switch (red)
                {
                    case 0:
                        {
                            red = 2;
                            sides[2] = Color.piros;
                            sides[0] = Color.kék;
                            break;
                        }
                    case 2:
                        {
                            red = 4;
                            sides[4] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                }
                map[palayerLocation[0], palayerLocation[1]] = "   ";
                map[palayerLocation[0] + 1, palayerLocation[1]] = " # ";
                palayerLocation1 = new byte[] { (byte)((int)palayerLocation[0] + 1), palayerLocation[1] };
                succes = "succes";
                return map;
            }
            succes = "failed";
            palayerLocation1 = palayerLocation;
            return map;
        }
        public string[,] MoveLeft(string[,] map, byte[] palayerLocation, out string succes, out byte[] palayerLocation1)
        {
            if (palayerLocation[0] == 7 && palayerLocation[1] == 3)
            {
                succes = "Finish";
                palayerLocation1 = palayerLocation;
                return map;
            }
            if (map[palayerLocation[0], palayerLocation[1] - 1] != " H " && sides[1] != Color.piros)
            {
                switch (red)
                {
                    case 2:
                        {
                            red = 1;
                            sides[1] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                    case 3:
                        {

                            red = 2;
                            sides[2] = Color.piros;
                            sides[3] = Color.kék;
                            break;
                        }
                }
                map[palayerLocation[0], palayerLocation[1]] = "   ";
                map[palayerLocation[0], palayerLocation[1] - 1] = " # ";
                palayerLocation1 = new byte[] { palayerLocation[0], (byte)((int)palayerLocation[1] - 1) };
                succes = "succes";
                return map;
            }
            palayerLocation1 = palayerLocation;
            succes = "failed";
            return map;
        }
        public string[,] MoveRight(string[,] map, byte[] palayerLocation, out string succes, out byte[] palayerLocation1)
        {
            if (palayerLocation[0] == 7 && palayerLocation[1] == 3)
            {
                succes = "Finish";
                palayerLocation1 = palayerLocation;
                return map;
            }
            if (map[palayerLocation[0], palayerLocation[1] + 1] != " H " && sides[3] != Color.piros)
            {
                switch (red)
                {
                    case 1:
                        {

                            red = 2;
                            sides[2] = Color.piros;
                            sides[1] = Color.kék;
                            break;
                        }
                    case 2:
                        {

                            red = 3;
                            sides[3] = Color.piros;
                            sides[2] = Color.kék;
                            break;
                        }
                }
                map[palayerLocation[0], palayerLocation[1]] = "   ";
                map[palayerLocation[0], palayerLocation[1] + 1] = " # ";
                palayerLocation1 = new byte[] { palayerLocation[0], (byte)(palayerLocation[1] + 1) };
                succes = "succes";
                return map;
            }
            palayerLocation1 = palayerLocation;
            succes = "failed";
            return map;
        }

        public bool TryMoveUp(string[,] map, byte[] palayerLocation)
        {
            if (map[palayerLocation[0] - 1, palayerLocation[1]] != " H " && sides[0] != Color.piros)
            {
                return true;
            }
            return false;
        }
        public bool TryMoveDown(string[,] map, byte[] palayerLocation)
        {
            if (map[palayerLocation[0] + 1, palayerLocation[1]] != " H " && sides[4] != Color.piros)
            {
                
                return true;
            }
            return false;
        }
        public bool TryMoveLeft(string[,] map, byte[] palayerLocation)
        {
            if (map[palayerLocation[0], palayerLocation[1] - 1] != " H " && sides[1] != Color.piros)
            {
                return true;
            }
            return false;
        }
        public bool TryMoveRight(string[,] map, byte[] palayerLocation)
        {
            if (map[palayerLocation[0], palayerLocation[1] + 1] != " H " && sides[3] != Color.piros)
            {
                return true;
            }
            return false;
        }
    }



    public enum Color { kék, piros}
}
