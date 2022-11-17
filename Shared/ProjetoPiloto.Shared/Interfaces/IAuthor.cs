﻿namespace ProjetoPiloto.Shared.Interfaces
{
    public interface IAuthor : IEntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Alias { get; set; }
    }
}
