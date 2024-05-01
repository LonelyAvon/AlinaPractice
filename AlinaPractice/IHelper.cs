using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AlinaPractice.Models;

namespace AlinaPractice
{
    public interface IHelper
    {
        public static PracticeAlinaContext GetContext() => new PracticeAlinaContext();
    }
}
