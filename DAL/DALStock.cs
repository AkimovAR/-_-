using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using motoStore.Models;

namespace motoStore.DAL
{
    class DALStock
    {
        MotoContext context;
        public DALStock()
        {
            context = new MotoContext();
        }

        public void Add(Stock stck)
        {

            try
            {
                context.Stocks.Add(stck);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        public List<Stock> ShowALL()
        {

            List<Stock> stocks = new List<Stock>();
            using (MotoContext ctx = new MotoContext())
            {
                try
                {
                    stocks = ctx.Stocks.ToList<Stock>();
                }
                catch
                {
                    stocks = null;
                }
            }
            return stocks;
        }
        public Stock Show(int Id)
        {
            Stock stock = new Stock();
            try
            {
                stock = context.Stocks.FirstOrDefault(n => n.Id == Id);

            }
            catch
            {
                stock = null;
            }
            return stock;
        }
        public bool Edit(Stock model)
        {
            try
            {
                Stock stock = context.Stocks.FirstOrDefault(n => n.Id == model.Id);
                stock = model;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Remove(Stock model)
        {
            try
            {
                Stock stock = context.Stocks.FirstOrDefault(n => n.Id == model.Id);
                context.Stocks.Remove(stock);
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
