﻿namespace LojinhaDaPaulinha.Data.Entities
{
    public class Product : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public double Price { get; set; }

        public bool IsAvaliable { get; set; }
    }
}