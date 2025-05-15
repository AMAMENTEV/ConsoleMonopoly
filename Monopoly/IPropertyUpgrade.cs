using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public interface IPropertyUpgrade
    {
        int GetRent();
        int GetLvl();
        void TryUpgrade(Player player);
    }
}
