using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using jooledotnet.Models;
using jooledotnet.DAL;

namespace jooledotnet.DAL
{
    public class ProductInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ProductContext>
    {
        protected override void Seed(ProductContext context)
        {
            var products = new List<Product>
            {
            new Product{Menufacture="Siemens AG",Category="Electrical",Series = "AeroBreeze",Model = "temp",Price = 100.0,Description = "{\"power\": \"50W\", \"voltage\": \"220V\", \"fan speed\": \"1200 rpm\", \"height\": \"40 cm\", \"weight\": \"3 kg\"}",DateMenufactured=DateTime.Parse("2005-09-01")},
            new Product{Menufacture="General Electric",Category="Electrical",Series = "WindWhisper",Model = "temp",Price = 150.0,Description = "{\"power\": \"75W\", \"voltage\": \"110V\", \"fan speed\": \"1500 rpm\", \"height\": \"50 cm\", \"weight\": \"4.5 kg\"}",DateMenufactured=DateTime.Parse("2005-09-01")},
            new Product{Menufacture="Schneider Electric",Category="Electrical",Series = "CycloneX",Model = "temp",Price = 135.0,Description = "{\"power\": \"100W\", \"voltage\": \"240V\", \"fan speed\": \"1800 rpm\", \"height\": \"45 cm\", \"weight\": \"5 kg\"}",DateMenufactured=DateTime.Parse("2005-09-01")},
            new Product{Menufacture="ABB Ltd",Category="Electrical",Series = "temp",Model = "ZephyrLine",Price = 90.0,Description = "{\"power\": \"60W\", \"voltage\": \"220V\", \"fan speed\": \"1400 rpm\", \"height\": \"42 cm\", \"weight\": \"3.5 kg\"}",DateMenufactured=DateTime.Parse("2005-09-01")},
            new Product{
    Menufacture="Siemens AG",
    Category="Lighting",
    Series = "LumiPlus",
    Model = "LP-1000",
    Price = 50.0,
    Description = "{\"type\": \"LED Bulb\", \"wattage\": \"10W\", \"lumens\": \"800 lm\", \"color temperature\": \"3000K Warm White\", \"life span\": \"25000 hours\"}",
    DateMenufactured=DateTime.Parse("2019-04-12")
},

            new Product{
    Menufacture="General Electric (GE)",
    Category="Home Appliances",
    Series = "QuickCook",
    Model = "QC-500",
    Price = 300.0,
    Description = "{\"type\": \"Microwave Oven\", \"capacity\": \"1.5 cu ft\", \"power\": \"1000W\", \"features\": \"Convection, Grill\", \"color\": \"Stainless Steel\"}",
    DateMenufactured=DateTime.Parse("2020-08-25")
},
            new Product{
    Menufacture="Schneider Electric",
    Category="Automation",
    Series = "AutoSmart",
    Model = "AS-200",
    Price = 1200.0,
    Description = "{\"type\": \"PLC Controller\", \"inputs\": \"16 Digital\", \"outputs\": \"8 Digital\", \"communication\": \"Ethernet/IP, Modbus\", \"rating\": \"IP20\"}",
    DateMenufactured=DateTime.Parse("2018-11-30")
},
            new Product{
    Menufacture="ABB Ltd",
    Category="Energy",
    Series = "PowerSave",
    Model = "PS-500",
    Price = 750.0,
    Description = "{\"type\": \"Solar Inverter\", \"capacity\": \"5 kW\", \"efficiency\": \"98%\", \"features\": \"MPPT, Remote Monitoring\", \"protection\": \"IP65\"}",
    DateMenufactured=DateTime.Parse("2022-06-15")
},
            };

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
            var users = new List<User>
            {
            new User{UserName="username1",Password="passwordTest1"},
            new User{UserName="username2",Password="passwordTest2"},
            new User{UserName="username3",Password="passwordTest3"},

            };
            users.ForEach(s => context.Users.Add(s));
            context.SaveChanges();

        }
    }
}