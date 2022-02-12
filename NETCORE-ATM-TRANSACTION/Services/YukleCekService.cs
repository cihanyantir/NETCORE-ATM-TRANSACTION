//using NETCORE_ATM_TRANSACTION.IService;
//using NETCORE_ATM_TRANSACTION.Repository.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace NETCORE_ATM_TRANSACTION.Services
//{
//    public class YukleCekService : IGenericServiceYukleCek<Musteri>
//    {
//        List<Musteri> musteri = new List<Musteri>();
        


//        public YukleCekService()
//        {
//            for (int i = 0; i < 8; i++)
//            {
//                if (i < 5)
//                {
//                    musteri.Add(new Musteri() { Bankaid = 2, Money = 5000 + i * 100, Musteriid = i });
//                }
//                else musteri.Add(new Musteri() { Bankaid = 1, Money = 5000, Musteriid = i });
//            }
//        }

//        public Musteri TransactionYukle(int fromaccount, double amount)
//        {
           
//                //musteri = musteri.Where(x => x.Musteriid == fromaccount).Select(s => { s.Money +=amount; return s; }).ToList();
//                musteri.Where(x => x.Musteriid == fromaccount).ToList().ForEach(s => s.Money +=amount);

            

//            return musteri.Where(x => x.Musteriid == fromaccount).SingleOrDefault(); //Doldurulacak
//        }

//        public Musteri TransactionCek(int fromaccount, double amount)
//        { 
//            if(MoneyService.Enough(fromaccount,amount))
//            { musteri.Where(x => x.Musteriid == fromaccount).ToList().ForEach(s => s.Money -= amount); }


//            return musteri.Where(x => x.Musteriid == fromaccount).SingleOrDefault(); //Doldurulacak
//        }
//    }
//}
