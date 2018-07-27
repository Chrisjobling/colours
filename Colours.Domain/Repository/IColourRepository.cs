using Colours.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Colours.Domain.Repository
{
    public interface IColourRepository
    {
        IEnumerable<Colour> GetColours();
        void Update(Colour colour);
        Colour FindById(int id);
    }
}
