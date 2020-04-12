using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollApp.Models
{
    public static class DbInitializer
    {
        public static void Seed(AppDbContext context)
        {
            IEnumerable<Offer> offers = new List<Offer>()
            {
                new Offer()
                {
                    Title = "Индивидуальные занятия",
                    Description = "Занятия с учителем по индивидуальной программе",
                    Price = 125
                },
                new Offer()
                {
                    Title = "Групповые занятия",
                    Description = "Занятия в группе из 4-5 учеников одного уровня",
                    Price = 400
                }
            };
            context.Offers.AddRange(offers);
            context.SaveChanges();

            IEnumerable<ClientRequestState> clientRequestStates = new List<ClientRequestState>()
            {
                new ClientRequestState()
                {
                    Title = "Новый запрос",
                    IsNewRequest = true
                },
                new ClientRequestState()
                {
                    Title = "Обработан, без ответа",
                    IsNewRequest = false
        },
                new ClientRequestState()
                {
                    Title = "Обработан, в базе данных",
                    IsNewRequest = false
                },
                new ClientRequestState()
                {
                    Title = "Обработан, запись на занятия",
                    IsNewRequest = false
                }
            };
            context.ClientRequestStates.AddRange(clientRequestStates);
            context.SaveChanges();
        }
    }
}
