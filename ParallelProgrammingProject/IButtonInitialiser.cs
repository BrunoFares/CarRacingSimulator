using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParallelProgrammingProject
{
    internal interface IButtonInitialiser
    {
        public Button LoadButton(string btText, Point location, Size size, bool enabled);
    }
}