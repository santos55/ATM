using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Atm.Model.Entities;
using Atm.Infrastructure;
using Atm.Infrastructure.Repositories;
using Atm.DataHelpers;

namespace Atm.Services
{
    public interface ILoginService
    {
        ServiceResponse<bool> IsValidCard(string number);
        ServiceResponse<User> Login(string cardNumber, string pin);
    }
    public class LoginService : ILoginService
    {
        private readonly ICardRepository cardRepository;
        private readonly IUnitOfWork unitOfWork;
        public LoginService(ICardRepository cardRepository, IUnitOfWork unitOfWork)
        {
            this.cardRepository = cardRepository;
            this.unitOfWork = unitOfWork;
        }


        public ServiceResponse<bool> IsValidCard(string number)
        {
            var card = cardRepository.GetByNumber(number);
            if (card == null)
                return new ServiceResponse<bool> { Success = false, Data = false, ErrorMessage = "Card not found" };

            if (card.Blocked)
                return new ServiceResponse<bool> { Success = false, Data = false, ErrorMessage = "Card is blocked" };

            return new ServiceResponse<bool> { Success = true, Data = true }; ;
        }

        public ServiceResponse<User> Login(string cardNumber, string pin)
        {
            var card = cardRepository.GetByNumber(cardNumber);
            
            if (card == null)
            {
                return new ServiceResponse<User> { Success = false, ErrorMessage = "Card not found" };
            }

            if (card.Pin != pin)
            {
                card.WrongAttempts++;
                if (card.WrongAttempts == 4)
                {
                    card.Blocked = true;
                    Save();
                    return new ServiceResponse<User> { Success = false, ErrorMessage = "Invalid PIN. Card is blocked" };
                }
                return new ServiceResponse<User> { Success = false, ErrorMessage = "Invalid PIN" };
            }
            
            //Valid pin
            card.WrongAttempts = 0;
            cardRepository.Update(card);
            Save();

            return new ServiceResponse<User> { Success = true, Data=card.Account.User, ErrorMessage = "Invalid PIN" };
        }
        public void Save()
        {
            unitOfWork.Commit();
        }

    }
}