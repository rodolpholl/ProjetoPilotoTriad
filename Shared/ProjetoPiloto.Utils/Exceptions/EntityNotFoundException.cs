﻿namespace ProjetoPiloto.Utils.Exceptions
{
    public class EntityNotFoundException : ApplicationException
    {
        public EntityNotFoundException(string name, object key)
        : base($"Entity \"{name}\" ({key}) was not found") { }
    }
}
