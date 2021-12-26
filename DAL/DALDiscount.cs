using System;
using System.Collections.Generic;
using System.Linq;
using motoStore.Models;


namespace motoStore.DAL
{
    class DALDiscount
    {
        MotoContext context;
        public DALDiscount()
        {
            context = new MotoContext();

        }
        public void Add(Discount dscnt)
        {

            try
            {
                context.Discounts.Add(dscnt);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        public List<Discount> ShowALL()
        {

            List<Discount> discounts = new List<Discount>();
            using (MotoContext ctx = new MotoContext())
            {
                try
                {
                    discounts = ctx.Discounts.ToList<Discount>();

                }
                catch
                {
                    discounts = null;
                }
            }
            return discounts;
        }
        public Discount Show(int Id)
        {
            Discount discount = new Discount();
            try
            {
                discount = context.Discounts.FirstOrDefault(n => n.Id == Id);

            }
            catch
            {
                discount = null;
            }
            return discount;
        }
        public bool Remove(int model)
        {
            try
            {
                Discount discount = context.Discounts.FirstOrDefault(n => n.Id == model);
                context.Discounts.Remove(discount);
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
