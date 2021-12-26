using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using motoStore.Models;

namespace motoStore.DAL
{
    class DALOrder
    {
        MotoContext context;
        public DALOrder()
        {
            context = new MotoContext();
        }
        public void Add(Order  order)
        {

            try
            {

                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        public List<Order> ShowALL()
        {

            List<Order> orders = new List<Order>();
            using (MotoContext ctx = new MotoContext())
            {
                try
                {
                    orders = ctx.Orders.ToList<Order>();
                }
                catch
                {
                    orders = null;
                }
            }
            return orders;
        }
        public Order Show(int Id)
        {
            Order order = new Order();
            try
            {
                order = context.Orders.FirstOrDefault(n => n.Id == Id);

            }
            catch
            {
                order = null;
            }
            return order;
        }
        public bool Edit(Order model)
        {
            try
            {
                Order order = context.Orders.FirstOrDefault(n => n.Id == model.Id);
                order = model;
                context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool Remove(int model)
        {
            try
            {
                Order order = context.Orders.FirstOrDefault(n => n.Id == model);
                context.Orders.Remove(order);
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
