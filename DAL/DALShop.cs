using System;
using System.Collections.Generic;
using System.Linq;
using motoStore.Models;


namespace motoStore.DAL
{
    class DALShop
    {
        MotoContext context;
        public DALShop()
        {
            context = new MotoContext();
        }

        public void Add(Bikeshop shop)
        {

            try
            {
                context.Bikeshops.Add(shop);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        public List<Bikeshop> ShowALL()
        {

            List<Bikeshop> shops = new List<Bikeshop>();
            using (MotoContext ctx = new MotoContext())
            {
                try
                {
                    shops = ctx.Bikeshops.ToList<Bikeshop>();

                }
                catch
                {
                    shops = null;
                }
            }
            return shops;
        }
        public Bikeshop Show(int Id)
        {
            Bikeshop shop = new Bikeshop();
            try
            {
                shop = context.Bikeshops.FirstOrDefault(n => n.Id == Id);

            }
            catch
            {
                shop = null;
            }
            return shop;
        }
        public bool Edit(Bikeshop model)
        {
            try
            {
                Bikeshop shop = context.Bikeshops.FirstOrDefault(n => n.Id == model.Id);
                shop.Id = model.Id;
                shop.Address = model.Address;
                shop.Phone_number = model.Phone_number;
                shop.Motoshop_name = model.Motoshop_name;
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
                Bikeshop shop = context.Bikeshops.FirstOrDefault(n => n.Id == model);
                context.Bikeshops.Remove(shop);
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
