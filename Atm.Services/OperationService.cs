using Atm.DataHelpers;
using Atm.Infrastructure.Repositories;
using Atm.Model.Entities;
using Atm.Services.Responses;
using System;

namespace Atm.Services
{
    public interface IOperationService
    {
        BalanceResponse Balance(string cardNumber);
        
        ServiceResponse<BalanceResponse> Withdrawal(string number, double amount);
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

            TrackOperation(card, OperationTypes.BalanceCheck);
            Save();

            var balance = new BalanceResponse
            {
                Date = DateTime.Now,
                Amount = card.Account.Balance,
                CardNumber = cardNumber
            };

            return balance;
        }


        public ServiceResponse<BalanceResponse> Withdrawal(string cardNumber, double amount)
        {
            var response = new ServiceResponse<BalanceResponse>
            {
                Data = new BalanceResponse { CardNumber = cardNumber },
                Success = false,
                ErrorMessage = string.Empty
            };

            var card = cardRepository.GetByNumber(cardNumber);
            if (card==null)
            {
                response.ErrorMessage = "Card not found";
                return response;
            }
            
            if (card.Account.Balance < amount)
            {
                response.ErrorMessage = "Operation denied. The amount exceeds the account balance.";
               return response;
            }

            //perform opertaion and track it.            
            card.Account.Balance = card.Account.Balance - amount;
            TrackOperation(card, OperationTypes.Withdrawal, amount);
            Save();

            //return balance
            response.Success = true;
            response.Data.Date = DateTime.Now;
            response.Data.Amount = card.Account.Balance;

            return response;
        }


        private void TrackOperation(Card card, OperationTypes type, double amount = 0)
        {
            var operation = new Operation
            {
                OpeartionType = type,
                CardId = card.CardId,
                Date = DateTime.UtcNow,
                Amount = amount
            };

            operationRepository.Add(operation);
        }


        public void Save()
        {
            unitOfWork.Commit();
        }
        
    }
}