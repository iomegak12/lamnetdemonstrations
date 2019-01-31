using Lam.Libraries.CreditCards.Interfaces;
using Lam.Libraries.DBStore.Interfaces;
using Lam.Libraries.Models;
using Lam.Libraries.Orders.Interfaces;
using Lam.Libraries.Stocks.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lam.Libraries.Orders.Impl
{
    public class OnlineOrderProcessorImpl : IOnlineOrderProcessor
    {
        private IStockVerifier stockVerifier = default(IStockVerifier);
        private ICreditCardValidator creditCardValidator = default(ICreditCardValidator);
        private IDbStore dbStore = default(IDbStore);

        public event OrderCompletionInfo OrderCompleted;

        public OnlineOrderProcessorImpl(IStockVerifier stockVerifier,
            ICreditCardValidator creditCardValidator, IDbStore dbStore)
        {
            if (stockVerifier == default(IStockVerifier))
                throw new ArgumentNullException(nameof(stockVerifier));

            if (creditCardValidator == default(ICreditCardValidator))
                throw new ArgumentNullException(nameof(creditCardValidator));

            if (dbStore == default(IDbStore))
                throw new ArgumentNullException(nameof(dbStore));

            this.stockVerifier = stockVerifier;
            this.creditCardValidator = creditCardValidator;
            this.dbStore = dbStore;
        }

        public void ProcessOrderSync(OnlineOrder onlineOrder, CreditCardInfo creditCardInfo)
        {
            var validation = onlineOrder != default(OnlineOrder) &&
                creditCardInfo != default(CreditCardInfo);

            if (!validation)
                throw new ArgumentNullException();

            var isStockAvailable = this.stockVerifier.VerifiyStockAvailability(onlineOrder.ProductId, onlineOrder.Units);
            var isCreditCardValid = this.creditCardValidator.Validate(creditCardInfo);
            var businessValidation = isStockAvailable && isCreditCardValid;

            if (!businessValidation)
                throw new ApplicationException("Business Validation Failed, Due to Stock or Credit Cards!");

            Thread.Sleep(1500);

            var saveStatus = this.dbStore.SaveOrderToDb(onlineOrder);
            var statusDescription = saveStatus ? "ACCEPTED" : "REJECTED";

            if (this.OrderCompleted != default(OrderCompletionInfo))
            {
                this.OrderCompleted(onlineOrder, statusDescription);
            }
        }

        public void ProcessOrder(OnlineOrder onlineOrder, CreditCardInfo creditCardInfo)
        {
            var thread = new Thread(
                new ThreadStart(delegate ()
                {
                    ProcessOrderSync(onlineOrder, creditCardInfo);
                }));

            thread.Start();
        }
    }
}
