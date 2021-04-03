using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CardManager : ICardService
    {
        ICardDal _cardDal;

        public CardManager(ICardDal cardDal)
        {
            _cardDal = cardDal;
        }

        public IResult CardControl(Card card)
        {
            var result=_cardDal.Get(c => card.CardNo == c.CardNo && card.Day == c.Day && card.Cvc == c.Cvc && card.Month == c.Month && card.UserName == c.UserName);
            if (result!=null)
            {
                return new SuccessResult("Başarılı");
            }
            return new ErrorResult("Hata");
        }
    }
}
