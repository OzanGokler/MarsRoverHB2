using MarsRover2.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover2.Interfaces
{
    public interface IRover
    {
        void Move();
        Direction ChangeDirection(char direction);

    }
}
