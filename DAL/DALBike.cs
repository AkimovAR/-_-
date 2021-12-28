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
                catch(Exception ex)
                {
                    string str = ex.Message;
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
                   bike.Id = model.Id;
                   bike.Brand_name = model.Brand_name;
                   bike.Max_speed = model.Max_speed;
                   bike.Model_name = model.Model_name;
                   bike.Power = model.Power;
                   bike.Price = model.Price;
                   bike.Torque = model.Torque;
                   bike.Transmis_type = model.Transmis_type;
                   bike.Color_name = model.Color_name;
                   bike.Complectation_name = model.Complectation_name;
                   bike.Availability = model.Availability;
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
           

        }
        public bool Remove(int model)
        {
            try
            {
                Bike temp = context.Bikes.FirstOrDefault(n => n.Id == model);
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
