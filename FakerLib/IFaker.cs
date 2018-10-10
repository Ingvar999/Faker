using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTOLib;

namespace FakerLib
{
    public interface IFaker
    {
        T Create<T>() where T : DTO;
    }
}
