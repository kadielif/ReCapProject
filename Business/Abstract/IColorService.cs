using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface IColorService
    {
        IDataResult<List<Color>> GetAll();
        IDataResult<Color> Get(Expression<Func<Color, bool>> filter = null);

        IResult Add(Color color);
        IResult Delete(Color color);
        IResult Update(Color color);
    }
}
