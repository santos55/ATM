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
using Atm.Services.Responses;

namespace Atm.Services
{
    public interface IOperationService
    {
        BalanceResponse Balance(string cardNumber);
        
        bool Withdrawal(string number, double amount);
    }
    public class OperationService : IOperationService
    {        
        private readonly IOperationRepository operationRepository;
        private readonly ICardRepository cardRepository;
        private readonly IAccountRepository accountRepository;

        private readonly IUnitOfWork unitOfWork;
        public OperationService(IOperationRepository operationRepository, ICardRepository cardRepository, IAccountRepository accountRepository, IUnitOfWork unitOfWork)
        {
            this.operationRepository = operationRepository;
            this.cardRepository = cardRepository;
            this.accountRepository = accountRepository;

            this.unitOfWork = unitOfWork;
        }

        public BalanceResponse Balance(string cardNumber)
        {
            var card = cardRepository.GetByNumber(cardNumber);

            if (card == null)
                return null;

            var balance = new BalanceResponse
            {
                Date = DateTime.Now,
                Amount = card.Account.Balance,
                CardNumber = cardNumber
            };

            return balance;
        }

        public bool Withdrawal(string number, double amount)
        {
            var card = cardRepository.GetByNumber(number);
            if (card==null)
                return false;

            if (card.Account.Balance < amount)
            {
                return false;
            }

            //DO operation

            return true;
        }
        public void Save()
        {
            unitOfWork.Commit();
        }
        
    }
}