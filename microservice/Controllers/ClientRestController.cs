using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using microservice.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Confluent.Kafka;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using microservice.Services;
using System.Threading.Tasks;

namespace microservice.Controllers
{
    [Route("/api/clients")]
    public class ClientRestController:Controller
    {
        public CatalogueDbRepository CatalogueRepository { get; set; }
        public ClientRestController(CatalogueDbRepository repository){
            this.CatalogueRepository=repository;
        }
        [HttpGet]
        public IEnumerable<Client> listCats(){
            return CatalogueRepository.Clients;
        }
        [HttpPost]
        public async Task<Client> save([FromBody]Client client){
            CatalogueRepository.Clients.Add(client);
            CatalogueRepository.SaveChanges();

            string serializedOrder = JsonSerializer.Serialize(client);

            Console.WriteLine("========");
            Console.WriteLine("Info: OrderController => Post => Recieved a new purchase order:");
            Console.WriteLine(serializedOrder);
            Console.WriteLine("=========");

            var producer = new ProducerWrapper("CLIENTS");
            await producer.writeMessage(serializedOrder);

            return client;
        }
        [HttpGet("{Id}")]
        public Client getOne(long Id){
            return CatalogueRepository.Clients.FirstOrDefault(p=>p.Id==Id);
        }
        [HttpPut("{Id}")]
        public Client update(long Id,[FromBody]Client Client){
            Client.Id=Id;
            CatalogueRepository.Clients.Update(Client);
            CatalogueRepository.SaveChanges();
            return Client;
        }
        [HttpDelete("{Id}")]
        public void delete(long Id){
            Client client=CatalogueRepository.Clients.FirstOrDefault(p=>p.Id==Id);
            CatalogueRepository.Remove(client);
            CatalogueRepository.SaveChanges();
        }
        [HttpGet("search")]
        public IEnumerable<Client> search(string q){
            return CatalogueRepository.Clients.Where(p=>p.Name.Contains(q));
        }
        [HttpGet("pagenate")]
        public IEnumerable<Client> page(int page=0,int size=5){
            int skipValue=(page-1)*size;
            return CatalogueRepository.Clients.Skip(skipValue).Take(size);
        }
    }
}