﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sprint0
{
    public interface ICommand
    {
        /* Commands include setting the character sprite and exiting */
        void Execute();
    }
}
