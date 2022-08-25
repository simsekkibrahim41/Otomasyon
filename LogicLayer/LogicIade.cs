using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;

namespace LogicLayer
{
    public class LogicIade
    {


        public static List<EntityIade> LogicıadeList()
        {
            return DALIade.IadeListesi();
        }

        public static int LogicIadeEkle(EntityIade entityIade)
        {
            return DALIade.iadeKitapEkle(entityIade);
        }

        public static bool LogicIadeSil(int id)
        {
            return DALIade.iadeKitapSil(id);
        }


    }
}
