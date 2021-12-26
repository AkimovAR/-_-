using motoStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace motoStore.DAL
{
    class DALClient
    {
        MotoContext context;
        public DALClient()
        {
            context = new MotoContext();
        }
        public void Add(Client client)
        {

            try
            {
                context.Clients.Add(client);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }
        public List<Client> ShowALL()
        {

            List<Client> clients = new List<Client>();
            using (MotoContext ctx = new MotoContext())
            {
                try
                {
                    clients = ctx.Clients.ToList<Client>();

                }
                catch
                {
                    clients = null;
                }
            }
            return clients;
        }
        public Client Show(int Id)
        {
            Client client = new Client();
            try
            {
                client = context.Clients.FirstOrDefault(n => n.Id == Id);

            }
            catch
            {
                client = null;
            }
            return client;
        }
        public bool Edit(Client model)
        {
            try
            {
                Client client = context.Clients.FirstOrDefault(n => n.Id == model.Id);
                client = model;
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
                Client client = context.Clients.FirstOrDefault(n => n.Id == model);
                context.Clients.Remove(client);
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
