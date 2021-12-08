using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using motoStore.Models;

namespace motoStore.DAL
{
    class DALBike
    {
        MotoContext context;
        public DALBike()
        {
            context = new MotoContext();
        }

        public void Add(Bike bike)
        {

            try
            {
                context.Bikes.Add(bike);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }                      
        }
        public List<Bike> ShowALL()
        {

            List<Bike> bikes = new List<Bike>();
            using (MotoContext ctx = new MotoContext())
            {
                try
                {
                    bikes = ctx.Bikes.ToList<Bike>();

                }
                catch
                {
                    bikes = null;
                }
            }
               
            return bikes;
        }
        public Bike Show(int Id)
        {
            Bike bike = new Bike();
            try
            {
                bike = context.Bikes.FirstOrDefault(n => n.Id == Id);

            }
            catch
            {
                bike = null;             
            }
            return bike;
        }
        public bool Edit(Bike model)
        {
            try
            {
                Bike bike = context.Bikes.FirstOrDefault(n => n.Id == model.Id);
                bike = model;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           

        }
        public bool Remove(Bike model)
        {
            try
            {
                Bike temp = context.Bikes.FirstOrDefault(n => n.Id == model.Id);
                context.Bikes.Remove(temp);
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
