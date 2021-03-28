using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRoverAlgorithm
{
    public class RoverManagement
    {
        (int X, int Y) maxPoints;
        public string GetOutput(string input)
        {
            var rows = input.Split('\n').ToList();
            maxPoints =GetMaxPoints(rows[0]);
            rows.RemoveAt(0); // Remove the maxPoints row
            var Positions = GetPositions(rows);
            List<string> outputs = new List<string>();
            foreach (var p in Positions)
            {
                p.Move();
                outputs.Add($"{ p.X} { p.Y} { p.Direction}");
            }
            string output = string.Join('\r', outputs);
            return output;
        }

        private List<Position> GetPositions(List<string> rows)
        {
            try
            {
                var PositionRows = new List<Position>();
                for (int i = 0; i < rows.Count; i++)
                {
                    if (i % 2 != 0) //if i%2!=0 then this row is orientation row
                    {
                        // row[i-1] is (X Y Direction) row
                        // row[i] is orientation row
                        string x = rows[i - 1].Trim().Split(' ')[0];
                        string y = rows[i - 1].Trim().Split(' ')[1];
                        string direction = rows[i - 1].Trim().Split(' ')[2];
                        string orientation = rows[i].Trim();
                        PositionRows.Add(new Position(maxPoints)
                        {
                            X = Convert.ToInt32(x),
                            Y = Convert.ToInt32(y),
                            Direction = (Directions)Enum.Parse(typeof(Directions), direction),
                            Orientation = orientation
                        });
                    }
                }
                return PositionRows;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private (int X, int Y) GetMaxPoints(string input)
        {
            int X = Convert.ToInt32(input.Split(' ')[0]);
            int Y = Convert.ToInt32(input.Split(' ')[1]);
            return (X,Y);
        }
    }
}
